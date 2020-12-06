using LanguageExt;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
{
    public static class CelestialMapExtensions
    {
        public static Option<ICelestialObject> GetCelestialObjectOption(this CelestialMap celestialMap, long id)
        {
            foreach (var celestialObjects in celestialMap.CelestialObjects)
            {
                if (id == celestialObjects.Id)
                {
                    return Option<ICelestialObject>.Some(celestialObjects.DeepClone());
                }
            }

            return Option<ICelestialObject>.None;
        }
    }
}
