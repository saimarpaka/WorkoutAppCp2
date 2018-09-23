using SQLite;

namespace WorkoutAppCp2.Models
{
    [Table("WorkoutWeeks")]
    public class WorkoutWeeks
    {
        [PrimaryKey, AutoIncrement, NotNull, Column("Id")]
        public int Id { get; set; }

        public int Workout_Id { get; set; }
        public int Week { get; set; }
        public int Day { get; set; }
    }
}