using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        class SideBarMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SideBarMenuItem> MenuItems { get; set; }
            
            public SideBarMasterViewModel()
            {
                MenuItems = new ObservableCollection<SideBarMenuItem>(new[]
                {
                    new SideBarMenuItem { Id = 0, Title = "Workouts" , TargetType = typeof(WorkoutsList)},
                    new SideBarMenuItem { Id = 1, Title = "Workout Editor", TargetType = typeof(SideBarDetail)}
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}