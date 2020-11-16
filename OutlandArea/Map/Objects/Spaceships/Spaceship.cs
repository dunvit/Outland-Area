﻿using System;
using System.Collections.Generic;
using OutlandArea.BL.Equipment;

namespace OutlandArea.Map.Objects
{
    [Serializable]
    public class Spaceship : ICelestialObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Direction { get; set; }
        public int Signature { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Classification { get; set; }
        public string ImageSmall { get; set; }
        public bool IsScanned { get; set; }

        public List<IModule> Modules { get; set; } = new List<IModule>();
    }
}