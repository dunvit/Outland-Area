using System;
using System.Drawing;
using Engine.Tools;

namespace Engine.Layers.Tactical
{
    public class SessionTools
    {



        public static ICelestialObject GetObjectInRange(GameSession gameSession, int distance, Point point)
        {
            foreach (var celestialObjects in gameSession.Map.CelestialObjects)
            {
                if (IsObjectInRange(celestialObjects, distance, point))
                {
                    return celestialObjects.DeepClone();
                }
            }

            return null;
        }

        public static bool IsObjectInRange(ICelestialObject celestialObject, int distance, Point point)
        {
            var w = Math.Abs(celestialObject.PositionX - point.X);
            var h = Math.Abs(celestialObject.PositionY - point.Y);

            return w < distance && h < distance;
        }
    }
}
