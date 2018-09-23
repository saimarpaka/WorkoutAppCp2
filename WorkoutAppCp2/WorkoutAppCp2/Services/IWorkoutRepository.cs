using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal interface IWorkoutRepository
    {
        Task<List<Workouts>> GetAllWorkouts();

        Task<Workouts> GetWorkout(int id);

        Task<Workouts> AddWorkout(Workouts workout);

        void UpdateWorkout(Workouts workout);
    }
}