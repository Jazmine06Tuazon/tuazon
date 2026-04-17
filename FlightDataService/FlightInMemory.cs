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
                existing.Departure = booking.Departure;
                existing.Type = booking.Type;
                existing.BaggageType = booking.BaggageType;
                existing.Contact = booking.Contact;
                existing.Email = booking.Email;
                existing.Date = booking.Date;
                existing.BirthDate = booking.BirthDate;
                existing.Age = booking.Age;
                existing.BaggageKg = booking.BaggageKg;
                existing.TotalCost = booking.TotalCost;
                existing.Gender = booking.Gender;
                existing.Nationality = booking.Nationality;
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
