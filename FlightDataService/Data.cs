
using FlightAppService;
using FlightModels;
using System.Reflection;

namespace FlightDataService
{
    public class PassengerData
    {
        public List<Models> Passengers { get; private set; } = new List<Models>();

        public void AddPassenger(Models passenger)
        {
            Passengers.Add(passenger);
        }
    }
}

