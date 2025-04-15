using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FRS
{
    
    internal class Connection
    {
        private MySqlConnection connection;
        private string connectionString;

        //Constructor

        public Connection()
        {
            //connection String

            connectionString = $"Server = localhost;Database=flight_reservation_system;user ID='root'; password='';";
            connection = new MySqlConnection(connectionString);
        }

        // Open connection to the database
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //Close the connection

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection GetConnection()
        {
            return connection;


        }
    }
}
