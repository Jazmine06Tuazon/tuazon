using FlightModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataService
{
    public interface IDataService
    {
        void SavePassenger(Models passenger);   
    }
}
