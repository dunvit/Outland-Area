using EngineCore.Session;
using EngineCore.Tools;

namespace EngineCore.DataProcessing
{
    public class Commands
    {
        public CelestialMap Execute(GameSession gameSession, TurnSettings settings)
        {
            var result = gameSession.DeepClone();

            foreach (Command command in gameSession.Commands.Values)
            {
                switch (command.Type)
                {
                    case CommandTypes.MoveForward:
                        break;
                    case CommandTypes.TurnLeft:
                        result = new CommandsExecution.Navigation().Execution(gameSession, settings, command);
                        break;
                    case CommandTypes.TurnRight:
                        result = new CommandsExecution.Navigation().Execution(gameSession, settings, command);
                        break;
                    case CommandTypes.StopShip:
                        result = new CommandsExecution.Navigation().Execution(gameSession, settings, command);
                        break;
                    case CommandTypes.Acceleration:
                        result = new CommandsExecution.Navigation().Execution(gameSession, settings, command);
                        break;
                    case CommandTypes.Fire:
                        break;
                    case CommandTypes.AlignTo:
                        break;
                    case CommandTypes.Orbit:
                        break;
                    case CommandTypes.Explosion:
                        break;
                    case CommandTypes.ReloadWeapon:
                        break;
                    case CommandTypes.Scanning:
                        break;
                }
            }

            return result.SpaceMap;
        }
    }
}
