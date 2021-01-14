using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class Scanning
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CommandExecuteResult Execute(GameSession gameSession, Command command)
        {
            gameSession.AddHistoryMessage("started.", GetType().Name, true);

            if (Tools.RandomizeDice100() > RandomGenerator.BaseAsteroidChance)
            {
                gameSession.AddCelestialObject(RandomGenerator.Asteroid(gameSession));
            }

            return new CommandExecuteResult { Command = command, IsResume = false };
        }

        

    }
}
