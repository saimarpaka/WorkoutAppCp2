using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.Services;
using Xamarin.Forms;

namespace WorkoutAppCp2.ViewModels
{
    class BaseWorkoutsViewModel : INotifyPropertyChanged
    {
        public WorkoutDays _workoutDays;
        public WorkoutWeeks _workoutWeeks;
        public Workouts _workout;
        public INavigation _navigation;
        public IWorkoutRepository _workoutRepository;
        public IWorkoutWeeksRepository _workoutWeeksrepository;
        public IWorkoutDaysRepository _workoutDaysRepository;

        public ObservableCollection<WeeksList> _slWeeks;

        public ObservableCollection<WeeksList> slWeeks
        {
            get => _slWeeks;
            set
            {
                _slWeeks = value;
                NotifyPropertyChanged("slWeeks");
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

        public int Week
        {
            get => _workoutWeeks.Week;
            set
            {
                _workoutWeeks.Week = value;
                NotifyPropertyChanged("Week");
            }
        }
        public int Day
        {
            get => _workoutWeeks.Day;
            set
            {
                _workoutWeeks.Day = value;
                NotifyPropertyChanged("Day");
            }
        }
        public int Exercise_Id
        {
            get => _workoutDays.Exercise_Id;
            set
            {
                _workoutDays.Exercise_Id = value;
                NotifyPropertyChanged("Exercise_Id");
            }
        }
        public int Sets
        {
            get => _workoutDays.Sets;
            set
            {
                _workoutDays.Sets = value;
                NotifyPropertyChanged("Sets");
            }
        }
        public int Reps
        {
            get => _workoutDays.Reps;
            set
            {
                _workoutDays.Reps = value;
                NotifyPropertyChanged("Reps");
            }
        }

        List<Workouts> _workoutsList;
        public List<Workouts> WorkoutsList
        {
            get => _workoutsList;
            set
            {
                _workoutsList = value;
                NotifyPropertyChanged("WorkoutsList");
            }
        }
        List<WorkoutWeeks> _workoutWeeksList;
        public List<WorkoutWeeks> WorkoutWeeksList
        {
            get => _workoutWeeksList;
            set
            {
                _workoutWeeksList = value;
                NotifyPropertyChanged("WorkoutWeeksList");
            }
        }
        List<WorkoutWeeks> _workoutDaysList;
        public List<WorkoutWeeks> WorkoutDaysList
        {
            get => _workoutDaysList;
            set
            {
                _workoutDaysList = value;
                NotifyPropertyChanged("WorkoutDaysList");
            }
        }
        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
