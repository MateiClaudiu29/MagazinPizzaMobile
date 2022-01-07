using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagazinPizza.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagazinPizza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (Comanda)BindingContext;
            //slist. = DateTime.UtcNow;
           // await App.Database.SaveComandaAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Comanda)BindingContext;
            await App.Database.DeleteComandaAsync(slist);
            await Navigation.PopAsync();
        }

    }
}