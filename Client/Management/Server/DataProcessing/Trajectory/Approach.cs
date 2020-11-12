using System.Collections.Generic;
using System.Drawing;
using Engine.Layers.Tactical;

namespace Engine.Management.Server.DataProcessing.Trajectory
{
    public partial class GetTrajectory
    {
        public List<ObjectLocation> Approach(GameSession gameSession, ICelestialObject spaceShip, ICelestialObject targetObject)
        {
            var pointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);

            var result = Coordinates.GetTrajectoryApproach(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);

            foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            {
                if (mapCelestialObject.Id == spaceShip.Id)
                {
                    if (result.Count > 1)
                    {
                        mapCelestialObject.Direction = result[1].Direction;
                    }
                }
            }

            return result;
        }
    }
}
