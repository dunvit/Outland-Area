using System.Linq;
using log4net;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

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

            Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} ");

            var currentSpaceShip = gameSession.GetCelestialObject(command.CelestialObjectId).ToSpaceship();

            if (currentSpaceShip == null)
            {
                Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} space ship not found.");
                return new CommandExecuteResult { Command = command, IsResume = isResume };
            }

            var updatedObject = gameSession.GetCelestialObject(command.CelestialObjectId, false);

            switch (command.Type)
            {
                case CommandTypes.StopShip:
                    if (currentSpaceShip.Speed <= 0)
                    {
                        var commandMoveForward = new Command
                        {
                            Type = CommandTypes.MoveForward,
                            TargetCelestialObjectId = command.TargetCelestialObjectId,
                            TargetCellId = command.TargetCellId,
                            CelestialObjectId = command.CelestialObjectId,
                            MemberId = command.MemberId
                        };

                        gameSession.GetCelestialObject(command.CelestialObjectId, false).Speed = 0;

                        return new CommandExecuteResult { Command = commandMoveForward, IsResume = true };
                    }

                    // Update current space ship speed
                    Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} " +
                                 $"Speed before: {updatedObject.Speed} " +
                                 $"Speed after: {updatedObject.Speed - 1} ");

                    updatedObject.Speed = updatedObject.Speed - 1;

                    return new CommandExecuteResult { Command = command, IsResume = true };

                case CommandTypes.Acceleration:
                    

                    if (currentSpaceShip.Speed >= currentSpaceShip.MaxSpeed)
                    {
                        var commandMoveForward = new Command
                        {
                            Type = CommandTypes.MoveForward,
                            TargetCelestialObjectId = command.TargetCelestialObjectId,
                            TargetCellId = command.TargetCellId,
                            CelestialObjectId = command.CelestialObjectId,
                            MemberId = command.MemberId
                        };

                        gameSession.GetCelestialObject(command.CelestialObjectId, false).Speed =
                            currentSpaceShip.MaxSpeed;

                        return new CommandExecuteResult { Command = commandMoveForward, IsResume = true };
                    }

                    // Update current space ship speed
                    updatedObject = gameSession.GetCelestialObject(command.CelestialObjectId, false);

                    var speedBeforeManeuver = updatedObject.Speed;

                    updatedObject.Speed = updatedObject.Speed + 1;

                    Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} " +
                                 $"Speed before: {speedBeforeManeuver} " +
                                 $"Speed after: {updatedObject.Speed} ");

                    return new CommandExecuteResult { Command = command, IsResume = true };

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
