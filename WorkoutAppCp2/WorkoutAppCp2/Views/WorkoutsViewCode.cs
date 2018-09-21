using System.Collections.Generic;
using System.Windows.Input;
using WorkoutAppCp2.Controls;
using Xamarin.Forms;

namespace WorkoutAppCp2.Views
{
    public class WorkoutsViewCode : ContentView
    {
        public ICommand AddWeekCommand { get; private set; }
        public Grid grid;
        public Label lbl;
        public Entry eWorkoutName;
        public CardView card;
        public Button btnAddWeeks;
        public BindableStackLayout MainStackLayout;
        public ScrollView sv;
        public int WeekCounter { get; set; }
        public List<Grid> cardGridList = new List<Grid>();
        public List<Button> cardGridButtonsList = new List<Button>();
        public Dictionary<int, int> cardGridCounters = new Dictionary<int, int>();
        public Dictionary<Button, int> cardGridDayCounters = new Dictionary<Button, int>();
        public List<StackLayout> cardStackLayoutList = new List<StackLayout>();
        public List<Button> nestedGridDaysButtonList = new List<Button>();
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
            MainStackLayout.SetBinding(BindableStackLayout.ItemsProperty, "slWeeks", BindingMode.TwoWay);
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
            btnAddWeeks.SetBinding(Button.CommandProperty, "AddWeekCommand");
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

        private Grid CreateCardGrid()
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

            cardGrid.Children.Add(new Entry { Placeholder = "Exercise 1", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 0, 0);
            cardGrid.Children.Add(new Entry { Placeholder = "Sets", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 1, 0);
            cardGrid.Children.Add(new Entry { Placeholder = "Reps", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 2, 0);

            return cardGrid;
        }

        private void BtnAddWeeks_Clicked(object sender, System.EventArgs e)
        {
            Grid cardGrid = CreateCardGrid();
            Button gridButton = new Button
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
            gridButton.Clicked += GridButton_Clicked;
            Button gridDays = new Button
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
            gridDays.Clicked += GridDays_Clicked;
            nestedGridDaysButtonList.Add(gridDays);
            cardGridButtonsList.Add(gridButton);
            cardGridList.Add(cardGrid);

            StackLayout NestedCard = new StackLayout();
            NestedCard.Children.Add(new Label { Text = "Day 1", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
            NestedCard.Children.Add(cardGrid);
            NestedCard.Children.Add(gridButton);

            StackLayout cardStackLayout = new StackLayout();
            cardStackLayout.Children.Add(new Label { Text = "Week " + WeekCounter, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
            cardStackLayout.Children.Add(new CardView { Content = NestedCard, BackgroundColor = Color.FromHex("#f2f4f5"), HasShadow = true });
            cardStackLayoutList.Add(cardStackLayout);
            cardStackLayout.Children.Add(gridDays);

            MainStackLayout.Children.Insert(MainStackLayout.Children.IndexOf(btnAddWeeks), new CardView { Content = cardStackLayout });
            sv.ScrollToAsync(btnAddWeeks, ScrollToPosition.End, false);
            cardGridDayCounters.Add(gridDays, 1);
            WeekCounter++;
        }

        private void GridDays_Clicked(object sender, System.EventArgs e)
        {
            int buttonIndex = nestedGridDaysButtonList.IndexOf((Button)sender);
            StackLayout NestedCard = new StackLayout();
            Grid cardGrid = CreateCardGrid();
            Button gridButton = new Button
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
            gridButton.Clicked += GridButton_Clicked;
            cardGridButtonsList.Add(gridButton);
            cardGridList.Add(cardGrid);

            NestedCard.Children.Add(new Label { Text = "Day " + (cardGridDayCounters[(Button)sender] + 1), FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
            NestedCard.Children.Add(cardGrid);
            NestedCard.Children.Add(gridButton);
            cardGridDayCounters[(Button)sender] += 1;
            cardStackLayoutList[buttonIndex].Children.Insert(cardStackLayoutList[buttonIndex].Children.IndexOf((Button)sender), new CardView { Content = NestedCard, BackgroundColor = Color.FromHex("#f2f4f5"), HasShadow = true });
            sv.ScrollToAsync((Button)sender, ScrollToPosition.End, false);
        }

        private void GridButton_Clicked(object sender, System.EventArgs e)
        {
            int buttonIndex = cardGridButtonsList.IndexOf((Button)sender);

            int currentRowCount;
            if (cardGridCounters.ContainsKey(buttonIndex))
            {
                currentRowCount = cardGridCounters[buttonIndex] + 1;
                cardGridCounters[buttonIndex] = currentRowCount;
            }
            else
            {
                currentRowCount = 1;
                cardGridCounters.Add(buttonIndex, currentRowCount);
            }
            CardView c = new CardView();

            cardGridList[buttonIndex].Children.Add(new Entry { Placeholder = "Exercise " + (currentRowCount + 1), FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 0, currentRowCount);
            cardGridList[buttonIndex].Children.Add(new Entry { Placeholder = "Sets ", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 1, currentRowCount);
            cardGridList[buttonIndex].Children.Add(new Entry { Placeholder = "Reps ", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 2, currentRowCount);
        }
    }
}