using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class connectdb
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;uid=root;password=root;database=fitnessapp");


        //function to open the connection
        public void openConnection()
        {
            if(connection.State != System.Data.ConnectionState.Open)
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

        //function a function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
