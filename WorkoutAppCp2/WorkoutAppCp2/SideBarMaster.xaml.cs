using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WorkoutAppCp2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutAppCp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideBarMaster : ContentPage
    {
        public ListView ListView;

        public SideBarMaster()
        {
            InitializeComponent();

            BindingContext = new SideBarMasterViewModel();
            ListView = MenuItemsListView;
        }

        private class SideBarMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SideBarMenuItem> MenuItems { get; set; }

            public SideBarMasterViewModel()
            {
                MenuItems = new ObservableCollection<SideBarMenuItem>(new[]
                {
                    new SideBarMenuItem { Id = 0, Title = "Workouts" , TargetType = typeof(WorkoutsList)}
                });
            }

            #region INotifyPropertyChanged Implementation

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion INotifyPropertyChanged Implementation
        }
    }
}