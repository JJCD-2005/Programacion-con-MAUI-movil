using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CrudSqliteMAUI
{
    public class LocalDbService
    {
        private SQLiteAsyncConnection _connection;

        private async Task Init()
        {
            if (_connection != null) return;

            // Crea la base de datos en la ruta segura del sistema operativo
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Inventario.db3");
            _connection = new SQLiteAsyncConnection(databasePath);
            await _connection.CreateTableAsync<Product>();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            await Init();
            return await _connection.Table<Product>().ToListAsync();
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            await Init();
            if (product.Id != 0)
                return await _connection.UpdateAsync(product); // Si ya existe, lo actualiza
            else
                return await _connection.InsertAsync(product); // Si es nuevo, lo siembra
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            await Init();
            return await _connection.DeleteAsync(product);
        }
    }
}