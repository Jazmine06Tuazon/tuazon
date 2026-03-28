using FlightModels;
using System.Reflection;

namespace FlightDataService
{
    public class PassengerData : IDataService
    {
        public List<Models> Passengers { get; private set; } = new List<Models>();

        public void AddPassenger(Models passenger)
        {
            Passengers.Add(passenger);
        }

        public void SavePassenger(Models passenger)
        {
            throw new NotImplementedException();
        }
    }
}

