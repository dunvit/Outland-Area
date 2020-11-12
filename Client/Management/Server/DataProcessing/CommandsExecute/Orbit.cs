using System.Drawing;
using Engine.Layers.Tactical;
using Engine.Management.Server.DataProcessing.Trajectory;

namespace Engine.Management.Server.DataProcessing.CommandsExecute
{
    public class Orbit
    {
        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            const bool isResume = true;

            var spaceShip = gameSession.GetPlayerSpaceShip();
            var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

            var pointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);

            var orbitPoint = Coordinates.GetRadiusPoint(spaceShip.GetLocation(), pointTargetLocation, 100);

            var result = new RouteCalculation().Execute(pointCurrentLocation, new Point((int) orbitPoint.X, (int) orbitPoint.Y), spaceShip.Direction, spaceShip.Speed, 200);

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

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
