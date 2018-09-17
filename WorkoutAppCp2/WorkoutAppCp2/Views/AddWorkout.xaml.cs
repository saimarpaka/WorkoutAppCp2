using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutAppCp2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutAppCp2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddWorkout : ContentPage
	{
		public AddWorkout ()
		{
			InitializeComponent ();
            BindingContext = new AddWorkoutViewModel(Navigation);
		}
	}
}