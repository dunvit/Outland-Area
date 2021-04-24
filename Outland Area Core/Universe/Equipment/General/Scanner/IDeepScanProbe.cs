namespace EngineCore.Universe.Equipment.General.Scanner
{
    public interface IDeepScanProbe
    {
        int AmmoId { get; set; }
        long OwnerId { get; set; }
        float ScanRadius { get; set; }

        float ScanPower { get; set; }
    }
}