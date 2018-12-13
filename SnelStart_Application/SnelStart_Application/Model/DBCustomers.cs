using SQLite;

namespace SnelStart_Application
{
    public class DBCustomers
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Recent { get; set; }
    }
}
