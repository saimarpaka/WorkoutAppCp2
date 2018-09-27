using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using Xamarin.Forms;

namespace WorkoutAppCp2.ViewModels
{
    internal class AddWorkoutViewModel : BaseWorkoutsViewModel
    {
        public ICommand AddWorkoutCommand { get; private set; }
        public ICommand ViewAllWorkoutsCommand { get; private set; }

        public AddWorkoutViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _workout = new Workouts();

            _workoutRepository = new WorkoutRepository();
            _slWeeks = new ObservableCollection<WeeksList>();
            AddWorkoutCommand = new Command(async () => await AddWorkout());
            ViewAllWorkoutsCommand = new Command(async () => await ShowWorkoutsList());
        }

        private async Task UpdateWorkout()
        {
            await _navigation.PopAsync();
        }

        private async Task AddWorkout()
        {
            _workoutDaysRepository = new WorkoutDaysRepository();
            Workouts oLastWorkout = _workoutRepository.AddWorkout(_workout).Result;
            foreach (var item in _slWeeks)
            {
                _workoutDaysRepository.AddWorkoutDay(new WorkoutDays { Day = item.Day, Exercise_Id = item.Exercise_Id, Reps = item.Reps, Sets = item.Sets, Workout_Id = oLastWorkout.Workout_id });
            }

            await _navigation.PopAsync();
        }

        private async Task ShowWorkoutsList()
        {
            await _navigation.PopAsync();
        }
    }
}