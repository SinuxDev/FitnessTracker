using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FitnessTracker
{
    public class connectdb :IDisposable
    {
        private readonly MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;uid=root;password=root;database=fitnessapp");

        //function to open the connection
        public void openConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        //function to close the connection
        public void closeConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        //function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }

        // Implement IDisposable interface
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Dispose method
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                connection?.Dispose();
            }
        }

        //Provide method to get connection string
        public string getConnectionString()
        {
            return connection.ConnectionString;
        }
    }
}
