using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;
using SQLitePCL;
using System.IO;
using Xamarin.Forms;
using Assignment;

[assembly: Dependency(typeof(SQliteDroid))]
namespace Assignment
{
    public class SQliteDroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "Mydatabase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;

        }
    }
}