using System.Collections.Generic;
using System.Reflection;
using log4net;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
{
    public static class SessionExtensions
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ICelestialObject GetPlayerSpaceShip(this GameSession session)
        {
            foreach (var celestialObject in session.Map.CelestialObjects)
            {
                if (celestialObject.Classification == 200)
                {
                    return celestialObject.DeepClone();
                }
            }

            return null;
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
                            break;

                        case CommandTypes.Orbit:
                            return CommandTypes.Orbit;
                            break;
                    }
                }
            }

            return CommandTypes.MoveForward;
        }

        public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id)
        {
            foreach (var celestialObjects in gameSession.Map.CelestialObjects)
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
            session.Map.CelestialObjects.Add(celestialObject);
        }

        public static void RemoveCelestialObject(this GameSession session, ICelestialObject celestialObject)
        {
            var result = new List<ICelestialObject>();

            foreach (var mapCelestialObject in session.Map.CelestialObjects)
            {
                if (mapCelestialObject.Id != celestialObject.Id)
                {
                    result.Add(mapCelestialObject);
                }
            }

            session.Map.CelestialObjects = result;
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
