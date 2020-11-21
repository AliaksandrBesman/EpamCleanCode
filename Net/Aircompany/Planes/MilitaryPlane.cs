using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        private readonly MilitaryType militaryType;
        private readonly ClassificationLevel classificationLevel;
        private readonly ExperimentalTypes experimentalTypes;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType militaryType, ClassificationLevel classificationLevel, ExperimentalTypes experimentalTypes)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.militaryType = militaryType;
            this.classificationLevel = classificationLevel;
            this.experimentalTypes = experimentalTypes;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   militaryType == plane.militaryType &&
                   classificationLevel == plane.classificationLevel &&
                   experimentalTypes == plane.experimentalTypes 
                   ;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + militaryType.GetHashCode();
            hashCode = hashCode * -1521134295 + classificationLevel.GetHashCode();
            hashCode = hashCode * -1521134295 + experimentalTypes.GetHashCode();
            return hashCode;
        }

        public MilitaryType GetMilitaryType()
        {
            return militaryType;
        }

        public ClassificationLevel GetClassificationLevel()
        {
            return classificationLevel;
        }
        
        public ExperimentalTypes GetExperimentalTypes()
        {
            return experimentalTypes;
        }


        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", militaryType=" + militaryType +
                    ", experimentalTypes=" + experimentalTypes +
                    ", classificationLevel=" + classificationLevel +
                    '}');
        }        
    }
}
