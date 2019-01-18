using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnelStart_Application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenu : ContentPage
	{
		public MainMenu ()
		{
			InitializeComponent ();
            Classes.API api = new Classes.API();
            api.snelstartAPI();
        }

        private async void Onclick_Customers(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Customers());
        }

        private async void Onclick_Settings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }

        private async void Onclick_Logout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}