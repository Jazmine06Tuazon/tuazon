using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataService
{
    public class DBFlight
    {
        private string connectionString =
            Server = localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
