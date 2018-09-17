using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.ViewModels;
using WorkoutAppCp2.Views;
using Xamarin.Forms;

namespace WorkoutAppCp2.Services
{
    class WorkoutsListViewModel : BaseWorkoutsViewModel
    {
        public ICommand AddNewWorkoutCommand { get; private set; }
        public ICommand DeleteAllWorkoutsCommand { get; private set; }

        public WorkoutsListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _workoutRepository = new WorkoutRepository();
            AddNewWorkoutCommand = new Command(async () => await ShowAddWorkout());
            DeleteAllWorkoutsCommand = new Command(async () => await DeleteAllWorkouts());
            FetchWorkouts();
        }
        void FetchWorkouts()
        {
            WorkoutsList = _workoutRepository.GetAllWorkouts().Result;
        }
        async Task ShowAddWorkout()
        {
            await _navigation.PushAsync(new AddWorkout());
        }
        async Task DeleteAllWorkouts()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Workouts List", "Delete All Workouts ?", "OK", "Cancel");

            if (isUserAccept)
            {
                await _navigation.PushAsync(new AddWorkout());
            }

        }

        Workouts _SelectedWorkout;
        public Workouts SelectedWorkout
        {
            get { return _SelectedWorkout; }
            set
            {
                if (value != null)
                {
                    _SelectedWorkout = value;
                    NotifyPropertyChanged("SelectedWorkout");
                    ShowWorkoutDetails(value.Workout_id);
                }
            }
        }

        async void ShowWorkoutDetails(int Workout_id)
        {
            await _navigation.PushAsync(new WorkoutDetails(Workout_id));
        }

    }
}
