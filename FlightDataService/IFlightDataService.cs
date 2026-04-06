using System;
using System.Collections.Generic;
using System.Text;
using FlightBookingModels;

namespace FlightDataService
{
    public interface IFlightDataService
    { 
        void Add(FlightModels flightModels);
        FlightModels? GetPassport(string passportNumber);
        void Update(FlightModels flightModels);
        void Delete(string passport);
        List<FlightModels> GetAll();
    }
}
