using System.Drawing;
using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class ExecuteFire
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            var isResume = true;

            Logger.Info($"[{GetType().Name}]\t CommandsExecute ExecuteFire - Execute.");

            var missile = gameSession.GetCelestialObject(command.CelestialObjectId);
            var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

            if (missile == null) return new CommandExecuteResult { Command = command, IsResume = false };
            if (targetObject == null) return new CommandExecuteResult { Command = command, IsResume = false };

            var pointCurrentLocation = new PointF(missile.PositionX, missile.PositionY);
            var pointTargetLocation = new PointF(targetObject.PositionX, targetObject.PositionY);

            var direction = Coordinates.GetRotation(pointTargetLocation, pointCurrentLocation);

            foreach (var mapCelestialObject in gameSession.SpaceMap.CelestialObjects)
            {
                if (mapCelestialObject.Id == missile.Id)
                {
                    mapCelestialObject.Direction = direction;
                }
            }

            var distance = Coordinates.GetDistance(missile.GetLocation(), targetObject.GetLocation());

            if (distance <= missile.Speed / 2)
            {
                // BOOM!!!
                isResume = false;
                gameSession.RemoveCelestialObject(missile);
            }

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
