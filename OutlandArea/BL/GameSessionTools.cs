using OutlandArea.Map;
using OutlandArea.Tools;

namespace OutlandArea.BL
{
    public class GameSessionTools
    {
        public static ICelestialObject GetCelestialObject(long id, GameSession gameSession)
        {
            foreach (var celestialObjects in gameSession.Map.CelestialObjects)
            {
                if (id == celestialObjects.Id)
                {
                    return celestialObjects.DeepClone();
                }
            }

            return null;
        }


    }
}
