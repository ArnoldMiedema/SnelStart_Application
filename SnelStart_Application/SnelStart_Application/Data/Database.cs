using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace SnelStart_Application
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DBCustomers>().Wait();
        }

        //public Task<List<DBCustomers>> GetItemsAsync()
        //{
        //    return database.Table<DBCustomers>().ToListAsync();
        //}

        //public Task<List<DBCustomers>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<DBCustomers>("SELECT * FROM [DBCustomers]");
        //}

        public Task<DBCustomers> GetItemAsync(int id)
        {
            return database.Table<DBCustomers>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<DBCustomers> GetUserCredAsync(string userName, string password)//user credentials
        {
            return database.Table<DBCustomers>().Where(i => i.Name == userName && i.Password == password).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DBCustomers item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(DBCustomers item)
        {
            return database.DeleteAsync(item);
        }
    }
}
