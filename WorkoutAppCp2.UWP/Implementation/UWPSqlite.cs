using SQLite;
using System;
using System.IO;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.UWP.Implementation;

[assembly: Xamarin.Forms.Dependency(typeof(UWPSqlite))]

namespace WorkoutAppCp2.UWP.Implementation
{
    internal class UWPSqlite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseHelper.DbFileName);
            //File.Delete(path);
            var conn = new SQLiteAsyncConnection(path);

            return conn;
        }
    }
}