using Peanut;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeetleX.Blog.DBModules
{
    public class DBHelper
    {
        private static DBHelper mDefault;

        public long GetSequence(string key)
        {
            lock (this)
            {
                Sequence sequence = (Sequence.key == key).ListFirst<Sequence>();
                if (sequence == null)
                {
                    sequence = new Sequence();
                    sequence.Key = key;
                    sequence.Value = 10000;
                }
                sequence.Value++;
                long result = sequence.Value;
                sequence.Save();
                return result;
            }
        }

        public static DBHelper Default
        {
            get
            {

                if (mDefault == null)
                {
                    lock (typeof(DBHelper))
                    {
                        if (mDefault == null)
                        {
                            DBContext.SetConnectionDriver<SqliteDriver>(DB.DB1);
                            DBContext.SetConnectionString(DB.DB1, "Data Source=beetlex_blog.db;Pooling=true;FailIfMissing=false;");
                            mDefault = new DBHelper();
                            mDefault.Setting = new Setting();
                            mDefault.Setting.Init();
                            mDefault.Setting.Load();
                        }

                    }
                }
                return mDefault;
            }
        }


        public Setting Setting { get; private set; }

    }
}
