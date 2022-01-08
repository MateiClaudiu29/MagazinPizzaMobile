using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MagazinPizza.Models;
namespace MagazinPizza
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaProdus : ContentPage
    {
        Comanda c1;

      
        public PaginaProdus(Comanda comanda)
        {
            InitializeComponent();
            c1 = comanda;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // var product = (Produse)BindingContext;
            Produse product = new Produse();
            product.NumeProdus = nume.Text.ToString();
            product.PretProdus = double.Parse(pret.Text.ToString());
            await App.Database.SaveProduseAsync(product);
            listView.ItemsSource = await App.Database.GetProdusesAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var product = (Produse)listView.SelectedItem;
            await App.Database.DeleteProduseAsync(product);
            listView.ItemsSource = await App.Database.GetProdusesAsync();

           
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProdusesAsync();
        }

        async void OnListViewItemSelected(object sender, EventArgs e)
        {

            Produse p;
            
            if (listView.SelectedItem != null)
            {
                p = listView.SelectedItem as Produse;
                var lp = new ListaProdus()
                {
                    ComandaId = c1.ComandaId,
                    ProdusId = p.ProdusId
                };
                await App.Database.SaveListaProduseAsync(lp);
                p.ListProduse = new List<ListaProdus> { lp };

                await Navigation.PopAsync();
            }
        }

        
        }
}