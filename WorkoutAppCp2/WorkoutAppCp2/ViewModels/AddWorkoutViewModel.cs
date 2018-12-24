using MvvmHelpers;
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
        public ICommand AddCommand { get; private set; }
        public ICommand AddDayCommand { get; private set; }
        public ICommand AddExerciseCommand { get; private set; }

        public AddWorkoutViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _workout = new Workouts();

            _weeksList = new ObservableRangeCollection<WeeksList>();

            AddWorkoutCommand = new Command(async () => await AddWorkout());
            AddCommand = new Command(async () => await Add());
            AddDayCommand = new Command<WeeksList>((model) => AddDay(model));
            AddExerciseCommand = new Command<DaysInWeek>((model) => AddExercise(model));
            bEnableWorkoutEdit = true;
        }

        private void AddExercise(DaysInWeek day)
        {
           day.exercisesOnDays.Add(new ExercisesOnDay());

        }

        private void AddDay(WeeksList week)
        {
           
                if (week.Days.Count is 7)
                {
                    Device.BeginInvokeOnMainThread(() => { Application.Current.MainPage.DisplayAlert("Error", "Only 7 Days in a Week.", "OK"); });

                }
                else
                {
                    ExercisesOnDay exercisesOnDay = new ExercisesOnDay();
                    week.Days.Add(new DaysInWeek { Day = week.Days.Count + 1, exercisesOnDays = new ObservableRangeCollection<ExercisesOnDay> { exercisesOnDay } });
                }
         

        }

        private async Task Add()
        {
            await Task.Run(() =>
            {
                ExercisesOnDay exercisesOnDay = new ExercisesOnDay();
                ObservableRangeCollection<DaysInWeek> ds = new ObservableRangeCollection<DaysInWeek>
            {
                new DaysInWeek { Day = 1, exercisesOnDays = new ObservableRangeCollection<ExercisesOnDay> { exercisesOnDay } }
            };

            Device.BeginInvokeOnMainThread(() => { _weeksList.Add(new WeeksList { Week = _weeksList.Count + 1, Days = ds }); MessagingCenter.Send("Scroll", "ScrollTo", "AddWeek"); });
               
            });
        }

        private async Task AddWorkout()
        {
            if (_workout.Workout_Name is null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please Enter the Workout Name", "OK");
                return;
            }
            else
            {
                _workoutRepository = new WorkoutRepository();
                _workoutDaysRepository = new WorkoutDaysRepository();
                _exerciseRepository = new ExerciseRepository();
                _workoutWeeksrepository = new WorkoutWeeksRepository();

                Workouts oLastWorkout = await _workoutRepository.AddWorkout(_workout);

                foreach (var item in _weeksList)
                {
                    var weekId = await _workoutWeeksrepository.AddWorkoutWeek(new WorkoutWeeks { Week = item.Week, Workout_Id = oLastWorkout.Workout_id });

                    foreach (var item2 in item.Days)
                    {
                        var dayId = await _workoutDaysRepository.AddWorkoutDay(new WorkoutDays { Day = item2.Day.ToString(), Workout_Week_Id = weekId.Id, Workout_Id = oLastWorkout.Workout_id });

                        foreach (var item3 in item2.exercisesOnDays)
                        {
                            await _exerciseRepository.AddExercise(new Exercises { Day_Id = dayId.Id, Exercise_Name = item3.ExerciseId, Sets = item3.Reps, Reps = item3.Reps, Workout_Id = oLastWorkout.Workout_id });
                        }
                    }
                }

                await _navigation.PopAsync();
            }
        }

        private async Task ShowWorkoutsList()
        {
            await _navigation.PopAsync();
        }
    }
}