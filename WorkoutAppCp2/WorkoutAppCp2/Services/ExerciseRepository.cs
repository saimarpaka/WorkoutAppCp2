using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutAppCp2.Helpers;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal class ExerciseRepository : IExerciseRepository
    {
        private DatabaseHelper _databaseHelper;
        public ExerciseRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        
        public Task<List<Exercises>> GetExercises(int dayId)
        {
            return _databaseHelper.GetExercises(dayId);
        }
        public Task<Exercises> AddExercise(Exercises exercise)
        {
            return _databaseHelper.AddExercise(exercise);
        }
    }
}
