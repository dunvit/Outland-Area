using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Engine.Tools;

namespace Engine.Layers.Tactical
{
    public static class SessionExtensions
    {
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

        public static void AddCelestialObject(this GameSession session, ICelestialObject celestialObject)
        {
            session.Map.CelestialObjects.Add(celestialObject);
        }

        public static void AddCommand(this GameSession session, Command command)
        {
            List<Command> commands;

            switch (command.Type)
            {
                case CommandTypes.AlignTo:
                    commands = RemovePreviousCommand(command.Type, session);
                    break;

                default:
                    commands = session.Commands;
                    break;
            }

            commands.Add(command);
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
    }
}
