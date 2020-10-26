using System;
using System.Collections.Generic;
using Engine.Tools;

namespace Engine.Layers.Tactical
{
    [Serializable]
    public class CelestialMap
    {
        public string Id { get; set; }
        public int Turn { get; set; }
        public bool IsEnabled { get; set; }
        public List<ICelestialObject> CelestialObjects { get; set; } = new List<ICelestialObject>();

        

    }
}
