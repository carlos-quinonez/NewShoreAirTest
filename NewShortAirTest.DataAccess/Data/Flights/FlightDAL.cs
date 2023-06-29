using Azure;
using NewShortAirTest.Shared.Entities;
using NewShortAirTest.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.DataAccess.Data.Flights;

public class FlightDAL : IFlightDAL
{
    private readonly DataContext _context;
    private readonly IRepository _repository;

    public List<Flight>? Flights { get; set; }

    public FlightDAL(DataContext context, IRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<List<Flight>> GetAllAsync(int level)
    {
        var url1 = $"https://recruiting-api.newshore.es/api/flights/{level}";
        var responseHppt = await _repository.Get<List<Flight>>(url1);
        Flights = responseHppt.Response!;
        return Flights;
    }
}