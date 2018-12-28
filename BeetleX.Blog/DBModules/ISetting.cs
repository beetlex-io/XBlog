using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Mappings;
namespace BeetleX.Blog.DBModules
{
    [Table]
    public interface IOption
    {
        [ID]
        string Name { get; set; }
        [Column]
        string Value { get; set; }
    }

    public class Setting
    {
        public const string USERNAME = "USERNAME";

        public const string PASSWORD = "PASSWORD";

        public const string BLOG_TITLE = "BLOG_TITLE";

        public const string ES_HOST = "ES_HOST";

        public const string ABOUT = "ABOUT";

        public const string JWTKEY = "JWT_KEY";

        public Option PassWord { get; private set; }

        public Option Title { get; private set; }

        public Option UserName { get; private set; }

        public Option About { get; private set; }

        public Option ElasticSearch { get; private set; }

        public Option JwtKey { get; private set; }

        public void Init()
        {
            Option option;
            if ((Option.name == USERNAME).Count<Option>() == 0)
            {
                option = new Option();
                option.Name = USERNAME;
                option.Value = "admin";
                option.Save();
            }

            if ((Option.name == PASSWORD).Count<Option>() == 0)
            {
                option = new Option();
                option.Name = PASSWORD;
                option.Value = Units.MD5Encrypt("123456");
                option.Save();
            }

            if ((Option.name == BLOG_TITLE).Count<Option>() == 0)
            {
                option = new Option();
                option.Name = BLOG_TITLE;
                option.Value = "BeetleX Blog";
                option.Save();
            }

            if ((Option.name == ES_HOST).Count<Option>() == 0)
            {
                option = new Option();
                option.Name = ES_HOST;
                option.Value = "http://localhost:9200";
                option.Save();
            }

            if ((Option.name == ABOUT).Count<Option>() == 0)
            {
                option = new Option();
                option.Name = ABOUT;
                option.Value = "Copyright © 2018 ikende.com email:henryfan@msn.com| http://github.com/ikende";
                option.Save();
            }
            if ((Option.name == JWTKEY).Count<Option>() == 0)
            {
                byte[] key = new byte[128];
                new Random().NextBytes(key);
                string keyStr = Convert.ToBase64String(key);
                option = new Option();
                option.Name = JWTKEY;
                option.Value = keyStr;
                option.Save();
            }
        }

        public void Load()
        {
            UserName = (Option.name == USERNAME).ListFirst<Option>();
            PassWord = (Option.name == PASSWORD).ListFirst<Option>();
            Title = (Option.name == BLOG_TITLE).ListFirst<Option>();
            ElasticSearch = (Option.name == ES_HOST).ListFirst<Option>();
            About = (Option.name == ABOUT).ListFirst<Option>();
            JwtKey = (Option.name == JWTKEY).ListFirst<Option>();

        }

        public void ReCreateJWT()
        {
            byte[] key = new byte[128];
            new Random().NextBytes(key);
            string keyStr = Convert.ToBase64String(key);
            JwtKey.Value = keyStr;
            JwtKey.Save();
        }

        public void Save()
        {
            UserName.Save();
            PassWord.Save();
            Title.Save();
            ElasticSearch.Save();
            About.Save();
        }
    }
}
