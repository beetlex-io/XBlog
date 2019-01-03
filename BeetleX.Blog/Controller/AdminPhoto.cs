using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;
using BeetleX.Blog.DBModules;
using Peanut;
using System.Linq;
using BeetleX.FastHttpApi.Data;

namespace BeetleX.Blog.Controller
{
    [Controller(BaseUrl = "/admin/photo")]
    [AdminFilter]
    public class AdminPhoto
    {

        public void Add(string title)
        {
            Photo photo = new Photo();
            photo.Title = title;
            photo.Save();
        }

        public void Del(long[] id)
        {
            if (id != null && id.Length > 0)
            {
                (PhotoItem.photoID == id).Delete<PhotoItem>();
                (Photo.iD == id).Delete<Photo>();
            }
        }

        private static byte[] mImageBuffer = new byte[1024 * 1024];

        public void SetDefault(string id)
        {
            PhotoItem item = DBContext.Load<PhotoItem>(id);
            if (item != null)
            {
                Photo photo = DBContext.Load<Photo>(item.PhotoID);
                if (photo != null)
                {
                    photo.SmallUrl = item.SmallUrl;
                    photo.LargeUrl = item.LargeUrl;
                    photo.Save();
                }
            }
        }

        public string GetImageID()
        {
            return DBHelper.Default.GetSequence("photo_key").ToString();
        }

        [Put]
        [NoDataConvert]
        public void UploadImage(string id, string file, long photoid, bool large, HttpRequest request)
        {
            lock (mImageBuffer)
            {
                Photo photo = DBContext.Load<Photo>(photoid);
                if (photo != null)
                {
                    request.Stream.Read(mImageBuffer, 0, request.Length);
                    if (!large)
                        file = "s_" + file;
                    string fileUrl = SaveImage(file, mImageBuffer, request.Length);

                    PhotoItem item = DBContext.Load<PhotoItem>(id);
                    if (item == null)
                    {
                        item = new PhotoItem();
                        item.ID = id;
                    }
                    item.PhotoID = photo.ID;
                    if (large)
                        item.LargeUrl = fileUrl;
                    else
                        item.SmallUrl = fileUrl;
                    item.Save();
                    if (string.IsNullOrEmpty(photo.LargeUrl) || string.IsNullOrEmpty(photo.SmallUrl))
                    {
                        photo.LargeUrl = item.LargeUrl;
                        photo.SmallUrl = item.SmallUrl;
                        photo.Save();
                    }
                }
            }
        }

        private string SaveImage(string file, byte[] data, int length)
        {
            int code = Math.Abs(file.GetHashCode());
            string subfolder = (code % 10).ToString("00");
            string filename = Units.ImagePath + subfolder
                + System.IO.Path.DirectorySeparatorChar + file;
            using (System.IO.Stream stream = System.IO.File.Create(filename))
            {
                stream.Write(data, 0, length);
                stream.Flush();
            }
            string url = "/images/" + subfolder + "/" + file;
            return url;
        }


        public void DelItem(string[] id)
        {
            (PhotoItem.iD == id).Delete<PhotoItem>();
        }

        public object Get(long id)
        {
            Photo photo = DBContext.Load<Photo>(id);
            var items = (PhotoItem.photoID == id).List<PhotoItem>();
            var Items = from a in items select new { a.ID, a.SmallUrl };
            return new { photo.Title, Items };
        }

        public object List(int index)
        {
            int size = 10;
            Expression expression = new Expression();
            int Count = expression.Count<Photo>();
            int Pages = Count / size;
            if (Count % size > 0)
                Pages++;
            var items = expression.List<Photo>(new Region(index, size), Photo.createTime.Desc);
            var Items = from a in items
                        select new
                        {
                            a.ID,
                            a.Title,
                            CreateTime = a.CreateTime.ToShortDateString(),
                            SmallUrl = Blog.Units.GetImageUrl(a.SmallUrl)
                        };
            return new { Count, Pages, Items };
        }
    }
}
