using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;

namespace Aircompany
{
    public class Runner
    {
        public static List<Plane> planes = new List<Plane>() {
            new PassengerPlane("Boeing-737", 900, 12000, 60500, 164, ClassificationLevel.UNCLASSIFIED),
            new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192, ClassificationLevel.UNCLASSIFIED),
            new PassengerPlane("Boeing-747", 980, 16100, 70500, 242, ClassificationLevel.UNCLASSIFIED),
            new PassengerPlane("Airbus A320", 930, 11800, 65500, 188, ClassificationLevel.UNCLASSIFIED),
            new PassengerPlane("Airbus A330", 990, 14800, 80500, 222, ClassificationLevel.CONFIDENTIAL),
            new PassengerPlane("Embraer 190", 870, 8100, 30800, 64,ClassificationLevel.UNCLASSIFIED),
            new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140, ClassificationLevel.UNCLASSIFIED),
            new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196, ClassificationLevel.UNCLASSIFIED),
            new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryType.BOMBER, ClassificationLevel.TOP_SECRET, ExperimentalTypes.HYPERSONIC),
            new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryType.BOMBER, ClassificationLevel.SECRET, ExperimentalTypes.HIGH_ALTITUDE),
            new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryType.BOMBER, ClassificationLevel.TOP_SECRET, ExperimentalTypes.HIGH_ALTITUDE),
            new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryType.FIGHTER, ClassificationLevel.SECRET, ExperimentalTypes.VTOL),
            new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryType.FIGHTER, ClassificationLevel.SECRET, ExperimentalTypes.HIGH_ALTITUDE),
            new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryType.TRANSPORT,ClassificationLevel.SECRET, ExperimentalTypes.HIGH_ALTITUDE)
    };
        public static void Main(string[] args)
        {
            Airport airport = new Airport(planes);
            Airport militaryAirport = new Airport(airport.GetMilitaryPlanes());
            Airport passengerAirport = new Airport(airport.GetPassengersPlanes());
            Console.WriteLine(militaryAirport.SortByMaxFlightDistance().ToString());
            Console.WriteLine(passengerAirport.SortByMaxSpeed().ToString());
            Console.WriteLine(passengerAirport.GetPassengerPlaneWithMaxPassengersCapacity());           
        }
    }
}
