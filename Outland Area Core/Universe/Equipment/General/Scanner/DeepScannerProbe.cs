using System;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;

namespace EngineCore.Universe.Equipment.General.Scanner
{
    [Serializable]
    public class DeepScannerProbe : BaseCelestialObject, IDeepScanProbe, ICelestialObject
    {
        public int AmmoId { get; set; } = 601;
        public long OwnerId { get; set; }
        public float ScanRadius { get; set; } = 30;
        public float ScanPower { get; set; } = 60;

        public DeepScannerProbe()
        {
            Id = RandomGenerator.GetId();
            Speed = 90;
            Classification = (int)CelestialObjectTypes.ScanProbe;
            Name = "Deep Scan Object Probe Mk I";
        }
    }
}
