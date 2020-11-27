using Engine.Common.Geometry.Trajectory;
using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class AlignTo
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            bool isResume = true;

            Logger.Info($"[{GetType().Name}]\t CommandsExecute AlignTo - Execute.");

            var spaceShip = gameSession.GetPlayerSpaceShip();
            var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);
            
            var result = Approach.Calculate(spaceShip.GetLocation(), targetObject.GetLocation(), spaceShip.Direction, spaceShip.Speed, 100);

            foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            {
                if (mapCelestialObject.Id == spaceShip.Id)
                {
                    if (result.Trajectory.Count > spaceShip.Speed)
                    {
                        mapCelestialObject.Direction = result.Trajectory[spaceShip.Speed].Direction;
                        Logger.Debug($"[{GetType().Name}]\t CommandsExecute AlignTo - {mapCelestialObject.Name} Direction before is {mapCelestialObject.Direction} Direction after {mapCelestialObject.Direction}");

                        if (result.Trajectory[spaceShip.Speed].Distance < spaceShip.Speed * 2)
                        {
                            isResume = false;
                            Logger.Info($"[{GetType().Name}]\t CommandsExecute AlignTo - {mapCelestialObject.Name} finished. Target location is {targetObject.GetLocation()} current location is {spaceShip.GetLocation()}");
                        }
                    }
                }
            }

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
