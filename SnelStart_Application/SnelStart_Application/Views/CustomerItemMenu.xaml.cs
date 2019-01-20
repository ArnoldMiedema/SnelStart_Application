using SnelStart_Application.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnelStart_Application.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomerItemMenu : ContentPage
	{
        string Token;
        Customer CustomerInfo; 
		public CustomerItemMenu (string Bearertoken, Customer Cust)
		{
			InitializeComponent ();
            Token = Bearertoken;
            CustomerInfo = Cust;
        }

        private async void Onclick_RecentItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerRecentItems(Token, CustomerInfo));
        }

        private async void Onclick_RecommendedItems(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomerRecommendedItems(Token, CustomerInfo));
        }
    }
}