using System.Collections.Generic;

namespace WorkoutAppCp2.Models
{
    public class Days
    {
        public int Day { get; set; }
        public List<ExercisesOnDay> exercisesOnDays = new List<ExercisesOnDay>();
    }
}