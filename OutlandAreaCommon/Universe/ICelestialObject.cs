﻿namespace OutlandAreaCommon.Universe
{
    public interface ICelestialObject
    {
        int Id { get; set; }
        int OwnerId { get; set; }
        string Name { get; set; }
        double Direction { get; set; }
        int Signature { get; set; }
        int Speed { get; set; }
        float PositionX { get; set; }
        float PositionY { get; set; }
        float PreviousPositionX { get; set; }
        float PreviousPositionY { get; set; }
        int Classification { get; set; }
        string ImageSmall { get; set; }
        bool IsScanned { get; set; }
    }
}
