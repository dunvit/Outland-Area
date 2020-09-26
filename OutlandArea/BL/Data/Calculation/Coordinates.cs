using System;
using System.Drawing;
using OutlandArea.Map;
using OutlandArea.Tools;

namespace OutlandArea.BL.Data.Calculation
{
    public class Coordinates
    {
        public CelestialMap Recalculate(CelestialMap spaceMap)
        {
            var result = spaceMap.DeepClone();

            //var random = new Random((int)DateTime.UtcNow.Ticks);

            foreach (var celestialObject in result.CelestialObjects)
            {
                var position = Common.MoveCelestialObjects(
                    new Point(celestialObject.PositionX, celestialObject.PositionY),
                    celestialObject.Speed, 
                    celestialObject.Direction);

                celestialObject.PositionX = position.X;
                celestialObject.PositionY = position.Y;
            }

            return result;
        }
    }
}
