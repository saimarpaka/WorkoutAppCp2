using WorkoutAppCp2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutAppCp2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsView : ContentPage
    {
        public WorkoutsView()
        {
            InitializeComponent();
            BindingContext = new WorkoutDetailsViewModel();
            MessagingCenter.Subscribe<Button,string>("Scroll","ScrollTo" ,(sender, arg) =>
            {
                sv.FadeTo(1, 200, Easing.CubicIn);
                sv.ScrollToAsync(sender, 0, false);
            });
        }
    }
}