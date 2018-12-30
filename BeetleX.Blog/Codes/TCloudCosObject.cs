using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace BeetleX.Blog
{
    public class TCloudCosObject
    {
        public TCloudCosObject(string secretId, string secretKey, string host)
        {

            if (host[host.Length - 1] == '/')
                host = host.Substring(0, host.Length - 1);
            Host = host;
            SecretId = secretId;
            SecretKey = secretKey;
        }

        public static int DefaultConnectionLimit
        {
            get
            {
                return ServicePointManager.DefaultConnectionLimit;
            }
            set
            {
                ServicePointManager.DefaultConnectionLimit = value;
            }
        }

        public string Host { get; set; }

        public string SecretId { get; set; }

        public string SecretKey { get; set; }

        private string GetSignature(string method, string filename)
        {
            method = method.ToLower();
            if (filename.IndexOf("/") != 0)
            {
                filename = "/" + filename;
            }
            var baseDate = new System.DateTime(1970, 1, 1);
            var now = (int)(DateTime.Now.AddDays(-5) - baseDate).TotalSeconds;
            var exp = (int)(DateTime.Now.AddMinutes(2) - baseDate).TotalSeconds;
            string signTime = now + ";" + exp;
            string keyTime = signTime;
            string singKey = HmacSha1Sign(keyTime, SecretKey);
            string httpString = method + "\n" + filename + "\n\n\n";
            string sha1edHttpString = EncryptToSHA1(httpString);
            string stringToSign = $"sha1\n{signTime}\n{sha1edHttpString}\n";
            string signature = HmacSha1Sign(stringToSign, singKey);
            var authorization = $"q-sign-algorithm=sha1&q-ak={SecretId}&q-sign-time={signTime}&q-key-time={signTime}&q-header-list=&q-url-param-list=&q-signature={signature}";
            return authorization;
        }

        public string GetPutToken(string file)
        {
            return GetSignature("put", file);
        }

        public string GetPutUrl(string file)
        {
            if (file[0] != '/')
                file = "/" + file;
            return Host + file;
        }

        private string EncryptToSHA1(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = System.Security.Cryptography.SHA1.Create().ComputeHash(buffer);
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        private string HmacSha1Sign(string EncryptText, string EncryptKey)
        {
            HMACSHA1 myHMACSHA1 = new HMACSHA1(Encoding.Default.GetBytes(EncryptKey));
            byte[] RstRes = myHMACSHA1.ComputeHash(Encoding.Default.GetBytes(EncryptText));
            StringBuilder EnText = new StringBuilder();
            foreach (byte Byte in RstRes)
            {
                EnText.AppendFormat("{0:x2}", Byte);
            }
            return EnText.ToString();
        }

        public bool Put(string file, string localFile)
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead(localFile))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return Put(file, data);
            }
        }

        public bool Put(string file, byte[] data)
        {
            if (file[0] != '/')
                file = "/" + file;
            var sign = GetSignature("put", file);
            string url = Host + file;
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Authorization", sign);
            webClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                Stream postStream = webClient.OpenWrite(url, "PUT");
                postStream.Write(data, 0, data.Length);
                postStream.Close();
            }
            catch (WebException webError)
            {
                string errorText;
                using (System.IO.StreamReader reader = new StreamReader(webError.Response.GetResponseStream()))
                {
                    errorText = reader.ReadToEnd();
                }
                throw new Exception(errorText, webError);
            }
            return true;
        }

        public bool Del(string file)
        {
            if (file[0] != '/')
                file = "/" + file;
            var sign = GetSignature("DELETE", file);
            string url = Host + file;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.Headers.Add("Authorization", sign);
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException webError)
            {
                string errorText;
                using (System.IO.StreamReader reader = new StreamReader(webError.Response.GetResponseStream()))
                {
                    errorText = reader.ReadToEnd();
                }
                throw new Exception(errorText, webError);
            }
            return true;
        }

    }

}
