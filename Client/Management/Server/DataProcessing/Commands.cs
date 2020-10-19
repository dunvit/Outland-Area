using System.Collections.Generic;
using Engine.Layers.Tactical;
using Engine.Layers.Tactical.Objects.Spaceships;
using Engine.Tools;

namespace Engine.Management.Server.DataProcessing
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
            result.Commands = new List<Command>();

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

        private CommandExecuteResult ExecuteMovementCommand(IEnumerable<ICelestialObject> objects, Command command)
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
