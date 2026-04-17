using FlightBookingModels;
using System.Security.Principal;
using System.Text.Json;

namespace FlightDataService
{

    public class FlightJsonData : IFlightDataService
    {

        private List<FlightModels> flights = new List<FlightModels>();

        private string jsonFile;

        public FlightJsonData()
        {
            jsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}/Flight.json";

            PopulateJson();
        }

        private void PopulateJson()
        {
            RetrieveData();

            if (flights.Count <= 0)
            {
                flights.Add(new FlightModels { PassportNumber = "12345", Name = "Jazmine" });

                SaveData();
            }
        }

        private void SaveData()
        {
            var x = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(flights, x);

            System.IO.File.WriteAllText(jsonFile, json);
        }


        private void RetrieveData()
        {
            using (var jsonFileReader = File.OpenText(jsonFile))
            {
                flights = JsonSerializer.Deserialize<List<FlightModels>>
                (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true })
                .ToList();
            }
        }


        public void Add(FlightModels f)
                    {
                        flights.Add(f);
                        SaveData();
                    }

        public FlightModels GetbyPassport(string passport)
             {
                        return flights.FirstOrDefault(x => x.PassportNumber == passport);
                    }

        public List<FlightModels> GetAll()
                    {
                        return flights;
                    }

         public void Update(FlightModels updated)
                    {
                        var existing = flights.FirstOrDefault(x => x.PassportNumber == updated.PassportNumber);

                        if (existing == null) return;

            existing.Name = updated.Name;
            existing.Destination = updated.Destination;
            existing.Departure = updated.Departure;
            existing.Type = updated.Type;
            existing.BaggageType = updated.BaggageType;
            existing.Contact = updated.Contact;
            existing.Email = updated.Email;
            existing.Date = updated.Date;
            existing.BirthDate = updated.BirthDate;
            existing.Age = updated.Age;
            existing.BaggageKg = updated.BaggageKg;
            existing.TotalCost = updated.TotalCost;
            existing.Gender = updated.Gender;
            existing.Nationality = updated.Nationality;

            SaveData();
                    }

        public void Delete(string passport)
        {
            var item = flights.FirstOrDefault(x => x.PassportNumber == passport);

            if (item != null)
            {
                flights.Remove(item);
                SaveData();
            }
        }

        
    }
}