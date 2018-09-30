using SQLite;
using System.IO;
using WorkoutAppCp2.Helpers;

namespace WorkoutAppCp2.iOS.Implementation
{
    internal class IOSSQLite : ISQLite
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