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
        public StackLayout sl;
        public ScrollView sv;
        public int WeekCounter { get; set; }
        public List<Grid> cardGridList = new List<Grid>();
        public List<Button> cardGridButtonsList = new List<Button>();
        public Dictionary<int, int> cardGridCounters = new Dictionary<int, int>();

        public WorkoutsViewCode()
        {
            WeekCounter = 1;
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

            sl = new StackLayout();
            sl.Spacing = 10;
            sl.Padding = 8;
            sl.Children.Add(card);
            sl.Children.Add(btnAddWeeks);
            sv = new ScrollView
            {
                Content = sl
            };
            sv.VerticalScrollBarVisibility = ScrollBarVisibility.Never;
            Content = sv;
        }

        private void BtnAddWeeks_Clicked(object sender, System.EventArgs e)
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

            cardGrid.Children.Add(new Label { Text = "Exercise 1", FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)) }, 0, 0);
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
            StackLayout cardStackLayout = new StackLayout();
            cardStackLayout.Children.Add(new Label { Text = "Week " + WeekCounter, FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) });
            cardStackLayout.Children.Add(cardGrid);
            cardStackLayout.Children.Add(gridButton);
            sl.Children.Insert(sl.Children.IndexOf(btnAddWeeks), new CardView { Content = cardStackLayout });
            sv.ScrollToAsync(btnAddWeeks, ScrollToPosition.End, false);
            WeekCounter++;
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

            cardGridList[buttonIndex].Children.Add(new Label { Text = "Exercise "+(currentRowCount+1) }, 0, currentRowCount);
        }
    }
}