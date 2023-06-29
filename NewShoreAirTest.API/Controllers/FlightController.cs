using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NewShortAirTest.Bussines.Flights;
using NewShortAirTest.Shared.Entities;

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
}
