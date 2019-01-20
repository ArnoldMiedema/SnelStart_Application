using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SnelStart_Application
{
    public partial class App : Application
    {
        static Database database;

        public App()
        {
            InitializeComponent();

            var navigationPage = new NavigationPage(new Login())
            {
                BarBackgroundColor = UIConfig.MainAppColor
            };

            MainPage = navigationPage;
        }

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TestDBSQLite.db3"));
                }
                return database;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
