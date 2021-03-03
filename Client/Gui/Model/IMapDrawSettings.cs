
namespace Engine.Gui.Model
{
    public interface IMapDrawSettings
    {
        bool IsDrawCelestialObjectCoordinates { get; set; } 

        bool IsDrawCelestialObjectDirections { get; set; }

        bool IsDrawSpaceshipInformation { get; set; } 
    }
}
