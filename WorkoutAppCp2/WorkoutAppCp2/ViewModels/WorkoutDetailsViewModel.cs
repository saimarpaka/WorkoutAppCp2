using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using Xamarin.Forms;

namespace WorkoutAppCp2.ViewModels
{
    class WorkoutDetailsViewModel : BaseWorkoutsViewModel
    {
        public ICommand UpdateWorkoutCommand { get; private set; }
        public ICommand DeleteWorkoutCommand { get; private set; }
        

        public WorkoutDetailsViewModel(INavigation navigation, int selectedWorkoutId)
        {
            _navigation = navigation;
            _workout = new Workouts
            {
                Workout_id = selectedWorkoutId
            };
            _workoutWeeks = new WorkoutWeeks
            {
                Workout_Id = selectedWorkoutId
            };
            _workoutWeeksrepository = new WorkoutWeeksRepository();
            _workoutRepository = new WorkoutRepository();
            _slWeeks = new ObservableCollection<View>();
            UpdateWorkoutCommand = new Command(async () => await UpdateWorkout());
            DeleteWorkoutCommand = new Command(async () => await DeleteWorkout());
            

            FetchWorkoutDetails();
        }
        public void AddWeek()
        {               
            Application.Current.MainPage.DisplayAlert("Workout Details", "Update Workout Details?", "OK", "Cancel");
        }
        void FetchWorkoutDetails()
        {
            _workout = _workoutRepository.GetWorkout(_workout.Workout_id).Result;
            _workoutWeeks = _workoutWeeksrepository.GetWorkoutWeek(_workout.Workout_id).Result;
        }
        async Task UpdateWorkout()
        {
            //bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Workout Details", "Update Workout Details?", "OK", "Cancel");
            //if (isUserAccept)
            //{
            //    _workoutRepository.UpdateWorkout(_workout);
            //    await _navigation.PopAsync();
            //}
            _slWeeks.Add(new Label { Text = "hello" });
            await Application.Current.MainPage.DisplayAlert("", "Count : "+_slWeeks.Count, "OK", "Cancel");
        }
        async Task DeleteWorkout()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Workout Details", "Delete Workout Details?", "OK", "Cancel");
            if (isUserAccept)
            {
             //   _workoutRepository.DeleteWorkout(_workout.Workout_id);
                await _navigation.PopAsync();
            }
        }
    }
}

