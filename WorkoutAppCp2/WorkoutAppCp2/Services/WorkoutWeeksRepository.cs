using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal class WorkoutWeeksRepository : IWorkoutWeeksRepository
    {
        private DatabaseHelper _databaseHelper;

        public WorkoutWeeksRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public Task<List<WorkoutWeeks>> GetAllWorkoutWeeks()
        {
            return _databaseHelper.GetAllWorkoutWeeks();
        }

        public Task<WorkoutWeeks> GetWorkoutWeek(int workout_Id)
        {
            return _databaseHelper.GetWorkoutWeek(workout_Id);
        }

        public void AddWorkoutWeek(WorkoutWeeks workoutWeek)
        {
            _databaseHelper.AddWorkoutWeek(workoutWeek);
        }

        public void UpdateWorkoutWeek(WorkoutWeeks workoutWeek)
        {
            _databaseHelper.UpdateWorkoutWeek(workoutWeek);
        }
    }
}