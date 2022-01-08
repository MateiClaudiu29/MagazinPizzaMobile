using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagazinPizza.Models;

namespace MagazinPizza.Data
{
    public class ComandaDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ComandaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Comanda>().Wait();
            _database.CreateTableAsync<Produse>().Wait();
            _database.CreateTableAsync<ListaProdus>().Wait();
        }
        public Task<List<Comanda>> GetComandaAsync()
        {
            return _database.Table<Comanda>().ToListAsync();
        }
        public Task<Comanda> GetComandaAsync(int id)
        {
            return _database.Table<Comanda>().Where(i => i.ComandaId == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveComandaAsync(Comanda slist)
        {
            if (slist.ComandaId != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteComandaAsync(Comanda slist)
        {
            return _database.DeleteAsync(slist);
        }


        public Task<int> SaveProduseAsync(Produse product)
        {
            if (product.ProdusId != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProduseAsync(Produse product)
        {
            return _database.DeleteAsync(product);
        }

        public Task<List<Produse>> GetProdusesAsync()
        {
            return _database.Table<Produse>().ToListAsync();
        }

        public Task<int> SaveListaProduseAsync(ListaProdus listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }

       
        public Task<List<Produse>> GetListaProduseAsync(int shoplistid)
        {
            return _database.QueryAsync<Produse>(
                "select P.ProdusId, P.NumeProdus from Produse P"
            + " inner join ListaProdus LP"
            + " on P.ProdusId = LP.ProdusId where LP.ComandaId = ?",
            shoplistid);
        }

    }
}
