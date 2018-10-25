using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace WorkoutAppCp2
{
    public partial class App : Application
    {
        public App()
        {
            LiveReload.Init();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzE1NjlAMzEzNjJlMzMyZTMwWE15US8vbUFqZ3dNWVlxMGxXNFd4WEIrSHhzNWxHdUFHa3MwbE5zNUtRaz0=");
            InitializeComponent();

            MainPage = new SideBar();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}