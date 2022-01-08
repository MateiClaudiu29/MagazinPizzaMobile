using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MagazinPizza.Models
{
    public class Produse
    {
        [PrimaryKey, AutoIncrement]  public int ProdusId{ get; set; }
        public string NumeProdus { get; set; }

        public double PretProdus { get; set; }
        [OneToMany]   public List<ListaProdus> ListProduse { get; set; }

    }
}
