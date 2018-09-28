using MvvmHelpers;

namespace WorkoutAppCp2.Models
{
    public class Days
    {
        public int Day { get; set; }
        public ObservableRangeCollection<ExercisesOnDay> exercisesOnDays { get; set; }
    }
}