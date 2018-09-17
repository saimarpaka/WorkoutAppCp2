using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutAppCp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsView : ContentView
    {
        public WorkoutsView()
        {
            InitializeComponent();          
        }

        private void lvWeeks_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var last = lvWeeks.ItemsSource.Cast<object>().LastOrDefault();
            lvWeeks.ScrollTo(last, ScrollToPosition.MakeVisible, true);
        }
    }
}