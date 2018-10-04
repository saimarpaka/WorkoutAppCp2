using MvvmHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using Xamarin.Forms;

namespace WorkoutAppCp2.ViewModels
{
    internal class BaseWorkoutsViewModel : INotifyPropertyChanged
    {
        public Workouts _workout;
        public INavigation _navigation;
        public IWorkoutRepository _workoutRepository;
        public IWorkoutWeeksRepository _workoutWeeksrepository;
        public IWorkoutDaysRepository _workoutDaysRepository;
        public IExerciseRepository _exerciseRepository;
        public ObservableRangeCollection<WeeksList> _weeksList;

        private bool _bEnableWorkoutEdit;

        public bool bEnableWorkoutEdit
        {
            get { return _bEnableWorkoutEdit; }
            set
            {
                _bEnableWorkoutEdit = value;
                NotifyPropertyChanged("bEnableWorkoutEdit");
            }
        }

        public ObservableRangeCollection<WeeksList> NamesList
        {
            get => _weeksList;
            set
            {
                _weeksList = value;
                NotifyPropertyChanged("NamesList");
            }
        }

        public string Workout_Name
        {
            get => _workout.Workout_Name;
            set
            {
                _workout.Workout_Name = value;
                NotifyPropertyChanged("Workout_Name");
            }
        }

        private ObservableCollection<Workouts> _workoutsList;

        public ObservableCollection<Workouts> WorkoutsList
        {
            get => _workoutsList;
            set
            {
                _workoutsList = value;
                NotifyPropertyChanged("WorkoutsList");
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}