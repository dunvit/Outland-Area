using System;
using System.Collections.Generic;
using OutlandArea.Map;

namespace OutlandArea.BL
{
    [Serializable]
    public class GameSession
    { 
        public int Id { get; set; }

        public int Turn { get; set; }

        public CelestialMap Map { get; set; }

        public List<GameCommand> Commands { get; set; }
    }
}
