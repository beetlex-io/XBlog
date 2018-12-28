using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace BeetleX.Blog.DBModules
{
    public class SqliteDriver : Peanut.DriverTemplate<
SQLiteConnection,
SQLiteCommand,
SQLiteDataAdapter,
SQLiteParameter,
Peanut.SqlitBuilder>
    {
    }
}
