using FlightBookingModels;
using System.Collections.Generic;
using System.Linq;

namespace FlightDataService 
{ 
    public class FlightInMemory : IFlightDataService
    {
        public List<FlightModels> bookings = new List<FlightModels>();

        public void Add(FlightModels booking)
        {
            bookings.Add(booking);
        }

        public FlightModels GetbyPassport(string passport)
        {
            return bookings.FirstOrDefault(b => b.PassportNumber == passport);
        }

        public List<FlightModels> GetAll()
        {
            return bookings;
        }

        public void Update(FlightModels booking)
        {
            var existing = GetbyPassport(booking.PassportNumber);

            if (existing != null)
            {
                existing.Name = booking.Name;
                existing.Destination = booking.Destination;
                existing.BaggageKg = booking.BaggageKg;
                existing.TotalCost = booking.TotalCost;
            }
        }

        public void Delete(string passport)
        {
            var booking = GetbyPassport(passport);

            if (booking != null)
            {
                bookings.Remove(booking);
            }
        }
    }
}
