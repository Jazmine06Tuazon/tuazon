using FlightModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace FlightDataService
{
    public class JsonData : IDataService
    {
        private PassengerData passenger = new PassengerData();

        private string json;

        public JsonData()
        {
            json = $"{AppDomain.CurrentDomain.BaseDirectory}/PassengerData.json";
            
            PopulateJsonFile();       
        }

        public void SaveFlight(Models newPassenger)
        {
            passenger.SavePassenger(newPassenger);
            SaveData();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();
            
            if (passenger.Passengers.Count == 0)
            {
                passenger.SavePassenger(new Models
                {
                    Name = "Jazmine",
                    Payment = "cash",
                    Total = 0
                });

                SaveData();
            }
        }

        private void SaveData()
        {
            using (var outputStream = File.OpenWrite(json))
            {
                JsonSerializer.Serialize<List<Models>>(
                   new Utf8JsonWriter(outputStream, new JsonWriterOptions
                   { SkipValidation = true, Indented = true })
                   , passenger.Passengers);
            }
        }
        
        private void RetrieveDataFromJsonFile()
        {
            if (!File.Exists(json))
            {
                File.WriteAllText(json, "[]");
            }

            using (var jsonFileReader = File.OpenText(json))
            {
                var data = JsonSerializer.Deserialize<List<Models>>(
            jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (data != null)
                {
                    foreach (var item in data)
                    {
                        passenger.SavePassenger(item);
                    }
                }
            }
        }

        public void SavePassenger(Models passenger)
        {
            SqlData db = new SqlData();
            db.SavePassenger(passenger);
        }
    }
}
