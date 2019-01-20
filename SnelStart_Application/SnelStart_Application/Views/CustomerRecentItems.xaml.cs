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
            //API BoughtProducts = new API();
            //BoughtProducts.GetBoughtProducts(Token, CustomerInfo.CustomerID);

            List<Product> Products = new List<Product>();
            Products.Add(new Product { Name = "Schoenen", Price = "€ 100,95" });
            Products.Add(new Product { Name = "Vaas", Price = "€ 30,95" });
            Products.Add(new Product { Name = "Jas", Price = "€ 195,00" });
            Products.Add(new Product { Name = "Trui", Price = "€ 59,99" });

            RecentItems.ItemsSource = Products;
        }


	}
}