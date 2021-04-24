using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EngineCore.DataProcessing;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using LanguageExt;
using LanguageExt.SomeHelp;
using log4net;

namespace EngineCore.Session
{
    public static class SessionExtensions
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ICelestialObject GetPlayerSpaceShip(this GameSession session)
        {
            foreach (var celestialObject in session.SpaceMap.CelestialObjects)
            {
                if (celestialObject.Classification == 200)
                {
                    return celestialObject.DeepClone();
                }
            }

            return null;
        }

        public static List<Command> GetSpaceShipCommands(this GameSession session, long id)
        {
            // TODO: Big memory crash on collection modification
            var result = new List<Command>();

            foreach (var sessionCommand in session.Commands)
            {
                if (sessionCommand.CelestialObjectId == id)
                {
                    result.Add(sessionCommand.DeepClone());
                }
            }

            return result;
        }

        public static List<Spaceship> GetSpaceShips(this GameSession session)
        {
            var npcSpaceships = session.SpaceMap.CelestialObjects.
                Where(_ => _.IsSpaceship()).
                Where(_ => _.Classification == CelestialObjectTypes.SpaceshipPlayer.ToInt() || 
                           _.Classification == CelestialObjectTypes.SpaceshipNpcFriend.ToInt()).
                Map(_ => _.ToSpaceship()).
                ToList();

            return npcSpaceships;
        }


        public static ICelestialObject AGetCelestialObject(this GameSession gameSession, long id)
        {
            foreach (var celestialObjects in gameSession.SpaceMap.CelestialObjects)
            {
                if (id == celestialObjects.Id)
                {
                    return celestialObjects;
                }
            }

            return null;
        }
        /*
         *
         *
         *
         *
         foreach (var spaceShip in gameSession.SpaceMap.CelestialObjects.Where(mapCelestialObject => mapCelestialObject.Id == command.CelestialObjectId))
                    {
                        Logger.Debug($"[{GetType().Name}]\t CommandsExecute Navigation - {command.Type} " +
                                     $"Direction before: {directionBeforeManeuver} " +
                                     $"Direction after: {directionAfterManeuver} ");
                        spaceShip.Direction = directionAfterManeuver;
                    }
         *
         *
         *
         */


        public static CommandTypes GetMovementType(this GameSession session, long id)
        {
            var cObject = session.GetCelestialObject(id);

            foreach (var command in session.Commands)
            {
                if (command.CelestialObjectId == cObject.Id)
                {
                    switch (command.Type)
                    {
                        case CommandTypes.AlignTo:
                            return CommandTypes.AlignTo;

                        case CommandTypes.Orbit:
                            return CommandTypes.Orbit;
                    }
                }
            }

            return CommandTypes.MoveForward;
        }

        public static Option<CelestialMap> GetSpaceMapOption(this GameSession gameSession)
        {
            if(gameSession.SpaceMap == null)
            {
                return Option<CelestialMap>.None;
            }

            return gameSession.SpaceMap.ToSome();
        }

        public static Option<ICelestialObject> GetCelestialObjectOption(this GameSession gameSession, long id)
        {
            foreach (var celestialObjects in gameSession.SpaceMap.CelestialObjects)
            {
                if (id == celestialObjects.Id)
                {
                    return Option<ICelestialObject>.Some(celestialObjects.DeepClone());
                }
            }

            return Option<ICelestialObject>.None;
        }

        public static Option<List<ICelestialObject>> GetCelestialObjectsOption(this GameSession gameSession)
        {
            return Option<List<ICelestialObject>>.Some(gameSession.SpaceMap.CelestialObjects);
        }

        public static List<ICelestialObject> GetCelestialObjectsByDistance(this GameSession gameSession)
        {
            
            return gameSession.SpaceMap.CelestialObjects.Map(celestialObject => (celestialObject,
                    Coordinates.GetDistance(
                        gameSession.GetPlayerSpaceShip().GetLocation(),
                        celestialObject.GetLocation())
                )).
                OrderBy(e => e.Item2).Map(e => e.celestialObject).
                Where(celestialObject => celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).
                ToList();
        }

        

        public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id, bool isCopy = true)
        {
            if(isCopy)
                return (from celestialObjects in gameSession.SpaceMap.CelestialObjects where id == celestialObjects.Id select celestialObjects.DeepClone()).FirstOrDefault();

            return (from celestialObjects in gameSession.SpaceMap.CelestialObjects where id == celestialObjects.Id select celestialObjects).FirstOrDefault();
        }

        public static void AddCelestialObject(this GameSession session, ICelestialObject celestialObject)
        {
            Logger.Info($"[AddCelestialObject] Turn = {session.Turn} AddCelestialObject Id = {celestialObject.Id} Name = {celestialObject.Name} Classification = {celestialObject.Classification}");
            session.SpaceMap.CelestialObjects.Add(celestialObject);
        }

        

        public static void RemoveCelestialObject(this GameSession session, ICelestialObject celestialObject)
        {
            if (celestialObject == null) return;

            var result = new List<ICelestialObject>();

            foreach (var mapCelestialObject in session.SpaceMap.CelestialObjects)
            {
                if (mapCelestialObject.Id != celestialObject.Id)
                {
                    result.Add(mapCelestialObject);
                }
            }

            session.SpaceMap.CelestialObjects = result;
        }

        public static void AddCommand(this GameSession session, Command command)
        {
            List<Command> commands;

            switch (command.Type)
            {
                case CommandTypes.AlignTo:
                    commands = RemoveMovementCommands(command, session);
                    break;

                case CommandTypes.Orbit:
                    commands = RemoveMovementCommands(command, session);
                    break;

                case CommandTypes.TurnLeft:
                case CommandTypes.TurnRight:
                case CommandTypes.MoveForward:
                case CommandTypes.Acceleration:
                case CommandTypes.StopShip:
                    commands = RemoveMovementCommands(command, session);
                    break;


                default:
                    commands = session.Commands;
                    break;
            }

            commands.Add(command);

            session.Commands = commands.DeepClone();
        }

        private static List<Command> RemovePreviousCommand(CommandTypes type, GameSession session)
        {
            var commands = new List<Command>();

            foreach (var command in session.Commands)
            {
                if (command.Type != type)
                {
                    commands.Add(command);
                }
            }

            return commands;
        }

        private static List<Command> RemoveMovementCommands(Command newCommand, GameSession session)
        {
            var commands = new List<Command>();

            foreach (var command in session.Commands)
            {
                // Remove only commands for current spaceship
                if (command.CelestialObjectId == newCommand.CelestialObjectId)
                {
                    if ((int)command.Type < 200 || (int)command.Type > 249)
                    {
                        commands.Add(command);
                    }
                }
                else
                {
                    // This is not current spaceship command
                    commands.Add(command);
                }
                
            }

            return commands;
        }

        public static void AddHistoryMessage(this GameSession session, string message, string className, bool isTechnicalLog = false)
        {
            Logger.Debug($"[HistoryMessage]\t [{className}]\t {message} ");

            session.TurnHistory.Add(new HistoryMessage
            {
                Turn = session.Turn,
                Class = className,
                Message = message,
                IsTechnicalLog = isTechnicalLog
            });
        }
    }
}
