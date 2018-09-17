using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    class WorkoutDaysRepository : IWorkoutDaysRepository
    {
        DatabaseHelper _databaseHelper;

        public WorkoutDaysRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public Task<List<WorkoutDays>> GetAllWorkoutDays()
        {
           return _databaseHelper.GetAllWorkoutDays();
        }
        public Task<WorkoutDays> GetWorkoutDay(int workout_Id, int workout_week_Id, int workout_Day_Id)
        {
            return _databaseHelper.GetWorkoutDay(workout_Id, workout_week_Id, workout_Day_Id);
        }
        public void AddWorkoutDay(WorkoutDays workoutDay)
        {
            _databaseHelper.AddWorkoutDay(workoutDay);
        }

        public void UpdateWorkoutDay(WorkoutDays workoutDay)
        {
            _databaseHelper.UpdateWorkoutDay(workoutDay);
        }
    }
}
