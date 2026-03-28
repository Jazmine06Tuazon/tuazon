using FlightModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace FlightDataService
{
    public class JsonData
    {
        private PassengerData passenger = new PassengerData();

        private string json;

        public JsonData()
        {
            json = $"{AppDomain.CurrentDomain.BaseDirectory}/PassengerData.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (passenger.Passengers.Count == 0)
            {
                passenger.AddPassenger(new Models
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
            File.WriteAllText(json, JsonSerializer.Serialize(passenger.Passengers, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
            /*using (var outputStream = File.OpenWrite(json))
            {
                JsonSerializer.Serialize<List<Models>>(
                   new Utf8JsonWriter(outputStream, new JsonWriterOptions
                   { SkipValidation = true, Indented = true })
                   , passenger.Passengers);
            }*/
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
                        passenger.AddPassenger(item);
                    }
                }
            }
        }

        public void SaveFlight(Models newPassenger)
        {
            passenger.AddPassenger(newPassenger);
            SaveData();
        }

        public List<Models> Flight()
        {
            RetrieveDataFromJsonFile();
            return passenger.Passengers;
        }
    }
}
