using FlightDataService;
using FlightBookingModels;
using System;
using System.Collections.Generic;

namespace FlightAppService
{
    public class AppService
    {
        private FlightJsonData _repo = new FlightJsonData();

        private void Validate(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"{field} cannot be empty.");
        }

        public void CreateBooking(FlightModels booking)
        {
            Validate(booking.PassportNumber, "Passport");
            Validate(booking.Name, "Name");
            Validate(booking.Destination, "Destination");

            if (_repo.Get(booking.PassportNumber) != null)
                throw new Exception("Booking already exists.");

            booking.TotalCost = CalculateBaggage(
            booking.BaggageKg,
            booking.BaggageType
);

            _repo.Add(booking);
        }

        public FlightModels GetBooking(string passport)
        {
            Validate(passport, "Passport");

            return _repo.Get(passport);
        }

        public void UpdateBooking(FlightModels booking)
        {
            booking.TotalCost = CalculateBaggage(
            booking.BaggageKg,
            booking.BaggageType
);

            _repo.Update(booking);
        }

        public void DeleteBooking(string passport)
        {
            _repo.Delete(passport);
        }

        public List<FlightModels> GetAllBookings()
        {
            return _repo.GetAll();
        }

        private double CalculateBaggage(int kg, string type)
        {
            switch (type)
            {
                case "1":
                    return kg * 200;

                case "2":
                    return kg * 300;

                default:
                    throw new Exception("Invalid.");
            }
        }


    }
}