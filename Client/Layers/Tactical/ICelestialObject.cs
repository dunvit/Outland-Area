namespace Engine.Layers.Tactical
{
    public interface ICelestialObject
    {
        int Id { get; set; }
        string Name { get; set; }
        int Direction { get; set; }
        int Signature { get; set; }
        int Speed { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        int Classification { get; set; }
        string ImageSmall { get; set; }
        bool IsScanned { get; set; }
    }
}
