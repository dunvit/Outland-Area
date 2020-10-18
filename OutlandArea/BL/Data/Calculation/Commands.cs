using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using OutlandArea.Map;
using OutlandArea.Map.Objects;
using OutlandArea.Tools;

namespace OutlandArea.BL.Data.Calculation
{
    public class Commands
    {
        public GameSession Execute(GameSession gameSession)
        {
            var result = gameSession.DeepClone();

            if (gameSession.Commands == null)
            {
                // Commands pool is empty. No need execute action.
                return result;
            }

            // Clear commands pool
            result.Commands = new List<GameCommand>();

            foreach (var gameSessionCommand in gameSession.Commands)
            {
                switch (gameSessionCommand.CommandTypeId)
                {
                    case 1:
                        var executeResult = ExecuteMovementCommand(result.Map.CelestialObjects, gameSessionCommand);

                        if (executeResult.IsResume)
                        {
                            result.Commands.Add(executeResult.Command);
                        }

                        break;
                }
            }


            return result;
        }

        private CommandExecuteResult ExecuteMovementCommand(IEnumerable<ICelestialObject> objects, GameCommand command)
        {
            var isResume = true;

            foreach (var celestialObject in objects)
            {
                if (celestialObject.Id == command.CelestialObjectId && celestialObject is Spaceship)
                {
                    if ((celestialObject as Spaceship).Speed < (celestialObject as Spaceship).MaxSpeed)
                    {
                        celestialObject.Speed += 1;
                    }
                    else
                    {
                        isResume = false;
                    }
                }
            }

            return new CommandExecuteResult{Command = command, IsResume = isResume};
        }

        
    }
}
