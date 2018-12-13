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
	public partial class Register : ContentPage
	{
		public Register ()
		{
			InitializeComponent ();
		}

        private async void Register_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Username.Text) && (!string.IsNullOrWhiteSpace(Password1.Text) && !string.IsNullOrWhiteSpace(Password2.Text) && Password1.Text == Password2.Text) )
            {
                //add database
                await Navigation.PushAsync(new Login());
            }
        }
    }
}