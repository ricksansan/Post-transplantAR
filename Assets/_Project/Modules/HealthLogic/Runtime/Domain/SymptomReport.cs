using System;

namespace LiverAR.Modules.HealthLogic.Runtime.Domain
{
    [Serializable]
    public class SymptomReport
    {
        public float TemperatureCelsius;
        public bool HasSeverePain;
        public bool HasNausea;
        public bool HasWoundRedness;
        public int EnergyLevel;
    }
}
