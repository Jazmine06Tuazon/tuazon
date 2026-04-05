using FlightBookingModels;
using System.Security.Principal;
using System.Text.Json;

namespace FlightDataService
{

    public class FlightJsonData
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
            using (var outputStream = File.OpenWrite(jsonFile))
            {
                    JsonSerializer.Serialize<List<FlightModels>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , flights);
            }
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

                    public FlightModels GetPassport(string passport)
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