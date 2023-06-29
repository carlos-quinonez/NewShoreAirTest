using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NewShortAirTest.Bussines.Flights;
using NewShortAirTest.Shared.Entities;
using NewShortAirTest.Shared.Inputs;

namespace NewShoreAirTest.API.Controllers;

[ApiController]
[Route("/api/flights")]
public class FlightController : ControllerBase
{
    private readonly IFlightBS _flightBS;
    public List<Flight>? Flights { get; set; }

    public FlightController(IFlightBS flightBS)
    {
        _flightBS = flightBS;
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync(int level)
    {
        Flights = await _flightBS.GetAllAsync(level);
        return Ok(Flights);
    }

    [HttpGet("journey/{level:int}")]
    public async Task<ActionResult> GetJourney(int level, [FromQuery] JourneyInput journeyInput)
    {
        Journey journey = new Journey();
        journey = await _flightBS.GetJourneyAsync(journeyInput, level);
        return Ok(journey);
    }
}
