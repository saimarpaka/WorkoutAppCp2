using SQLite;
using System;

namespace WorkoutAppCp2.Models
{
    [Table("Workouts")]
    public class Workouts
    {
        [PrimaryKey,AutoIncrement, NotNull,Column("Workout_id")]        
        public int Workout_id { get; set; }

        [Column("Workout_Name")]
        public string Workout_Name { get; set; }       
    }
}
