using System.Collections.Generic;
using System.Drawing;
using OutlandAreaCommon;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer
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
                        //var executeMoveForwardResult = new Movement().Execute(result.Map.CelestialObjects, command);

                        //if (executeMoveForwardResult.IsResume)
                        //{
                        //    result.Commands.Add(executeMoveForwardResult.Command.DeepClone());
                        //}

                        break;

                    case CommandTypes.AlignTo:
                        var executeAlignToResult = new CommandsExecute.AlignTo().Execute(result, command);

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

                    case CommandTypes.Orbit:

                        //var a = new CommandsExecute.Orbit().Execute(result, command);

                        break;
                }
            }

            return result;
        }





        private CommandExecuteResult ExecuteFire(GameSession gameSession, Command command)
        {
            var isResume = true;

            var missile = gameSession.GetCelestialObject(command.CelestialObjectId);
            var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);

            if (missile == null) return new CommandExecuteResult { Command = command, IsResume = false };
            if (targetObject == null) return new CommandExecuteResult { Command = command, IsResume = false };

            var pointCurrentLocation = new PointF(missile.PositionX, missile.PositionY);
            var pointTargetLocation = new PointF(targetObject.PositionX, targetObject.PositionY);

            var direction = Coordinates.GetRotation(pointTargetLocation, pointCurrentLocation);

            foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            {
                if (mapCelestialObject.Id == missile.Id)
                {
                    mapCelestialObject.Direction = direction;
                }
            }

            var distance = Coordinates.GetDistance(missile.GetLocation(), targetObject.GetLocation());

            if (distance <= missile.Speed / 2)
            {
                // BOOM!!!
                gameSession.RemoveCelestialObject(missile);
            }

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
