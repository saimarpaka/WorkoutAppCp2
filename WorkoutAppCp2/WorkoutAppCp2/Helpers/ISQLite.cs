using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutAppCp2.Helpers
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
