using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkoutAppCp2.Models;

namespace WorkoutAppCp2.Services
{
    interface IWorkoutDaysRepository
    {
        Task<List<WorkoutDays>> GetAllWorkoutDays(int workout_week_Id);

        Task<WorkoutDays> GetWorkoutDay(int workout_Id, int workout_week_Id, int workout_Day_Id);

        Task<WorkoutDays> AddWorkoutDay(WorkoutDays workoutDay);

        void UpdateWorkoutDay(WorkoutDays workoutDay);
       
    }
}
