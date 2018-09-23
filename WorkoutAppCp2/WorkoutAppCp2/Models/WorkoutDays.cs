using SQLite;

namespace WorkoutAppCp2.Models
{
    [Table("WorkoutDays")]
    public class WorkoutDays
    {
        public int Id { get; set; }
        public int Workout_Id { get; set; }
        public int Workout_Week_Id { get; set; }
        public string Day { get; set; }
        public string Exercise_Id { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
    }
}