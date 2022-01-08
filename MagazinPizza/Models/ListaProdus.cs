using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MagazinPizza.Models
{
    public class ListaProdus
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [ForeignKey(typeof(Comanda))] public int ComandaId { get; set; }
        public int ProdusId { get; set; }
    }
}
