using Engine.Gui.Model;

namespace Engine.Layers.Tactical
{
    public class MapSettings : IMapDrawSettings
    {
        public bool IsDrawCelestialObjectCoordinates { get; set; } = false;

        public bool IsDrawCelestialObjectDirections { get; set; } = true;

        public bool IsDrawSpaceshipInformation { get; set; } = true;

        public bool IsCenterOnSpaceship { get; set; } = true;
    }
}
