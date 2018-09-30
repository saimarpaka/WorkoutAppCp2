using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal class WorkoutRepository : IWorkoutRepository
    {
        private DatabaseHelper _databaseHelper;

       
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
        public void DeleteWorkout(int Workout_Id)
        {
            _databaseHelper.DeleteWorkout(Workout_Id);
        }
    }
}