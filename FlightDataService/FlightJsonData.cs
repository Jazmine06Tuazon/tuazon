using FlightBookingModels;
using System.Text.Json;

namespace FlightDataService
{
    public class FlightJsonData
    {
        private List<FlightModels> flights;
        private string filePath;

        public FlightJsonData()
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flight.json");

            if (!File.Exists(filePath))
            {
                flights = new List<FlightModels>();
                Save(); 
            }
            else
            {
                Load();
            }
        }

        private void Load()
        {
            var json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                flights = new List<FlightModels>();
                return;
            }

            flights = JsonSerializer.Deserialize<List<FlightModels>>(json)
                      ?? new List<FlightModels>();
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(flights, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }


        public void Add(FlightModels f)
        {
            flights.Add(f);
            Save();
        }

        public FlightModels Get(string passport)
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
            existing.Nationality = updated.Nationality;
            existing.Departure = updated.Departure;
            existing.Destination = updated.Destination;
            existing.Date = updated.Date;
            existing.Type = updated.Type;
            existing.Contact = updated.Contact;
            existing.Email = updated.Email;
            existing.BaggageKg = updated.BaggageKg;
            existing.BaggageType = updated.BaggageType;

            Save();
        }

        public void Delete(string passport)
        {
            var item = flights.FirstOrDefault(x => x.PassportNumber == passport);

            if (item != null)
            {
                flights.Remove(item);
                Save();
            }
        }
    }
}