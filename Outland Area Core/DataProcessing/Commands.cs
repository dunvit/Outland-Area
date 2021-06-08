﻿using EngineCore.Session;
using EngineCore.Tools;

namespace EngineCore.DataProcessing
{
    public class Commands
    {
        public GameSession Execute(GameSession gameSession, EngineSettings settings)
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
                    case CommandTypes.Shot:
                        result = new CommandsExecution.Shots().Execution(gameSession, settings, command);
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

            return result;
        }
    }
}