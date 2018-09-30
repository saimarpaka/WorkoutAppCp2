using SQLite;

namespace WorkoutAppCp2.Models
{
    [Table("Exercises")]
    public class Exercises
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id")]
        public int Id { get; set; }

        [Column("Exercise_Name")]
        public string Exercise_Name { get; set; }

        [Column("Sets")]
        public string Sets { get; set; }

        [Column("Reps")]
        public string Reps { get; set; }

        [Column("Day_Id")]
        public int Day_Id { get; set; }

        [Column("Workout_Id")]
        public int Workout_Id { get; set; }
    }
}