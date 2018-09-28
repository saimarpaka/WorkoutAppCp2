using MvvmHelpers;
using System.Collections.Generic;

namespace WorkoutAppCp2.Models
{
    public class WeeksList
    {
        public int Week { get; set; }
        public ObservableRangeCollection<Days> days { get; set; }

        public string Day { get; set; }
        public string Exercise_Id { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
    }
}