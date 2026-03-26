using FlightModels;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace FlightDataService
{
    public class SqlDataService : IDataService
    {
        private DbConnection db = new DbConnection();

        public void Add(Models models)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Passengers (Name, Payment, Total) VALUES (@Name, @Payment, @Total)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", models.Name);
                cmd.Parameters.AddWithValue("@Payment", models.Payment);
                cmd.Parameters.AddWithValue("@Total", models.Total);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Models> GetModels()
        {
            List<Models> list = new List<Models>();

            using (var conn = db.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Passengers", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Models
                    {
                        Name = reader["Name"].ToString(),
                        Payment = reader["Payment"].ToString(),
                        Total = (int)reader["Total"]
                    });
                }
            }

            return list;
        }

        public Models GetByName(string name) => null;
        public Models GetByTotal(int total) => null;
        public bool NameExists(string name) => false;
        public void Update(Models models) { }
    }
}