using SQLite;
using System.IO;
using WorkoutAppCp2.Droid.Implementation;
using WorkoutAppCp2.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]

namespace WorkoutAppCp2.Droid.Implementation
{
    internal class AndroidSQLite : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            //File.Delete(path);
            var conn = new SQLiteAsyncConnection(path);

            return conn;
        }
    }
}