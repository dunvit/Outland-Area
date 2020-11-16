using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class AlignTo
    {
        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            const bool isResume = true;

            //var spaceShip = gameSession.GetPlayerSpaceShip();
            //var targetObject = gameSession.GetCelestialObject(command.TargetCelestialObjectId);
            //var result = new Trajectory.GetTrajectory().Approach(gameSession, spaceShip, targetObject);

            //foreach (var mapCelestialObject in gameSession.Map.CelestialObjects)
            //{
            //    if (mapCelestialObject.Id == spaceShip.Id)
            //    {
            //        if (result.Count > 1)
            //        {
            //            mapCelestialObject.Direction = result[1].Direction;
            //        }
            //    }
            //}

            return new CommandExecuteResult { Command = command, IsResume = isResume };
        }
    }
}
