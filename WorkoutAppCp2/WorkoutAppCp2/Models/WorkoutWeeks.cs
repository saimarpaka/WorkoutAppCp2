using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutAppCp2.Models
{
    [Table("WorkoutWeeks")]
    public class WorkoutWeeks
    {
        public int Id { get; set; }
        public int Workout_Id { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
    }
}
