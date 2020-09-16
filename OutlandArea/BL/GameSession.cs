using OutlandArea.Map;

namespace OutlandArea.BL
{
    public class GameSession
    { 
        public int Id { get; set; }

        public CelestialMap Map { get; set; }

        public int Commands { get; set; }
    }
}
