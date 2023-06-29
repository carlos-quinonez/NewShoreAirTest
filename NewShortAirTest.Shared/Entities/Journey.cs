using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Entities;

public class Journey
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Origin { get; set; } = null!;
    public string Destination { get; set; } = null!;
    public decimal Price { get; set; }
    public List<Flight>? Flights { get; set; }
}
