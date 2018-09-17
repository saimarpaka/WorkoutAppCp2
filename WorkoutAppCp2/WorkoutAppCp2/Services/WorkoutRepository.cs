using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    class WorkoutRepository : IWorkoutRepository
    {
        DatabaseHelper _databaseHelper;

        public WorkoutRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public Task<List<Workouts>> GetAllWorkouts()
        {
            return _databaseHelper.GetAllWorkouts();
        }

        public Task<Workouts> GetWorkout(int id)
        {
            return _databaseHelper.GetWorkout(id);
        }

        public Task<Workouts> AddWorkout(Workouts workout)
        {
           return _databaseHelper.AddWorkout(workout);
        }

        public void UpdateWorkout(Workouts workout)
        {
            _databaseHelper.UpdateWorkout(workout);
        }
    }
}
