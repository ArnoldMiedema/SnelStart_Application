using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SnelStart_Application
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Customers : ContentPage
	{
		public Customers ()
		{
			InitializeComponent ();
            ObservableCollection<SnelStart_Application.Classes.Customer> Customers = new ObservableCollection<SnelStart_Application.Classes.Customer>();
            Customers.Add(new Classes.Customer { Name = "Stephan Reker", Recent = "Gisteren" });
            Customers.Add(new Classes.Customer { Name = "Coen Reker", Recent = "Vandaag" });
            Customers.Add(new Classes.Customer { Name = "Arnold Reker", Recent = "Morgen" });
            Customers.Add(new Classes.Customer { Name = "Marcel Reker", Recent = "Overmorgen" });
            Customers.Add(new Classes.Customer { Name = "Gert Reker", Recent = "Eregisteren" });
            CustomerView.ItemsSource = Customers;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //CustomerView.BeginRefresh();

            //if (string.IsNullOrWhiteSpace(e.NewTextValue))
            //    CustomerView.ItemsSource = Customers;
            //else
            //    CustomerView.ItemsSource = _Customers.Employees.Where(i => i.Name.Contains(e.NewTextValue));

            //CustomerView.EndRefresh();
        }

    }
}