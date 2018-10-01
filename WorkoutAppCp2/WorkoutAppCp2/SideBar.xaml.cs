using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutAppCp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideBar : MasterDetailPage
    {
        public SideBar()
        {
            InitializeComponent();
            
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is SideBarMenuItem item))
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
            var nav = new NavigationPage(page);
            nav.BarBackgroundColor = Color.FromHex("#7635EB");
            nav.BarTextColor = Color.White;

            Detail = nav;

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}