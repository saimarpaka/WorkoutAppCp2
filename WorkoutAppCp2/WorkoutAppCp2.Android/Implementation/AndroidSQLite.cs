using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using WorkoutAppCp2.Droid.Implementation;
using WorkoutAppCp2.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace WorkoutAppCp2.Droid.Implementation
{
    class AndroidSQLite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            var conn = new SQLiteAsyncConnection(path);

            return conn;
        }
    }
}