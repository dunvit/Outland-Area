using Newtonsoft.Json.Linq;

namespace EngineCore.Universe.Equipment.Propulsion
{
    public interface IPropulsionModule
    {
        double Power { get; set; }

        dynamic Braking();
    }
}
