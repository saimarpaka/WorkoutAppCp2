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

        public WorkoutsViewCode()
        {
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
                BackgroundColor = Color.FromHex("#5989B5"),
            };
            btnAddWeeks.Clicked += BtnAddWeeks_Clicked;
            btnAddWeeks.SetBinding(Button.CommandProperty, "AddWeekCommand");
            eWorkoutName.SetBinding(Entry.TextProperty, "Workout_Name");
            grid.Children.Add(lbl, 0, 0);
            grid.Children.Add(eWorkoutName, 1, 0);

            sl = new StackLayout();
            sl.Spacing = 10;
            sl.Padding = 10;
            sl.Children.Add(card);
            sl.Children.Add(btnAddWeeks);
            sv = new ScrollView
            {
                Content = sl
            };

            Content = sv;
        }

        private void BtnAddWeeks_Clicked(object sender, System.EventArgs e)
        {
            sl.Children.Insert(sl.Children.IndexOf(btnAddWeeks), new CardView { Content = new Label { Text = "Week1" } });
            sv.ScrollToAsync(btnAddWeeks, ScrollToPosition.End, false);
        }
    }
}