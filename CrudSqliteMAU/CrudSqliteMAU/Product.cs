using SQLite;

namespace CrudSqliteMAUI
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}