using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaLocalServer.CommandsExecute
{
    public class SessionEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execute(GameSession gameSession)
        {
            gameSession.AddHistoryMessage($"SessionEvents started.", GetType().Name, true);

            var result = gameSession.DeepClone();

            if (gameSession.Rules.IsEventsEnabled == false)
            {
                gameSession.AddHistoryMessage("SessionEvents canceled by scenario configuration.", GetType().Name, true);

                return result;
            }

            foreach (var scenarioEvent in gameSession.GetScenarioEvents())
            {
                Logger.Debug($"Found scenario event (id={scenarioEvent.Id}.");

                var newGameEvent = new GameEvent
                {
                    Turn = gameSession.Turn + 1,
                    Type = GameEventTypes.OpenDialog,
                    IsPause = true,
                    IsOpenWindow = true,
                    DialogId = scenarioEvent.ToScenarioEventDialog().DialogId
                };

                result.AddEvent(newGameEvent);
            }

            return result;
        }
    }
}
