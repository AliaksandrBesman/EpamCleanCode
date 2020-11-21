using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private List<Plane> planes = new List<Plane>(){
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

        private PassengerPlane planeWithMaxPassengerCapacity = new PassengerPlane("Boeing-747", 980, 16100, 70500, 242, ClassificationLevel.UNCLASSIFIED);

        [Test]
        public void MyTest1()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetMilitaryPlanesWithEnteredMilitaryType(MilitaryType.TRANSPORT).ToList();
            Assert.AreEqual(transportMilitaryPlanes.Count > 0,true);
        }

        [Test]
        public void MyTest2()
        {
            Airport airport = new Airport(planes);
            PassengerPlane expectedPlaneWithMaxPassengersCapacity = airport.GetPassengerPlaneWithMaxPassengersCapacity();           
        }

        [Test]
        public void MyTest3()
        {
            Airport airport = new Airport(planes);
            airport = airport.SortByMaxLoadCapacity();
            List<Plane> planesSortedByMaxLoadCapacity = airport.GetPlanes().ToList();

            bool nextPlaneMaxLoadCapacityIsHigherThanCurrent = true;
            for (int i = 0; i < planesSortedByMaxLoadCapacity.Count - 1; i++)
            {
                Plane currentPlane = planesSortedByMaxLoadCapacity[i];
                Plane nextPlane = planesSortedByMaxLoadCapacity[i + 1];
                if (currentPlane.MAXLoadCapacity() > nextPlane.MAXLoadCapacity())
                {
                    nextPlaneMaxLoadCapacityIsHigherThanCurrent = false;
                }
            }
            Assert.That(nextPlaneMaxLoadCapacityIsHigherThanCurrent==true);
        }
    }
}
