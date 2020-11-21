using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private readonly List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            this.planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return planes.Where(p => p.GetType() == typeof(PassengerPlane)).Select(p => (PassengerPlane)p).ToList();
        }
         
        

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Select(p => (MilitaryPlane)p).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().OrderByDescending(p => p.GetPassengersCapacity()).First();           
        }

        public List<MilitaryPlane> GetMilitaryPlanesWithEnteredMilitaryType(MilitaryType militaryType)
        {
            return GetMilitaryPlanes().Where(p => p.GetMilitaryType() == militaryType).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanesWithEnteredExperimentalType(ExperimentalTypes experimentalTypes)
        {
            return GetMilitaryPlanes().Where(p => p.GetExperimentalTypes() == experimentalTypes).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanesWithEnteredClassificationLevel(ClassificationLevel classificationLevel)
        {
            return GetMilitaryPlanes().Where(p => p.GetClassificationLevel() == classificationLevel).ToList();
        }

        public List<PassengerPlane> GetPassengerPlanesWithEnteredClassificationLevel(ClassificationLevel classificationLevel)
        {
            return GetPassengersPlanes().Where(p => p.GetClassificationLevel() == classificationLevel).ToList();
        }

        public Airport SortByMaxFlightDistance()
        {
            planes.OrderBy(p => p.GetMaxFlightDistance());
            return this; 
        }

        public Airport SortByMaxSpeed()
        {
            planes.OrderBy(w => w.GetMaxSpeed());
            return this;
        }

        public Airport SortByMaxLoadCapacity()
        {
            planes.OrderBy(w => w.GetMaxLoadCapacity());
            return this;
        }

        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", planes.Select(x => x.GetModel())) +
                    '}';
        }
    }
}
