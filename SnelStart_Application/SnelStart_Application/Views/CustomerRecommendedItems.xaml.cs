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
	public partial class CustomerRecommendedItems : ContentPage
	{
        string Token;
        Customer CustomerInfo;
        public CustomerRecommendedItems (string Bearertoken, Customer Cust)
		{
			InitializeComponent ();
            Token = Bearertoken;
            CustomerInfo = Cust;
            //API BoughtProducts = new API();
            //BoughtProducts.GetRecommendedProducts(Token, CustomerInfo.CustomerID);


            List<Product> Products = new List<Product>();
            Products.Add(new Product { Name = "Nike Schoenen", Price = "€ 100,95" });
            Products.Add(new Product { Name = "Bloemen", Price = "€ 10,95" });
            Products.Add(new Product { Name = "Broek", Price = "€ 80,00" });
            Products.Add(new Product { Name = "Trui", Price = "€ 59,99" });

            RecommendedItem.ItemsSource = Products;
        }
	}
}