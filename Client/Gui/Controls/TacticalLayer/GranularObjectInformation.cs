using System;
using System.Collections.Generic;
using System.Drawing;
using OutlandAreaCommon;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer
{
    [Serializable]
    public class GranularObjectInformation
    {
        public int Id { get; set; }

        public ICelestialObject CelestialObject { get; set; }

        public SortedDictionary<int, PointF> WayPoints { get; set; }

        public GranularObjectInformation(ICelestialObject celestialObject, int drawInterval)
        {
            Id = celestialObject.Id;

            CelestialObject = celestialObject.DeepClone();

            WayPoints = Coordinates.GetWayPoints(
                new PointF(celestialObject.PreviousPositionX, celestialObject.PreviousPositionY),
                new PointF(celestialObject.PositionX, celestialObject.PositionY), drawInterval);
        }
    }
}
