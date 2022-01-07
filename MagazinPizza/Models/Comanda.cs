using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MagazinPizza.Models
{
    public class Comanda
    {
        [PrimaryKey, AutoIncrement]
        public int ComandaId { get; set; }
        public int ClientComanda { get; set; }
        public int TotalComanda { get; set; }

    }
}
