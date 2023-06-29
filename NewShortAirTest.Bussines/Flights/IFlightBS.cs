using NewShortAirTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.Bussines.Flights;

public interface IFlightBS
{
    public Task<List<Flight>> GetAllAsync(int level);
}
