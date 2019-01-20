using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SnelStart_Application.Classes;
using SnelStart_Application.Views;

namespace SnelStart_Application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Customers : ContentPage
	{
        string token;
        List<Customer> AllCustomers;
        public Customers ()
		{
			InitializeComponent ();
            API CustomerList = new API();
            string bearertoken = CustomerList.snelstartAPI();
            token = bearertoken;
            AllCustomers = CustomerList.GetCustomers(bearertoken);
            CustomerView.ItemsSource = AllCustomers;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CustomerView.ItemsSource = AllCustomers;
            else
                CustomerView.ItemsSource = AllCustomers.Where(i => i.Name.ToLowerInvariant().Contains(e.NewTextValue.ToLowerInvariant()));

            CustomerView.EndRefresh();
        }

        public async void TappedItemClick(object sender, ItemTappedEventArgs e)
        {
            var content = e.Item as Customer;
            await Navigation.PushAsync(new CustomerItemMenu(token, content));
        }
        

    }
}