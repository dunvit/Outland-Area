using Engine.Tools;

namespace Engine.Layers.Tactical
{
    public static class SessionExtensions
    {
        public static ICelestialObject GetPlayerSpaceShip(this GameSession session)
        {
            foreach (var celestialObject in session.Map.CelestialObjects)
            {
                if (celestialObject.Classification == 200)
                {
                    return celestialObject.DeepClone();
                }
            }

            return null;
        }
    }
}
