using NewShortAirTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.DataAccess.Data;

public class SeedDb
{
    private DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync(); // Crea la BD
        await CheckTransportsAsync();
    }

    private async Task CheckTransportsAsync()
    {
        if (!_context.Transport.Any())
        {
            _context.Transport.Add(new Transport { FlightCarrier = "AVIANCA", FlightNumber = "A001" });
            _context.Transport.Add(new Transport { FlightCarrier = "EASY FLY", FlightNumber = "E002" });
            _context.Transport.Add(new Transport { FlightCarrier = "CONTINENTAL", FlightNumber = "C003" });
            await _context.SaveChangesAsync();
        }

        if (!_context.Flight.Any())
        {
            _context.Flight.Add(new Flight { Origin = "COL", Destination = "UND", Price = 100 });
            _context.Flight.Add(new Flight { Origin = "UND", Destination = "CAN", Price = 50 });
            _context.Flight.Add(new Flight { Origin = "CAN", Destination = "ARG", Price = 250 });
            _context.Flight.Add(new Flight { Origin = "COL", Destination = "ARG", Price = 40 });
            _context.Flight.Add(new Flight { Origin = "ZWB", Destination = "COL", Price = 180 });
            await _context.SaveChangesAsync();
        }

        if (!_context.Journey.Any())
        {
            _context.Journey.Add(new Journey { Origin = "GER", Destination = "JPN", Price = 95 });
            await _context.SaveChangesAsync();
        }
        
    }
}
