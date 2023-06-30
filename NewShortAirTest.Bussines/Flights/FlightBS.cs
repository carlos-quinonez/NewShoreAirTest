using AutoMapper;
using NewShortAirTest.DataAccess.Data.Flights;
using NewShortAirTest.Shared.Entities;
using NewShortAirTest.Shared.Inputs;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace NewShortAirTest.Bussines.Flights;

public class FlightBS : IFlightBS
{
    private readonly IFlightDAL _flightDAL;
    private readonly IMapper _mapper;
    public List<Flight>? Flights { get; set; }
    public FlightBS(IFlightDAL flightDAL, IMapper mapper)
    {
        _flightDAL = flightDAL;
        _mapper = mapper;
    }

    public async Task<List<Flight>> GetAllAsync(int level)
    {
        Flights = await _flightDAL.GetAllAsync(level);
        return Flights.ToList();
    }

    public async Task<Journey> GetJourneyAsync(JourneyInput journeyInput, int level,int numberMaxFlight)
    {
        List<Flight> flightsResult;
        Journey journey = new Journey();        
        Flights = await _flightDAL.GetAllAsync(level);

        flightsResult = Shared.Utils.Route.CalculateRoute(journeyInput.Origin, journeyInput.Destination, Flights);

        if (flightsResult != null)
        {
            //FlightOutput _definition = _mapper.Map<Definition>(_definitionapi);
            //var list = _mapper.Map<IEnumerable<Flight>>(flightsResult);
            if (numberMaxFlight > 0 && flightsResult.Count() > numberMaxFlight)
            {
                journey.Flights = null;
                journey.Price = 0;
            }
            else
            {
                decimal totalCost = flightsResult.Sum(r => r.Price);
                journey.Price = totalCost;
                journey.Flights = flightsResult.ToList();
            }
        }
        else
        {
            journey.Flights = null;
            journey.Price = 0;
        }
        journey.Origin = journeyInput.Origin;
        journey.Destination = journeyInput.Destination; 

        return journey;
    }
}
