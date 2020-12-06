using System.Collections.Generic;
using System.Reflection;
using LanguageExt;
using LanguageExt.SomeHelp;
using log4net;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
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

        public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id)
        {
            foreach (var celestialObjects in gameSession.SpaceMap.CelestialObjects)
            {
                if (id == celestialObjects.Id)
                {
                    return celestialObjects.DeepClone();
                }
            }

            return null;
        }

        public static void AddCelestialObject(this GameSession session, ICelestialObject celestialObject)
        {
            Logger.Info($"AddCelestialObject Id = {celestialObject.Id} Name = {celestialObject.Name} Classification = {celestialObject.Classification}" );
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
                    if ((int)command.Type < 99 || (int)command.Type > 200)
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
    }
}
