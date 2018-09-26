using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using WorkoutAppCp2.Views;
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

            AddWorkoutCommand = new Command(async () => await AddWorkout());
            ViewAllWorkoutsCommand = new Command(async () => await ShowWorkoutsList());
        }

        private async Task AddWorkout()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Add Workout", "Do you want to save Workout Details ?", "OK", "Cancel");
            if (isUserAccept)
            {
                Workouts oLastWorkout = _workoutRepository.AddWorkout(_workout).Result;
                await _navigation.PushAsync(new WorkoutsList());
            }
        }

        private async Task ShowWorkoutsList()
        {
            await _navigation.PushAsync(new WorkoutsList());
        }
    }
}