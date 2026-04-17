using FlightBookingModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FlightDataService
{
    public class FlightDBData : IFlightDataService
    {
        private string connection = "Data Source =localhost\\SQLEXPRESS; Initial Catalog = FlightDB; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public FlightDBData()
        {
             sqlConnection = new SqlConnection(connection);
             AddSeeds();
        }

        public void AddSeeds()
        {
            
                var existing = GetAll();
                if (existing.Count == 0)
                {
                    FlightModels defaultPassenger = new FlightModels
                    {
                        PassportNumber = "12345",
                        Name = "Jazmine",
                    };

                    Add(defaultPassenger);
                }
            }
       
        public void Add(FlightModels flightModels)
        {
            var insertStatement = @"INSERT INTO Flight
    (PassportNumber, Name, Nationality, Departure, Destination, [Date], [Type], Contact, Email, TotalCost, BaggageKg, BaggageType, Age, Gender, BirthDate) 
    VALUES (@PassportNumber, @Name, @Nationality, @Departure, @Destination, @Date, @Type, @Contact, @Email, @TotalCost, @BaggageKg, @BaggageType, @Age, @Gender, @BirthDate)";

            SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection);

            cmd.Parameters.AddWithValue("@PassportNumber", flightModels.PassportNumber);
            cmd.Parameters.AddWithValue("@Name", flightModels.Name);
            cmd.Parameters.AddWithValue("@Nationality", flightModels.Nationality ?? "");
            cmd.Parameters.AddWithValue("@Departure", flightModels.Departure ?? "");
            cmd.Parameters.AddWithValue("@Destination", flightModels.Destination ?? "");
            cmd.Parameters.AddWithValue("@Date", flightModels.Date ?? "");
            cmd.Parameters.AddWithValue("@Type", flightModels.Type ?? "");
            cmd.Parameters.AddWithValue("@Contact", flightModels.Contact ?? "");
            cmd.Parameters.AddWithValue("@Email", flightModels.Email ?? "");
            cmd.Parameters.AddWithValue("@TotalCost", flightModels.TotalCost);
            cmd.Parameters.AddWithValue("@BaggageKg", flightModels.BaggageKg);
            cmd.Parameters.AddWithValue("@BaggageType", flightModels.BaggageType ?? "");
            cmd.Parameters.AddWithValue("@Age", flightModels.Age);
            cmd.Parameters.AddWithValue("@Gender", flightModels.Gender ?? "");
            cmd.Parameters.AddWithValue("@BirthDate", flightModels.BirthDate ?? "");

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(string passport)
        {
            var query = "DELETE FROM Flight WHERE PassportNumber = @PassportNumber";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@PassportNumber", passport);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<FlightModels> GetAll()
        {
            string query = "SELECT * FROM Flight";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            var flights = new List<FlightModels>();

            while (reader.Read())
            {
                flights.Add(new FlightModels()
                {
                    PassportNumber = reader["PassportNumber"].ToString(),
                    Name = reader["Name"].ToString(),
                    Destination = reader["Destination"].ToString(),
                    BaggageKg = Convert.ToInt32(reader["BaggageKg"]),
                    TotalCost = Convert.ToDouble(reader["TotalCost"]),
                    Departure = reader["Departure"].ToString(),
                    Nationality = reader["Nationality"].ToString(),
                    Date = reader["Date"].ToString(),
                    Type = reader["Type"].ToString(),
                    Email = reader["Email"].ToString(),
                    Contact = reader["Contact"].ToString(),
                    BaggageType = reader["BaggageType"].ToString(),
                    Age = reader["Age"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    BirthDate = reader["BirthDate"].ToString()
                });
            }

            sqlConnection.Close();
            return flights;
        }

        public FlightModels? GetbyPassport(string passportNumber)
        {
            string query = "SELECT * FROM Flight WHERE PassportNumber = @PassportNumber";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            FlightModels? flight = null;

            if (reader.Read()) 
            {
                flight = new FlightModels()
                {
                    PassportNumber = reader["PassportNumber"].ToString(),
                    Name = reader["Name"].ToString(),
                    Destination = reader["Destination"].ToString(),
                    BaggageKg = Convert.ToInt32(reader["BaggageKg"]),
                    TotalCost = Convert.ToDouble(reader["TotalCost"]),
                    Departure = reader["Departure"].ToString(),
                    Nationality = reader["Nationality"].ToString(),
                    Date = reader["Date"].ToString(),
                    Type = reader["Type"].ToString(),
                    Email = reader["Email"].ToString(),
                    Contact = reader["Contact"].ToString(),
                    BaggageType = reader["BaggageType"].ToString(),
                    Age = reader["Age"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    BirthDate = reader["BirthDate"].ToString()
                };
            }

            sqlConnection.Close();
            return flight;
        }

        public void Update(FlightModels flightModels)
{
        string query = @"UPDATE Flight SET
                        Name = @Name,
                        Destination = @Destination,
                        Departure = @Departure,
                        BaggageKg = @BaggageKg,
                        TotalCost = @TotalCost,
                        Nationality = @Nationality,
                        [Date] = @Date,
                        [Type] = @Type,
                        Email = @Email,
                        Contact = @Contact,
                        BaggageType = @BaggageType,
                        Age = @Age,
                        Gender = @Gender,
                        BirthDate = @BirthDate
                     WHERE PassportNumber = @PassportNumber";

        SqlCommand cmd = new SqlCommand(query, sqlConnection);

        cmd.Parameters.AddWithValue("@PassportNumber", flightModels.PassportNumber);
        cmd.Parameters.AddWithValue("@Name", flightModels.Name);
        cmd.Parameters.AddWithValue("@Destination", flightModels.Destination);
        cmd.Parameters.AddWithValue("@BaggageKg", flightModels.BaggageKg);
        cmd.Parameters.AddWithValue("@TotalCost", flightModels.TotalCost);
        cmd.Parameters.AddWithValue("@Departure", flightModels.Departure);
        cmd.Parameters.AddWithValue("@Nationality", flightModels.Nationality);
        cmd.Parameters.AddWithValue("@Date", flightModels.Date);
        cmd.Parameters.AddWithValue("@Type", flightModels.Type);
        cmd.Parameters.AddWithValue("@Email", flightModels.Email);
        cmd.Parameters.AddWithValue("@Contact", flightModels.Contact);
        cmd.Parameters.AddWithValue("@BaggageType", flightModels.BaggageType);
        cmd.Parameters.AddWithValue("@Age", flightModels.Age);
        cmd.Parameters.AddWithValue("@Gender", flightModels.Gender);
        cmd.Parameters.AddWithValue("@BirthDate", flightModels.BirthDate);

        sqlConnection.Open();
        cmd.ExecuteNonQuery();
        sqlConnection.Close();
}
    }
}
