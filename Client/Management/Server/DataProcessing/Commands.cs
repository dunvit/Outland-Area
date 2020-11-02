using System.Collections.Generic;
using System.Drawing;
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

            foreach (var command in gameSession.Commands)
            {
                switch (command.Type)
                {
                    case CommandTypes.MoveForward:
                        var executeMoveForwardResult = ExecuteMovementCommand(result.Map.CelestialObjects, command);

                        if (executeMoveForwardResult.IsResume)
                        {
                            result.Commands.Add(executeMoveForwardResult.Command.DeepClone());
                        }

                        break;

                    case CommandTypes.AlignTo:
                        var executeAlignToResult = ExecuteAlignTo(result, command);

                        if (executeAlignToResult.IsResume)
                        {
                            result.Commands.Add(executeAlignToResult.Command.DeepClone());
                        }
                        break;

                    case CommandTypes.Fire:
                        var executeFireResult = ExecuteFire(result, command);

                        if (executeFireResult.IsResume)
                        {
                            result.Commands.Add(executeFireResult.Command.DeepClone());
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

        private CommandExecuteResult ExecuteAlignTo(GameSession gameSession, Command command)
        {
            var isResume = true;

            var spaceShip = gameSession.GetPlayerSpaceShip();
            var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

            var pointCurrentLocation = new Point(spaceShip.PositionX, spaceShip.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);

            var result = Coordinates.GetTrajectoryApproach(pointCurrentLocation, pointTargetLocation, spaceShip.Direction, spaceShip.Speed, 200);

            foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            {
                if (mapCelestialObject.Id == spaceShip.Id)
                {
                    mapCelestialObject.Direction = result[1].Direction;
                }
            }

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }

        private CommandExecuteResult ExecuteFire(GameSession gameSession, Command command)
        {
            var isResume = true;

            var missile = gameSession.GetCelestialObject(command.CelestialObjectId);
            var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

            var pointCurrentLocation = new Point(missile.PositionX, missile.PositionY);
            var pointTargetLocation = new Point(targetObject.PositionX, targetObject.PositionY);

            var direction = Coordinates.GetRotation(pointTargetLocation, pointCurrentLocation);

            foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            {
                if (mapCelestialObject.Id == missile.Id)
                {
                    mapCelestialObject.Direction = direction;
                }
            }

            var distance = Coordinates.GetDistance(missile.GetLocation(), targetObject.GetLocation());

            if (distance <= missile.Speed)
            {
                var a = "";
            }

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
