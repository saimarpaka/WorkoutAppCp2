using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using Xamarin.Forms;

namespace WorkoutAppCp2.ViewModels
{
    internal class WorkoutDetailsViewModel : BaseWorkoutsViewModel
    {
        public ICommand UpdateWorkoutCommand { get; private set; }
        public ICommand DeleteWorkoutCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand AddDayCommand { get; private set; }

        public WorkoutDetailsViewModel(INavigation navigation, int selectedWorkoutId)
        {
            _navigation = navigation;

            _workout = new Workouts
            {
                Workout_id = selectedWorkoutId
            };

            _workoutRepository = new WorkoutRepository();

            _slWeeks = new ObservableCollection<WeeksList>();
            UpdateWorkoutCommand = new Command(async () => await UpdateWorkout());
            DeleteWorkoutCommand = new Command(async () => await DeleteWorkout());
            FetchWorkoutDetails();
        }

        public WorkoutDetailsViewModel()
        {
            _namesList = new ObservableRangeCollection<WeeksList>();
            AddCommand = new Command(() => Add());
            AddDayCommand = new Command<WeeksList>((model) => AddDay(model));
        }

        private void AddDay(WeeksList week)
        {
            week.days.Add(new Days { Day = 4 });               
        }

        //test code
        private void Add()
        {
            ObservableRangeCollection<Days> ds = new ObservableRangeCollection<Days>();
            ds.Add(new Days { Day = 1 });
            ds.Add(new Days { Day = 2 });
            ds.Add(new Days { Day = 3 });
            _namesList.Add(new WeeksList { days = ds });
        }

        public void AddWeek()
        {
            Application.Current.MainPage.DisplayAlert("Workout Details", "Update Workout Details?", "OK", "Cancel");
        }

        private void FetchWorkoutDetails()
        {
            _workout = _workoutRepository.GetWorkout(_workout.Workout_id).Result;
        }

        private async Task UpdateWorkout()
        {
            _workoutDaysRepository = new WorkoutDaysRepository();
            foreach (var item in _slWeeks)
            {
                _workoutDaysRepository.AddWorkoutDay(new WorkoutDays { Day = item.Day, Exercise_Id = item.Exercise_Id, Reps = item.Reps, Sets = item.Sets, Workout_Id = _workout.Workout_id });
            }
            await _navigation.PopAsync();
        }

        private async Task DeleteWorkout()
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