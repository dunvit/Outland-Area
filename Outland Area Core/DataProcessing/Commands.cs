using System;
using EngineCore.Session;

namespace EngineCore.DataProcessing
{
    public class Commands
    {
        public GameSession ExecuteCommand(GameSession gameSession, EngineSettings settings, Command command, Action<int, string> addCommand) =>
            command.Type switch
            {
                CommandTypes.MoveForward => new CommandsExecution.Navigation().Execution(gameSession, settings, command),
                CommandTypes.TurnLeft => new CommandsExecution.Navigation().Execution(gameSession, settings, command),
                CommandTypes.TurnRight => new CommandsExecution.Navigation().Execution(gameSession, settings, command),
                CommandTypes.StopShip => new CommandsExecution.Navigation().Execution(gameSession, settings, command),
                CommandTypes.Acceleration => new CommandsExecution.Navigation().Execution(gameSession, settings, command),
                CommandTypes.Shot => new CommandsExecution.Shots().Execution(gameSession, settings, command, addCommand),
                _ => throw new ArgumentException("Invalid enum value for command", nameof(command)),
            };

        public GameSession Execute(GameSession gameSession, EngineSettings settings, Action<int, string> addCommand)
        {
            var result = gameSession;

            foreach (Command command in gameSession.Commands.Values)
            {
                result = ExecuteCommand(gameSession, settings, command, addCommand);
            }

            return result;
        }
    }
}
