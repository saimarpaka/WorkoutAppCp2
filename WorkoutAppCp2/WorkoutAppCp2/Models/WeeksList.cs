using System.Collections.Generic;

namespace WorkoutAppCp2.Models
{
    internal class WeeksList
    {
        public int Week { get; set; }
        public List<Days> days { get; set; }

        public string Day { get; set; }
        public string Exercise_Id { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
    }
}