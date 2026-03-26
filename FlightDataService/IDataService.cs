using FlightModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightDataService
{
    public interface IDataService
    {
        void Add(Models models);
        Models? GetByName(string Name);
        Models? GetByTotal(int Total);
        bool NameExists(string Name);
        void Update(Models models);
        List<Models> GetModels();
    }
}
