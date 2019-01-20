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
	public partial class CustomerRecentItems : ContentPage
	{
        string Token;
        Customer CustomerInfo;
        public CustomerRecentItems (string Bearertoken, Customer Cust)
		{
			InitializeComponent ();
            Token = Bearertoken;
            CustomerInfo = Cust;
        }


	}
}