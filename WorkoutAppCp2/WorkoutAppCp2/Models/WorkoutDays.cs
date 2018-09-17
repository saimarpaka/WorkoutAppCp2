using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutAppCp2.Models
{
    [Table("WorkoutDays")]
    public class WorkoutDays
    {
        public int Id { get; set; }
        public int Workout_Id { get; set; }
        public int Workout_Week_Id { get; set; }
        public int Workout_Day_Id { get; set; }
        public int Exercise_Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
    }
}
