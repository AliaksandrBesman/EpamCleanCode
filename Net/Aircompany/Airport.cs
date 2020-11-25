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
            return new Airport(planes.OrderBy(p => p.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxLoadCapacity()));
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

        public virtual bool IsEqualByHash(object obj)
        {
            List<Plane> airport = obj as List<Plane>;
            bool equality = true;
            if (planes.Count == airport.Count)
            {
                for (int i = 0; i < planes.Count; i++)
                {
                    equality &= planes[i].GetHashCode() == airport[i].GetHashCode();
                }
            }

            return equality;
        }
    }
}
