using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Entities;

public class Flight
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonPropertyName("departureStation")]
    public string Origin { get; set; } = null!;

    [JsonPropertyName("arrivalStation")]
    public string Destination { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("flightCarrier")]
    public string FlightCarrier { get; set; } = null!;

    [JsonPropertyName("flightNumber")]
    public string FlightNumber { get; set; } = null!;
    
    //public Transport? Transport { get; set; }
}

/*
 * "": "MZL",
        "": "CTG",
        "": "CO",
        "": "8002",
        "": 200
 */
