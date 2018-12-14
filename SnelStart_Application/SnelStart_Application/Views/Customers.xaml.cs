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

        ObservableCollection<SnelStart_Application.Classes.Customer> Klanten = new ObservableCollection<SnelStart_Application.Classes.Customer>();

        public Customers ()
		{
			InitializeComponent ();
            Klanten.Add(new Classes.Customer { Name = "Stephan Reker", Recent = "Gisteren" });
            Klanten.Add(new Classes.Customer { Name = "Coen Reker", Recent = "Vandaag" });
            Klanten.Add(new Classes.Customer { Name = "Arnold Reker", Recent = "Morgen" });
            Klanten.Add(new Classes.Customer { Name = "Marcel Reker", Recent = "Overmorgen" });
            Klanten.Add(new Classes.Customer { Name = "Gert Reker", Recent = "Eregisteren" });
            CustomerView.ItemsSource = Klanten;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            CustomerView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                CustomerView.ItemsSource = Klanten;
            else
                CustomerView.ItemsSource = Klanten.Where(i => i.Name.Contains(e.NewTextValue));

            CustomerView.EndRefresh();
        }

    }
}