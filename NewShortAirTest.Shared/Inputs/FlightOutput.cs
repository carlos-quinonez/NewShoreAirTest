using NewShortAirTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Inputs;

public class FlightOutput
{
     [JsonPropertyName("departureStation")]
    public string Origin { get; set; } = null!;

    [JsonPropertyName("arrivalStation")]
    public string Destination { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    public Transport? Transport { get; set; }
}
