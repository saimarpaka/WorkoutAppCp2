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
        public ICommand ViewAllWorkoutsCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand AddDayCommand { get; private set; }
        public ICommand AddExerciseCommand { get; private set; }

        public AddWorkoutViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _workout = new Workouts();

            _workoutRepository = new WorkoutRepository();
            _weeksList = new ObservableRangeCollection<WeeksList>();

            AddWorkoutCommand = new Command(async () => await AddWorkout());
            ViewAllWorkoutsCommand = new Command(async () => await ShowWorkoutsList());
            AddCommand = new Command(() => Add());
            AddDayCommand = new Command<WeeksList>((model) => AddDay(model));
            AddExerciseCommand = new Command<Days>((model) => AddExercise(model));
            bEnableWorkoutEdit = true;
        }

        private void AddExercise(Days day)
        {
            day.exercisesOnDays.Add(new ExercisesOnDay());
        }

        private void AddDay(WeeksList week)
        {
            ExercisesOnDay exercisesOnDay = new ExercisesOnDay();
            week.days.Add(new Days { Day = week.days.Count + 1, exercisesOnDays = new ObservableRangeCollection<ExercisesOnDay> { exercisesOnDay } });
        }

        private void Add()
        {
            ExercisesOnDay exercisesOnDay = new ExercisesOnDay();
            ObservableRangeCollection<Days> ds = new ObservableRangeCollection<Days>
            {
                new Days { Day = 1, exercisesOnDays = new ObservableRangeCollection<ExercisesOnDay> { exercisesOnDay } }
            };
            _weeksList.Add(new WeeksList { Week = _weeksList.Count + 1, days = ds });
            MessagingCenter.Send("Scroll", "ScrollTo", "AddWeek");
        }

        private async Task UpdateWorkout()
        {
            await _navigation.PopAsync();
        }

        private async Task AddWorkout()
        {
            _workoutDaysRepository = new WorkoutDaysRepository();
            _exerciseRepository = new ExerciseRepository();
            _workoutWeeksrepository = new WorkoutWeeksRepository();

            Workouts oLastWorkout = _workoutRepository.AddWorkout(_workout).Result;

            foreach (var item in _weeksList)
            {
                var weekId = _workoutWeeksrepository.AddWorkoutWeek(new WorkoutWeeks { Week = item.Week, Workout_Id = oLastWorkout.Workout_id }).Result;

                foreach (var item2 in item.days)
                {
                    var dayId = _workoutDaysRepository.AddWorkoutDay(new WorkoutDays { Day = item2.Day.ToString(), Workout_Week_Id = weekId.Id }).Result;

                    foreach (var item3 in item2.exercisesOnDays)
                    {
                        await _exerciseRepository.AddExercise(new Exercises { Day_Id = dayId.Id, Exercise_Name = item3.ExerciseId, Sets = item3.Reps, Reps = item3.Reps });
                    }
                }
            }

            await _navigation.PopAsync();
        }

        private async Task ShowWorkoutsList()
        {
            await _navigation.PopAsync();
        }
    }
}