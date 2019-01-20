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
        }

        private async void Onclick_Customers(object sender, EventArgs e)
        {
            if (IsBusy)return;
            IsBusy = true;

            await Navigation.PushAsync(new Customers());
            IsBusy = false;
        }

        //private async void Onclick_Settings(object sender, EventArgs e)
        //{
        //    if (IsBusy) return;
        //    IsBusy = true;
        //    await Navigation.PushAsync(new Settings());
        //    IsBusy = false;
        //}

        private async void Onclick_Logout(object sender, EventArgs e)
        {
            if (IsBusy) return;
            IsBusy = true;
            await Navigation.PushAsync(new Login());
            IsBusy = false;
        }
    }
}