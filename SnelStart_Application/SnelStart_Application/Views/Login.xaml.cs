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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        private async void Onclick_Register(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void Onclick_Login(object sender, EventArgs e)
        {
            //DBCustomers customer = App.Database.GetUserCredAsync(Username.Text, Pass.Text);
            if (Username.Text == "1" && Pass.Text == "1")//tijdelijk test
            {
                await Navigation.PushAsync(new MainMenu());
            }
            else
            {
               await DisplayAlert("Niet ingelogd", "U heeft verkeerde gegevens ingevoerd", "OK");
            }
        }
    }
}