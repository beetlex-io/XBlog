using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BeetleX.Blog
{
    class Units
    {


        public static string MD5Encrypt(string value)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        public static string ImagePath { get; set; }

        public static string GetImageUrl(string url)
        {
            string[] host = null;
            if (string.IsNullOrEmpty(url))
                url = "/images/small_img.jpg";
            if (!string.IsNullOrEmpty(DBModules.DBHelper.Default.Setting.ImgHost.Value))
            {
                host = DBModules.DBHelper.Default.Setting.ImgHost.Value.Split(';', StringSplitOptions.RemoveEmptyEntries);
            }
            if (host == null || host.Length == 0)
                return url;
            else
            {
                string imghost = "http://" + host[Math.Abs(url.GetHashCode()) % host.Length];
                return imghost + url;
            }
        }
    }
}
