using NewShortAirTest.DataAccess.Data.Flights;
using NewShortAirTest.Shared.Entities;
using System.Diagnostics.Metrics;

namespace NewShortAirTest.Bussines.Flights;

public class FlightBS : IFlightBS
{
    private readonly IFlightDAL _flightDAL;
    public List<Flight>? Flights { get; set; }
    public FlightBS(IFlightDAL flightDAL)
    {
        _flightDAL = flightDAL;
    }

    public async Task<List<Flight>> GetAllAsync(int level)
    {
        Flights = await _flightDAL.GetAllAsync(level);
        return Flights.ToList();
    }
}
