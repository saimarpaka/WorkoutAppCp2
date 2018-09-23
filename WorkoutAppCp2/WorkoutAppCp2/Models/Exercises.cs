using SQLite;
using System;

namespace WorkoutAppCp2.Models
{
    [Table("Exercices")]
    internal class Exercises
    {
        public int Exercise_Id { get; set; }
        public String Exercise_Name { get; set; }
    }
}