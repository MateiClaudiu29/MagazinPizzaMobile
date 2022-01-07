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
        }
        public Task<List<Comanda>> GetComandaAsync()
        {
            return _database.Table<Comanda>().ToListAsync();
        }
        public Task<Comanda> GetComandaAsync(int id)
        {
            return _database.Table<Comanda>()
            .Where(i => i.ComandaId == id)
           .FirstOrDefaultAsync();
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
    }
}
