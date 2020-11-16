using System.Collections.Generic;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace OutlandAreaCommon.Server.DataProcessing.CommandsExecute
{
    public class Movement
    {
        public CommandExecuteResult Execute(IEnumerable<ICelestialObject> objects, Command command)
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

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
