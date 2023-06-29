using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Entities;

public class Flight
{
    public int Id { get; set; }

    [JsonPropertyName("departureStation")]
    public string Origin { get; set; } = null!;

    [JsonPropertyName("arrivalStation")]
    public string Destination { get; set; } = null!;

    [JsonPropertyName("price")]
    public double Price { get; set; }
    
}

/*
 * "": "MZL",
        "": "CTG",
        "flightCarrier": "CO",
        "flightNumber": "8002",
        "": 200
 */
