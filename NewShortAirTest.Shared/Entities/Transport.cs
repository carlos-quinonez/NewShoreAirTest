using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Entities;

public class Transport
{
    public int Id { get; set; }

    public string FlightCarrier { get; set; } = null!;

    public string FlightNumber { get; set; } = null!;
}
