﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal class WorkoutDaysRepository : IWorkoutDaysRepository
    {
        private DatabaseHelper _databaseHelper;

        public WorkoutDaysRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public Task<List<WorkoutDays>> GetAllWorkoutDays(int workout_week_Id)
        {
            return _databaseHelper.GetAllWorkoutDays(workout_week_Id);
        }

        public Task<WorkoutDays> GetWorkoutDay(int workout_Id, int workout_week_Id, int workout_Day_Id)
        {
            return _databaseHelper.GetWorkoutDay(workout_Id, workout_week_Id, workout_Day_Id);
        }

        public Task<WorkoutDays> AddWorkoutDay(WorkoutDays workoutDay)
        {
            return _databaseHelper.AddWorkoutDay(workoutDay);
        }

        public void UpdateWorkoutDay(WorkoutDays workoutDay)
        {
            _databaseHelper.UpdateWorkoutDay(workoutDay);
        }
    }
}