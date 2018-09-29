using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal interface IWorkoutWeeksRepository
    {
        Task<List<WorkoutWeeks>> GetAllWorkoutWeeks(int workout_Id);

        Task<WorkoutWeeks> GetWorkoutWeek(int workout_Id);

        Task<WorkoutWeeks> AddWorkoutWeek(WorkoutWeeks workoutWeek);

        void UpdateWorkoutWeek(WorkoutWeeks workoutWeek);
    }
}