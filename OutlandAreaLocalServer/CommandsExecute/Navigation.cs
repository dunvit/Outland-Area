using System.Linq;
using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Navigation
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            var isResume = true;

            double mobilityInDegrees = 1;
            double directionBeforeManeuver = 0;
            double directionAfterManeuver = 0;

            switch (command.Type)
            {
                case CommandTypes.TurnLeft:
                    Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} ");

                    directionBeforeManeuver = gameSession.GetCelestialObject(command.CelestialObjectId).Direction;
                    directionAfterManeuver = (directionBeforeManeuver - mobilityInDegrees > 0) ? directionBeforeManeuver - mobilityInDegrees : 360 - (directionBeforeManeuver - mobilityInDegrees);

                    foreach (var spaceShip in gameSession.SpaceMap.CelestialObjects.Where(mapCelestialObject => mapCelestialObject.Id == command.CelestialObjectId))
                    {
                        Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} " +
                                     $"Direction before: {directionBeforeManeuver} " +
                                     $"Direction after: {directionAfterManeuver} ");
                        spaceShip.Direction = directionAfterManeuver;
                    }

                    break;
                case CommandTypes.TurnRight:
                    Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} ");
                    
                    directionBeforeManeuver = gameSession.GetCelestialObject(command.CelestialObjectId).Direction;
                    directionAfterManeuver = (directionBeforeManeuver + mobilityInDegrees < 361) ? directionBeforeManeuver + mobilityInDegrees : (directionBeforeManeuver + mobilityInDegrees) - 360;

                    foreach (var spaceShip in gameSession.SpaceMap.CelestialObjects.Where(mapCelestialObject => mapCelestialObject.Id == command.CelestialObjectId))
                    {
                        Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} " +
                                     $"Direction before: {directionBeforeManeuver} " +
                                     $"Direction after: {directionAfterManeuver} ");
                        spaceShip.Direction = directionAfterManeuver;
                    }
                    break;
                case CommandTypes.MoveForward:
                    Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} ");
                    break;
                default:
                    isResume = false;
                    Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - Error on {command.Type}");
                    break;
            }

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
