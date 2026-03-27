using FlightModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace FlightDataService
{
    public class SqlData : IDataService
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS\\SQLEXPRESS; Initial Catalog = Passenger; Integrated Security = True; TrustServerCertificate=True;";

      
        public void SavePassenger(Models passenger)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Passengers
                                (Name, Passport, Departure, Destination, Dates, Flight, Payment, Total)
                                VALUES
                                (@Name, @Passport, @Departure, @Destination, @Dates, @Flight, @Payment, @Total)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", passenger.Name);
                cmd.Parameters.AddWithValue("@Passport", passenger.Passport);
                cmd.Parameters.AddWithValue("@Departure", passenger.Departure);
                cmd.Parameters.AddWithValue("@Destination", passenger.Destination);
                cmd.Parameters.AddWithValue("@Dates", passenger.Dates);
                cmd.Parameters.AddWithValue("@Flight", passenger.Flight);
                cmd.Parameters.AddWithValue("@Payment", passenger.Payment);
                cmd.Parameters.AddWithValue("@Total", passenger.Total);
                cmd.Parameters.AddWithValue("@Nationality", passenger.Nationality);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
