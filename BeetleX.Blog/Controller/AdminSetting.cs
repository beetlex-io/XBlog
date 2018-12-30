using System;
using System.Collections.Generic;
using System.Text;
using BeetleX.Blog.DBModules;
using BeetleX.FastHttpApi;
namespace BeetleX.Blog.Controller
{
    [Controller(BaseUrl = "/admin/setting")]
    [AdminFilter]
    public class AdminSetting : IController
    {
        private BeetleX.FastHttpApi.HttpApiServer mServer;

        public object GetServerInfo()
        {
            if (mServer.ServerCounter != null)
                return mServer.ServerCounter.Next();
            return new object();
        }

        public object GetFileAndTCloudToken(string name)
        {
            string ext = System.IO.Path.GetExtension(name);
            if (string.IsNullOrEmpty(DBHelper.Default.Setting.TCloudID.Value))
            {
                return new ActionResult(500, "没有配置腾讯云SecretId相关信息!");
            }
            string filename = name;//Guid.NewGuid().ToString("N") + ext;
            filename = "/" + (Math.Abs(filename.GetHashCode()) % 10).ToString("00") + "/" + filename;
            TCloudCosObject cloudCosObject = new TCloudCosObject(
                DBHelper.Default.Setting.TCloudID.Value,
                DBHelper.Default.Setting.TCloudKey.Value,
                DBHelper.Default.Setting.TCloudHost.Value
                );
            string Token = cloudCosObject.GetPutToken(filename);
            string Url = cloudCosObject.GetPutUrl(filename);
            return new { Token, Url };
            ;
        }

        public void SaveTCloudInfo(string id, string key, string host)
        {
            DBHelper.Default.Setting.SaveTCould(id, key, host);
        }

        public object GetTCloudInfo()
        {
            return new
            {
                SecretId = DBHelper.Default.Setting.TCloudID.Value,
                SecretKey = DBHelper.Default.Setting.TCloudKey.Value,
                Host = DBHelper.Default.Setting.TCloudHost.Value
            };
        }

        public string ESTest(string word)
        {
            return string.Join(',', ES.ESHelper.Blog.Analyze(word, Elasticsearch.AnalyzerType.ik_smart));
        }

        [SkipFilter(typeof(AdminFilter))]
        public object Signout(HttpResponse response)
        {
            JWTHelper.Default.ClearToken(response);
            return new FastHttpApi.Move302Result("/");
        }


        [SkipFilter(typeof(AdminFilter))]
        public bool Login(string name, string pwd, HttpResponse response)
        {
            if (DBHelper.Default.Setting.UserName.Value == name && DBHelper.Default.Setting.PassWord.Value == pwd)
            {
                string tokey = JWTHelper.Default.CreateToken(name, "admin", 2000);
                JWTHelper.Default.CreateToken(response, name, "admin", 2000);
                return true;
            }
            return false;
        }

        public object ChangePwd(string pwd, string rpwd)
        {
            if (!string.IsNullOrEmpty(pwd) && pwd == rpwd)
            {
                DBHelper.Default.Setting.PassWord.Value = Units.MD5Encrypt(pwd);
                DBHelper.Default.Setting.Save();
                return true;
            }
            else
            {
                return new ActionResult(500, "密码为空或不一致!");
            }
        }
        public void UpdateSetting(string title, string host, string about)
        {
            DBHelper.Default.Setting.Title.Value = title;
            DBHelper.Default.Setting.ElasticSearch.Value = host;
            DBHelper.Default.Setting.About.Value = about;
            DBHelper.Default.Setting.Save();
            ES.ESHelper.Init(DBHelper.Default.Setting.ElasticSearch.Value);
        }

        public void ReCreateIndex()
        {
            ES.ESHelper.ReCreateIndex();
        }


        public void ReCreateJWT()
        {
            DBHelper.Default.Setting.ReCreateJWT();
            JWTHelper.Init();
        }

        public object GetSetting()
        {
            return new
            {
                Title = DBHelper.Default.Setting.Title.Value,
                ESHost = DBHelper.Default.Setting.ElasticSearch.Value,
                About = DBHelper.Default.Setting.About.Value,
                ESStatus = ES.ESHelper.Available,
                ESError = ES.ESHelper.InitError == null ? "" : ES.ESHelper.InitError.Message,
                KEY = DBHelper.Default.Setting.JwtKey.Value
            };
        }

        [Post]
        public void CloseSession(long[] ids, IHttpContext context)
        {
            foreach (long item in ids)
            {
                ISession session = context.Server.BaseServer.GetSession(item);
                if (session != null)
                    session.Dispose();
            }
        }
        public object ListConn(int index, IHttpContext context)
        {
            int size = 15;
            ISession[] sessions = context.Server.BaseServer.GetOnlines();
            int pages = sessions.Length / size;
            if (sessions.Length % size > 0)
                pages++;
            List<object> items = new List<object>();
            for (int i = index * size; i < (index * size + 20) && i < sessions.Length; i++)
            {
                ISession item = sessions[i];
                HttpToken token = (HttpToken)item.Tag;
                items.Add(new
                {
                    item.ID,
                    item.Name,
                    Type = token.WebSocket ? "WebSocket" : "http",
                    CreateTime = DateTime.Now - token.CreateTime,
                    IPAddress = ((System.Net.IPEndPoint)item.RemoteEndPoint).Address.ToString()

                });
            }
            return new { Index = index, Pages = pages, Items = items, context.Server.BaseServer.Count };
        }
        [NotAction]
        public void Init(BeetleX.FastHttpApi.HttpApiServer server)
        {
            mServer = server;
        }
    }
}
