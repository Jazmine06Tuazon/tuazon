using FlightBookingModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlightDataService
{
    public class DataService
    {
        IFlightDataService _flightDataService;
        public DataService(IFlightDataService flightDataService)
        {
            _flightDataService = flightDataService;
        }

        public void Add(FlightModels flightModels)
        {
            _flightDataService.Add(flightModels);
        }

        public FlightModels? GetPassport(string passport)
        {
            return _flightDataService.GetPassport(passport);
        }

        public void Update(FlightModels flightModels)
        {
            _flightDataService.Update(flightModels);
        }

        public void Delete(string passport)
        {
            _flightDataService.Delete(passport);
        }
        
        public List<FlightModels> GetAll()
        {
            return _flightDataService.GetAll(); 
        }
    }
}
