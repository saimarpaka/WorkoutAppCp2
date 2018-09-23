using WorkoutAppCp2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutAppCp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDetails : ContentPage
    {
        public WorkoutDetails(int WorkoutID)
        {
            InitializeComponent();
            this.BindingContext = new WorkoutDetailsViewModel(Navigation, WorkoutID);
        }
    }
}