using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Scanning
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            Logger.Debug(TraceMessage.Execute(this, "Execute command scanning is started."));

            gameSession.AddHistoryMessage("started.", GetType().Name, true);

            if (RandomGenerator.DiceRoller() < gameSession.Rules.Spawn.AsteroidSmallSize)
            {
                Logger.Debug(TraceMessage.Execute(this,"Add new asteroid."));

                gameSession.AddCelestialObject(CelestialObjectsFactory.GenerateAsteroid(gameSession));
            }

            return new CommandExecuteResult { Command = command, IsResume = false };
        }

        

    }
}
