using SQLite;

namespace WorkoutAppCp2.Models
{
    [Table("Exercices")]
    public internal class Exercises
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id")]
        public int Id { get; set; }
        public int Exercise_Id { get; set; }
        public string Exercise_Name { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
        public int Day_Id { get; set; }
    }
}