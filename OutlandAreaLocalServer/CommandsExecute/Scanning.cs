using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Scanning
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            Logger.Debug(TraceMessage.Execute(this, "Execute command scanning is started."));

            gameSession.AddHistoryMessage("started.", GetType().Name, true);

            if (Tools.RandomizeDice100() > RandomGenerator.BaseAsteroidChance)
            {
                Logger.Debug(TraceMessage.Execute(this,"Add new asteroid."));

                if (gameSession.IsRandomObjectsGeneration) 
                    gameSession.AddCelestialObject(RandomGenerator.Asteroid(gameSession));
            }

            return new CommandExecuteResult { Command = command, IsResume = false };
        }

        

    }
}
