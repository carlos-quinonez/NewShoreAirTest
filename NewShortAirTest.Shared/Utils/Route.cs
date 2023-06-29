using NewShortAirTest.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShortAirTest.Shared.Utils;

public static class Route
{
    public static List<Flight> CalculateRoute(string origin, string destination, List<Flight> flights)
    {
        Dictionary<string, decimal> distances = new Dictionary<string, decimal>();
        Dictionary<string, Flight> beforeFlights = new Dictionary<string, Flight>();
        List<string> visitedNodes = new List<string>();

        foreach (Flight ruta in flights)
        {
            if (!distances.ContainsKey(ruta.Origin))
            {
                distances[ruta.Origin] = decimal.MaxValue;
            }
            if (!distances.ContainsKey(ruta.Destination))
            {
                distances[ruta.Destination] = decimal.MaxValue;
            }
        }

        distances[origin] = 0;

        while (true)
        {
            string currentNode = null;
            decimal minDistance = decimal.MaxValue;

            foreach (KeyValuePair<string, decimal> kvp in distances)
            {
                if (!visitedNodes.Contains(kvp.Key) && kvp.Value < minDistance)
                {
                    currentNode = kvp.Key;
                    minDistance = kvp.Value;
                }
            }
            if (currentNode == null || currentNode == destination)
            {
                break;
            }
            visitedNodes.Add(currentNode);
            List<Flight> routesFromCurrentNode = flights.Where(r => r.Origin == currentNode).ToList();

            foreach (Flight ruta in routesFromCurrentNode)
            {
                decimal distance = distances[currentNode] + ruta.Price;
                if (distance < distances[ruta.Destination])
                {
                    distances[ruta.Destination] = distance;
                    beforeFlights[ruta.Destination] = ruta;
                }
            }
        }
        if (!beforeFlights.ContainsKey(destination))
        {
            return null;
        }
        List<Flight> optimalRoute = new List<Flight>();
        Flight? currentRoute = beforeFlights[destination];

        while (currentRoute != null)
        {
            optimalRoute.Insert(0, currentRoute);
            currentRoute = beforeFlights.ContainsKey(currentRoute.Origin) ? beforeFlights[currentRoute.Origin] : null;
        }

        return optimalRoute;
    }
}
