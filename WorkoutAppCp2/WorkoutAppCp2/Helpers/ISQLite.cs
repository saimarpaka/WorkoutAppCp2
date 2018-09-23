using SQLite;

namespace WorkoutAppCp2.Helpers
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}