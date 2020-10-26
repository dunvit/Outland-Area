using System;
using System.Collections.Generic;

namespace Engine.Layers.Tactical
{
    [Serializable]
    public class GameSession
    { 
        public int Id { get; set; }

        public int Turn { get; set; }

        public CelestialMap Map { get; set; }

        public List<Command> Commands { get; set; }

        public ICelestialObject SelectedObject { get; set; }
    }
}
