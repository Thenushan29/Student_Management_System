using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Student_Management_System.Data
{
    internal class DatabaseManager
    {
        private static string connectionString = "Data Source = unicomtic.db; Version = 3 ;";
        public static SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(connectionString);  
            conn.Open();
            return conn;
           
        }

    }
}
