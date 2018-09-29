using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal interface IExerciseRepository
    {
        Task<List<Exercises>> GetExercises(int dayId);
        Task<Exercises> AddExercise(Exercises exercise);
    }
}