using WorkoutAppCp2.ViewModels;
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
            MessagingCenter.Subscribe<string,string>("Scroll","ScrollTo" ,(sender, arg) =>
            {
               switch(arg)
                {
                    case "AddWeek":
                        ScrollTo(btnAddWeek);
                        break;
                }

            });
        }
        private void ScrollTo(Button sender)
        {
            sv.FadeTo(1, 200, Easing.CubicIn);
            sv.ScrollToAsync(sender, 0, false);
        }
    }
}