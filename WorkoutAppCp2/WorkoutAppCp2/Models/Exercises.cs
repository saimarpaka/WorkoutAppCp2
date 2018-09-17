using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutAppCp2.Models
{
    [Table("Exercices")]
    class Exercises
    {
        public int Exercise_Id { get; set; }
        public String Exercise_Name { get; set; }
    }
}
