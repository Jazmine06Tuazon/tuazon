using FlightDataService;
using FlightBookingModels;
using System;
using System.Collections.Generic;

namespace FlightAppService
{
    public class AppService
    {
        DataService _repo = new DataService(new FlightDBData());
        
        private void Validate(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception($"{field} cannot be empty.");
        }

        public void Add(FlightModels booking)
        {

            Validate(booking.PassportNumber, "Passport");
            Validate(booking.Name, "Name");
            Validate(booking.Destination, "Destination");
            Validate(booking.Departure, "Departure");
            Validate(booking.Date, "Travel Dates");
            Validate(booking.Email, "Email");
            Validate(booking.Gender, "Gender");
            Validate(booking.Type, "Flight Type [one-way or round-trip]");

            if (_repo.GetbyPassport(booking.PassportNumber) != null)
                throw new Exception("Booking already exixsts.");

            booking.TotalCost = CalculateBaggage(
            booking.BaggageKg,
            booking.BaggageType
            );

            _repo.Add(booking);
        }

        public FlightModels GetBooking(string passport)
        {
            Validate(passport, "Passport");

            return _repo.GetbyPassport(passport);
        }

        public void Update(FlightModels booking)
        {

            Validate(booking.PassportNumber, "Passport");
            Validate(booking.Name, "Name");
            Validate(booking.Destination, "Destination");
            Validate(booking.Departure, "Departure");
            Validate(booking.Date, "Travel Dates");
            Validate(booking.Email, "Email");
            Validate(booking.Gender, "Gender");
            Validate(booking.Type, "Flight Type [one-way or round-trip]");

            if (_repo.GetbyPassport(booking.PassportNumber) == null)
                throw new Exception("Booking does not exists.");

            booking.TotalCost = CalculateBaggage(
            booking.BaggageKg,
            booking.BaggageType
            );

            _repo.Update(booking);
        }

        public void Delete(string passport)
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