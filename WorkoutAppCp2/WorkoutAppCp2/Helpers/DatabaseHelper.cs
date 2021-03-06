﻿using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;
using Xamarin.Forms;

namespace WorkoutAppCp2.Helpers
{
    public class DatabaseHelper
    {
        private static SQLiteAsyncConnection sqliteconnection;
        public const string DbFileName = "WorkoutApp.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTableAsync<Workouts>().Wait();
            sqliteconnection.CreateTableAsync<WorkoutWeeks>().Wait();
            sqliteconnection.CreateTableAsync<WorkoutDays>().Wait();
            sqliteconnection.CreateTableAsync<Exercises>().Wait();
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
        public void DeleteWorkout(int Workout_Id)
        {
            sqliteconnection.DeleteAsync(new Workouts { Workout_id = Workout_Id });
            sqliteconnection.DeleteAsync(new WorkoutWeeks { Workout_Id = Workout_Id });
            sqliteconnection.DeleteAsync(new WorkoutDays { Workout_Id = Workout_Id });
            sqliteconnection.DeleteAsync(new Exercises { Workout_Id = Workout_Id });
        }
        public void UpdateWorkout(Workouts workout)
        {
            sqliteconnection.UpdateAsync(workout);
        }

        public Task<List<WorkoutWeeks>> GetAllWorkoutWeeks(int workout_Id)
        {
            return sqliteconnection.Table<WorkoutWeeks>().Where(t => t.Workout_Id == workout_Id).ToListAsync();
        }

        public Task<WorkoutWeeks> GetWorkoutWeek(int workout_Id)
        {
            return sqliteconnection.Table<WorkoutWeeks>().Where(t => t.Workout_Id == workout_Id).FirstOrDefaultAsync();
        }

        public Task<WorkoutWeeks> AddWorkoutWeek(WorkoutWeeks workoutWeek)
        {
            sqliteconnection.InsertAsync(workoutWeek);
            return sqliteconnection.Table<WorkoutWeeks>().OrderByDescending(t => t.Id).FirstOrDefaultAsync();
        }

        public void UpdateWorkoutWeek(WorkoutWeeks workoutWeek)
        {
            sqliteconnection.UpdateAsync(workoutWeek);
        }

        public Task<List<WorkoutDays>> GetAllWorkoutDays(int workout_week_Id)
        {
            return sqliteconnection.Table<WorkoutDays>().Where(t=>t.Workout_Week_Id == workout_week_Id).ToListAsync();
        }

        public Task<WorkoutDays> GetWorkoutDay(int workout_Id, int workout_week_Id, int workout_Day_Id)
        {
            return sqliteconnection.Table<WorkoutDays>().Where(t => t.Workout_Id == workout_Id
                                                                && t.Workout_Week_Id == workout_week_Id
                                                                && t.Id == workout_Day_Id).FirstOrDefaultAsync();
        }

        public Task<WorkoutDays> AddWorkoutDay(WorkoutDays workoutDay)
        {
            sqliteconnection.InsertAsync(workoutDay);
            return sqliteconnection.Table<WorkoutDays>().OrderByDescending(t => t.Id).FirstOrDefaultAsync();
        }

        public void UpdateWorkoutDay(WorkoutDays workoutDay)
        {
            sqliteconnection.UpdateAsync(workoutDay);
        }
        public Task<Exercises> AddExercise(Exercises exercise)
        {
            sqliteconnection.InsertAsync(exercise);
            return sqliteconnection.Table<Exercises>().OrderByDescending(t => t.Id).FirstOrDefaultAsync();
        }
        public Task<List<Exercises>> GetExercises(int dayId)
        {
            return sqliteconnection.Table<Exercises>().Where(t => t.Day_Id == dayId).ToListAsync();
        }
    }
}