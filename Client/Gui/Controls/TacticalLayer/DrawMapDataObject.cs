using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer
{
    [Serializable]
    public class DrawMapDataObject
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }

        private ICelestialObject CurrentCelestialObject { get; set; }

        private SortedDictionary<int, PointF> WayPoints { get; set; }

        private PointF positionFrom { get; set; }
        private PointF positionTo { get; set; }


        public DrawMapDataObject(ICelestialObject previous, ICelestialObject current, int turn)
        {
            Id = current.Id;
            CurrentCelestialObject = current.DeepClone();

            positionFrom = new PointF(previous.PositionX, previous.PositionY);
            positionTo = new PointF(current.PositionX, current.PositionY);

            WayPoints = Coordinates.GetWayPoints(
                new Point(previous.PositionX, previous.PositionY), 
                new Point(current.PositionX, current.PositionY), 10);

            if (current.Id == 5005)
            {
                foreach (var wayPoint in WayPoints.Keys)
                {
                    Logger.Debug($"[PlayerShip] WeyPoint=({turn}.{wayPoint}) Position={WayPoints[wayPoint]} From={positionFrom} To={positionTo}");
                }

                
            }
        }

        public ICelestialObject GetCelestialObject(int turn, int weyPoint)
        {
            var currentPosition = WayPoints[weyPoint] is PointF ? (PointF) WayPoints[weyPoint] : default;

            var celestialObject = CurrentCelestialObject.DeepClone();
            celestialObject.PositionX = (int)currentPosition.X;
            celestialObject.PositionY = (int)currentPosition.Y;

            if (celestialObject.Id == 5005)
            {
                Logger.Debug($"[PlayerShip] WeyPoint=({turn}.{weyPoint}) Position={currentPosition} From={positionFrom} To={positionTo}");
            }

            return celestialObject;
        }
    }
}
