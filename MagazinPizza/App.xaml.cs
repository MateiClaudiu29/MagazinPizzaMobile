using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using MagazinPizza.Data;

namespace MagazinPizza
{
    public partial class App : Application
    {
        static ComandaDatabase database;

        public static ComandaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ComandaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Comanda.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
