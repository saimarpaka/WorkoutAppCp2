using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using Xamarin.Forms;

namespace WorkoutAppCp2.ViewModels
{
    internal class WorkoutDetailsViewModel : BaseWorkoutsViewModel
    {
        public ICommand DeleteWorkoutCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand AddDayCommand { get; private set; }
        public ICommand AddExerciseCommand { get; private set; }

        public WorkoutDetailsViewModel(INavigation navigation, int selectedWorkoutId)
        {
            _navigation = navigation;

            _workout = new Workouts
            {
                Workout_id = selectedWorkoutId
            };

            _weeksList = new ObservableRangeCollection<WeeksList>();

            DeleteWorkoutCommand = new Command(async () => await DeleteWorkout());
            bEnableWorkoutEdit = false;
            Task.Run(async () => { await FetchWorkoutDetails(); });
        }

        private async Task FetchWorkoutDetails()
        {
            _workoutRepository = new WorkoutRepository();
            _workoutWeeksrepository = new WorkoutWeeksRepository();
            _workoutDaysRepository = new WorkoutDaysRepository();
            _exerciseRepository = new ExerciseRepository();

            _workout = await _workoutRepository.GetWorkout(_workout.Workout_id);
            List<WorkoutWeeks> weeks = await _workoutWeeksrepository.GetAllWorkoutWeeks(_workout.Workout_id);

            foreach (var week in weeks)
            {
                WeeksList addWeek = new WeeksList { Week = week.Week };
                addWeek.Days = new ObservableRangeCollection<DaysInWeek>();
                var daysInWeek = await _workoutDaysRepository.GetAllWorkoutDays(week.Id);
                foreach (var day in daysInWeek)
                {
                    DaysInWeek dayToAdd = new DaysInWeek { Day = Convert.ToInt32(day.Day) };
                    dayToAdd.exercisesOnDays = new ObservableRangeCollection<ExercisesOnDay>();
                    var exercisesInDay = await _exerciseRepository.GetExercises(day.Id);

                    foreach (var exercise in exercisesInDay)
                    {
                        dayToAdd.exercisesOnDays.Add(new ExercisesOnDay { ExerciseId = exercise.Exercise_Name, Reps = exercise.Reps, Sets = exercise.Sets });
                    }
                    addWeek.Days.Add(dayToAdd);
                }

                _weeksList.Add(addWeek);
            }
        }

        private async Task DeleteWorkout()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Confirmation", "Delete Workout?", "OK", "Cancel");
            if (isUserAccept)
            {
                _workoutRepository.DeleteWorkout(_workout.Workout_id);
                await _navigation.PopAsync();
            }
        }
    }
}