using System;
using System.Collections.Generic;
using System.Linq;
using WorkoutAppCp2.Controls;
using WorkoutAppCp2.Models;
using WorkoutAppCp2.ViewModels;
using Xamarin.Forms;

namespace WorkoutAppCp2.Views
{
    public class WorkoutsViewCode : ContentView
    {
        public Grid grid;
        public Label lbl;
        public Entry eWorkoutName;
        public CardView card;
        public Button btnAddWeeks;
        public BindableStackLayout MainStackLayout;
        public ScrollView sv;
        public int WeekCounter { get; set; }
        public List<Grid> listDayCardGrid = new List<Grid>();
        public List<Button> listBtnAddExercise = new List<Button>();
        public Dictionary<int, int> dictCardDayExerciseCounters = new Dictionary<int, int>();
        public Dictionary<Button, int> dictDayCardGridCounter = new Dictionary<Button, int>();
        public List<StackLayout> listWeekCards = new List<StackLayout>();
        public List<Button> listBtnAddDay = new List<Button>();
        public int DayCounter { get; set; }

        public WorkoutsViewCode()
        {
            WeekCounter = 1;
            DayCounter = 1;
            MainStackLayout = new BindableStackLayout
            {
                Spacing = 10,
                Padding = 6
            };

            grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Star }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star }
                }
            };

            lbl = new Label
            {
                Text = "Workout Name",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            eWorkoutName = new Entry
            {
                Placeholder = "Workout Name",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            card = new CardView
            {
                Content = grid,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HasShadow = true
            };

            btnAddWeeks = new Button
            {
                Text = "Add Week",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#5989B5")
            };
            btnAddWeeks.Clicked += BtnAddWeeks_Clicked;

            eWorkoutName.SetBinding(Entry.TextProperty, "Workout_Name");
            grid.Children.Add(lbl, 0, 0);
            grid.Children.Add(eWorkoutName, 1, 0);

            MainStackLayout.Children.Add(card);
            MainStackLayout.Children.Add(btnAddWeeks);

            sv = new ScrollView
            {
                Content = MainStackLayout
            };
            sv.VerticalScrollBarVisibility = ScrollBarVisibility.Never;
            Content = sv;
        }

        private Grid CreateCardGrid(string _weekCounter, string _dayCounter)
        {
            Grid cardGrid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star }
                }
            };
            var vm = BindingContext as WorkoutDetailsViewModel;
            WeeksList wl = new WeeksList { Week = Convert.ToInt32(_weekCounter), Day = _dayCounter };
            vm._slWeeks.Add(wl);

            Entry ExerciseEntry = new Entry { Placeholder = "Exercise 1", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };
            Entry SetsEntry = new Entry { Placeholder = "Sets", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };
            Entry RepsEntry = new Entry { Placeholder = "Reps", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };

            ExerciseEntry.SetBinding(Entry.TextProperty, "SlWeeks[" + vm._slWeeks.IndexOf(wl) + "].Exercise_Id");
            SetsEntry.SetBinding(Entry.TextProperty, "SlWeeks[" + vm._slWeeks.IndexOf(wl) + "].Sets");
            RepsEntry.SetBinding(Entry.TextProperty, "SlWeeks[" + vm._slWeeks.IndexOf(wl) + "].Reps");

            Label weekEntry = new Label { Text = _weekCounter.ToString(), IsVisible = false };
            Label dayEntry = new Label { Text = _dayCounter.ToString(), IsVisible = false };

            cardGrid.Children.Add(ExerciseEntry, 0, 0);
            cardGrid.Children.Add(SetsEntry, 1, 0);
            cardGrid.Children.Add(RepsEntry, 2, 0);

            cardGrid.Children.Add(weekEntry);

            cardGrid.Children.Add(dayEntry);

            return cardGrid;
        }

        private void BtnAddWeeks_Clicked(object sender, System.EventArgs e)
        {
            Grid cardGrid = CreateCardGrid((WeekCounter).ToString(), DayCounter.ToString());
            Button btnAddExercise = new Button
            {
                Text = "Add",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#5989B5"),
                WidthRequest = 50,
                HeightRequest = 30
            };
            btnAddExercise.Clicked += btnAddExercise_Clicked;
            Button btnAddDay = new Button
            {
                Text = "Add Day",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#5989B5"),
                WidthRequest = 50,
                HeightRequest = 30
            };
            btnAddDay.Clicked += btnAddDay_Clicked;
            listBtnAddDay.Add(btnAddDay);
            listBtnAddExercise.Add(btnAddExercise);

            StackLayout NestedCard = new StackLayout();
            NestedCard.Children.Add(new Label { Text = "Day 1", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
            NestedCard.Children.Add(cardGrid);
            NestedCard.Children.Add(btnAddExercise);

            StackLayout cardStackLayout = new StackLayout();
            Label WeekLabel = new Label { Text = "Week " + WeekCounter, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) };

            listDayCardGrid.Add(cardGrid);
            cardStackLayout.Children.Add(WeekLabel);
            cardStackLayout.Children.Add(new CardView { Content = NestedCard, BackgroundColor = Color.FromHex("#f2f4f5"), HasShadow = true });
            listWeekCards.Add(cardStackLayout);
            cardStackLayout.Children.Add(btnAddDay);

            MainStackLayout.Children.Insert(MainStackLayout.Children.IndexOf(btnAddWeeks), new CardView { Content = cardStackLayout });
            //sv.ScrollToAsync(btnAddWeeks, ScrollToPosition.End, false);

            ScrollTo(btnAddWeeks);
            dictDayCardGridCounter.Add(btnAddDay, 1);
            WeekCounter++;
        }

        private void ScrollTo(Button sender)
        {
            sv.FadeTo(1, 200, Easing.CubicIn);
            sv.ScrollToAsync(sender, 0, false);
        }

        private void btnAddDay_Clicked(object sender, System.EventArgs e)
        {
            int buttonIndex = listBtnAddDay.IndexOf((Button)sender);
            StackLayout NestedCard = new StackLayout();
            var tWeekLbl = listWeekCards[buttonIndex].Children.First().GetType();
            Label WeekLabel = null;
            WeekLabel = (Label)listWeekCards[buttonIndex].Children.First();

            Grid cardGrid = CreateCardGrid(WeekLabel.Text[WeekLabel.Text.Length - 1].ToString(), (dictDayCardGridCounter[(Button)sender] + 1).ToString());
            Button btnAddExercise = new Button
            {
                Text = "Add",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#5989B5"),
                WidthRequest = 50,
                HeightRequest = 30
            };
            btnAddExercise.Clicked += btnAddExercise_Clicked;
            listBtnAddExercise.Add(btnAddExercise);
            listDayCardGrid.Add(cardGrid);

            NestedCard.Children.Add(new Label { Text = "Day " + (dictDayCardGridCounter[(Button)sender] + 1), FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
            NestedCard.Children.Add(cardGrid);
            NestedCard.Children.Add(btnAddExercise);
            dictDayCardGridCounter[(Button)sender] += 1;
            listWeekCards[buttonIndex].Children.Insert(listWeekCards[buttonIndex].Children.IndexOf((Button)sender), new CardView { Content = NestedCard, BackgroundColor = Color.FromHex("#f2f4f5"), HasShadow = true });
            ScrollTo((Button)sender);
        }

        private void btnAddExercise_Clicked(object sender, System.EventArgs e)
        {
            int buttonIndex = listBtnAddExercise.IndexOf((Button)sender);
            var WeekOfExerciseCard = listDayCardGrid[buttonIndex].Children[3];
            var week = (Label)WeekOfExerciseCard;
            var gridDay = listDayCardGrid[buttonIndex].Children[4];
            var day = (Label)gridDay;

            int currentRowCount;
            if (dictCardDayExerciseCounters.ContainsKey(buttonIndex))
            {
                currentRowCount = dictCardDayExerciseCounters[buttonIndex] + 1;
                dictCardDayExerciseCounters[buttonIndex] = currentRowCount;
            }
            else
            {
                currentRowCount = 1;
                dictCardDayExerciseCounters.Add(buttonIndex, currentRowCount);
            }

            var vm = BindingContext as WorkoutDetailsViewModel;
            WeeksList wl = new WeeksList { Week = Convert.ToInt32(week.Text), Day = day.Text };
            vm._slWeeks.Add(wl);

            Entry ExerciseEntry = new Entry { Placeholder = "Exercise " + (currentRowCount + 1), FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };
            Entry SetsEntry = new Entry { Placeholder = "Sets ", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };
            Entry RepsEntry = new Entry { Placeholder = "Reps ", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) };

            ExerciseEntry.SetBinding(Entry.TextProperty, "SlWeeks[" + vm._slWeeks.IndexOf(wl) + "].Exercise_Id");
            SetsEntry.SetBinding(Entry.TextProperty, "SlWeeks[" + vm._slWeeks.IndexOf(wl) + "].Sets");
            RepsEntry.SetBinding(Entry.TextProperty, "SlWeeks[" + vm._slWeeks.IndexOf(wl) + "].Reps");

            listDayCardGrid[buttonIndex].Children.Add(ExerciseEntry, 0, currentRowCount);
            listDayCardGrid[buttonIndex].Children.Add(SetsEntry, 1, currentRowCount);
            listDayCardGrid[buttonIndex].Children.Add(RepsEntry, 2, currentRowCount);
        }
    }
}