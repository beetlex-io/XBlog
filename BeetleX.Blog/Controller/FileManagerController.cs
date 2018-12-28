using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.FastHttpApi;

namespace BeetleX.Blog.Controller
{
    [Controller(BaseUrl = "/admin/files")]
    [AdminFilter]
    public class FileManager : BeetleX.FastHttpApi.IController
    {

        private string mPath;

        public const string FILE_UPLOAE_MANAGER = "_FILE_UPLOAD_MANAGER";
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folder">当前目录</param>
        /// <param name="name">新建目录名称</param>
        public void CreateFolder(string folder, string name)
        {
            if (string.IsNullOrEmpty(folder))
                folder = System.IO.Path.DirectorySeparatorChar.ToString();
            string newFolder = mPath + folder + name;
            if (!System.IO.Directory.Exists(newFolder))
                System.IO.Directory.CreateDirectory(newFolder);

        }
        /// <summary>
        /// 上传文件信息
        /// </summary>
        /// <param name="folder">当前目录</param>
        /// <param name="info">文件信息</param>
        [Post]
        public void UploadFile(string folder,UploadInfo info, IHttpContext context)
        {
            if (string.IsNullOrEmpty(folder))
                folder = System.IO.Path.DirectorySeparatorChar.ToString();
            UploadManager manager = (UploadManager)context.Session[FILE_UPLOAE_MANAGER];
            if (manager == null)
            {
                manager = new UploadManager();
                context.Session[FILE_UPLOAE_MANAGER] = manager;
            }
            string filename = mPath + folder + info.Name;
            UploadWriter uw = manager.GetWriter(filename);
            uw.Write(info);
            if (info.Eof)
            {
                manager.CloseWriter(filename);
            }
        }
        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="folder">当前目录</param>
        /// <param name="name">删除资源名称</param>
        /// <param name="file">是否文件</param>
        public void DeleteResource(string folder, string name, bool file)
        {
            if (string.IsNullOrEmpty(folder))
                folder = System.IO.Path.DirectorySeparatorChar.ToString();
            string recName = mPath + folder + name;
            if (file)
            {
                System.IO.File.Delete(recName);
            }
            else
            {

                System.IO.Directory.Delete(recName, true);
            }
        }
        /// <summary>
        /// 获取目录资源信息
        /// </summary>
        /// <param name="folder">当前目录</param>
        /// <returns>资源列表</returns>
        public object List(string folder)
        {
            if (string.IsNullOrEmpty(folder))
                folder = System.IO.Path.DirectorySeparatorChar.ToString();
            List<Resource> items = new List<Resource>();
            if (folder != System.IO.Path.DirectorySeparatorChar.ToString())
            {
                items.Add(new Resource { Name = System.IO.Path.DirectorySeparatorChar.ToString() });
            }
            foreach (string item in System.IO.Directory.GetDirectories(mPath + folder))
            {
                Resource rec = new Resource();
                rec.Name = System.IO.Path.GetFileName(item);
                rec.Path = folder + rec.Name + System.IO.Path.DirectorySeparatorChar;
                rec.Url = "/Files" + rec.Path.Replace(System.IO.Path.DirectorySeparatorChar, '/');
                items.Add(rec);
            }
            foreach (string file in System.IO.Directory.GetFiles(mPath + folder))
            {
                Resource rec = new Resource();
                rec.Name = System.IO.Path.GetFileName(file);
                rec.Path = folder + rec.Name;
                rec.Url = "/Files" + rec.Path.Replace(System.IO.Path.DirectorySeparatorChar, '/');
                rec.IsFile = true;
                items.Add(rec);
            }

            return items;
        }

        [NotAction]
        public void Init(BeetleX.FastHttpApi.HttpApiServer server)
        {
            mPath = server.Options.StaticResourcePath;
            if (mPath[mPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                mPath += System.IO.Path.DirectorySeparatorChar;
            mPath += "Files";
            if (!System.IO.Directory.Exists(mPath))
                System.IO.Directory.CreateDirectory(mPath);
            server.HttpDisconnect += (o, e) =>
            {
                UploadManager manager = (UploadManager)e.Session[FILE_UPLOAE_MANAGER];
                if (manager != null)
                {
                    manager.Dispose();
                }
            };
        }

        public class Resource
        {


            public string Name { get; set; }

            public bool IsFile { get; set; }

            public string Path { get; set; }

            public string Url { get; set; }


        }
    }

    public class UploadInfo
    {
        public bool Eof { get; set; }

        public string Data { get; set; }

        public string Name { get; set; }
    }

    public class UploadManager : IDisposable
    {
        private Dictionary<string, UploadWriter> mWriters = new Dictionary<string, UploadWriter>();

        public UploadWriter GetWriter(string name)
        {
            lock (this)
            {
                UploadWriter writer;
                if (!mWriters.TryGetValue(name, out writer))
                {
                    writer = new UploadWriter(name);
                    mWriters[name] = writer;
                }
                return writer;
            }
        }

        public void CloseWriter(string name)
        {
            lock (this)
            {
                UploadWriter writer;
                if (mWriters.TryGetValue(name, out writer))
                {
                    mWriters.Remove(name);
                }
            }
        }

        public void Dispose()
        {
            lock (this)
            {
                foreach (UploadWriter item in mWriters.Values)
                {
                    item.Dispose();
                }
                mWriters.Clear();
            }
        }
    }

    public class UploadWriter : IDisposable
    {
        public UploadWriter(string file)
        {
            mFileStream = System.IO.File.Create(file);
        }
        private System.IO.Stream mFileStream;

        public void Write(UploadInfo data)
        {
            mFileStream.Write(Convert.FromBase64String(data.Data));
            mFileStream.Flush();
            if (data.Eof)
                mFileStream.Close();
        }

        public void Dispose()
        {
            mFileStream.Close();
        }
    }
}
