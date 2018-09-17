using System.Collections.Generic;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    internal interface IWorkoutWeeksRepository
    {
        Task<List<WorkoutWeeks>> GetAllWorkoutWeeks();

        Task<WorkoutWeeks> GetWorkoutWeek(int workout_Id);

        void AddWorkoutWeek(WorkoutWeeks workoutWeek);

        void UpdateWorkoutWeek(WorkoutWeeks workoutWeek);
    }
}