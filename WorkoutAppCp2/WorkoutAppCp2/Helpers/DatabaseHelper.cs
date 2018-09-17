using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;
using Xamarin.Forms;

namespace WorkoutAppCp2.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteAsyncConnection sqliteconnection;
        public const string DbFileName = "WorkoutApp.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTableAsync<Workouts>().Wait();
            sqliteconnection.CreateTableAsync<WorkoutWeeks>().Wait();
            sqliteconnection.CreateTableAsync<WorkoutDays>().Wait();
        }

        public Task<List<Workouts>> GetAllWorkouts()
        {
            return sqliteconnection.Table<Workouts>().OrderBy(t => t.Workout_id).ToListAsync();
        }

        public Task<Workouts> GetWorkout(int id)
        {
            return sqliteconnection.Table<Workouts>().Where(t => t.Workout_id == id).FirstOrDefaultAsync();
        }
        public Task<Workouts> AddWorkout(Workouts workout)
        {
            sqliteconnection.InsertAsync(workout);
            return sqliteconnection.Table<Workouts>().OrderByDescending(t => t.Workout_id).FirstOrDefaultAsync();
        }

        public void UpdateWorkout(Workouts workout)
        {
            sqliteconnection.UpdateAsync(workout);
        }

        public Task<List<WorkoutWeeks>> GetAllWorkoutWeeks()
        {
            return sqliteconnection.Table<WorkoutWeeks>().ToListAsync();
        }
        public Task<WorkoutWeeks> GetWorkoutWeek(int workout_Id)
        {
            return sqliteconnection.Table<WorkoutWeeks>().Where(t => t.Workout_Id == workout_Id).FirstOrDefaultAsync();
        }
        public void AddWorkoutWeek(WorkoutWeeks workoutWeek)
        {
            sqliteconnection.InsertAsync(workoutWeek);
        }

        public void UpdateWorkoutWeek(WorkoutWeeks workoutWeek)
        {
            sqliteconnection.UpdateAsync(workoutWeek);
        }

        public Task<List<WorkoutDays>> GetAllWorkoutDays()
        {
            return sqliteconnection.Table<WorkoutDays>().ToListAsync();
        }
        public Task<WorkoutDays> GetWorkoutDay(int workout_Id, int workout_week_Id, int workout_Day_Id)
        {
            return sqliteconnection.Table<WorkoutDays>().Where(t => t.Workout_Id == workout_Id
                                                                && t.Workout_Week_Id == workout_week_Id
                                                                && t.Workout_Day_Id == workout_Day_Id).FirstOrDefaultAsync();
        }
        public void AddWorkoutDay(WorkoutDays workoutDay)
        {
            sqliteconnection.InsertAsync(workoutDay);
        }

        public void UpdateWorkoutDay(WorkoutDays workoutDay)
        {
            sqliteconnection.UpdateAsync(workoutDay);
        }

    }
}
