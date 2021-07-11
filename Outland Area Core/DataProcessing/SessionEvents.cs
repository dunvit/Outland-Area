using System;
using System.Reflection;
using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Session;
using log4net;

namespace EngineCore.DataProcessing
{
    public class SessionEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execute(GameSession gameSession)
        {
            gameSession.AddHistoryMessage($"SessionEvents started.", GetType().Name, true);

            var result = gameSession;

            if (gameSession.Data.Rules.IsEventsEnabled == false)
            {
                gameSession.AddHistoryMessage("SessionEvents canceled by scenario configuration.", GetType().Name, true);

                return result;
            }

            foreach (var scenarioEvent in gameSession.GetScenarioEvents())
            {
                Logger.Debug($"Found scenario event (id={scenarioEvent.Id}.");

                var newGameEvent = new GameEvent();

                switch (scenarioEvent.Type)
                {
                    case GameEventTypes.AnomalyFound:
                        break;
                    case GameEventTypes.OpenDialog:
                        newGameEvent.Type = GameEventTypes.OpenDialog;
                        newGameEvent.DialogId = scenarioEvent.ToScenarioEventDialog().DialogId;
                        break;
                    case GameEventTypes.NpcSpaceShipFound:
                        newGameEvent.Type = GameEventTypes.NpcSpaceShipFound;
                        newGameEvent.DialogId = ((ScenarioEventGenerateNpcSpaceShip)scenarioEvent).DialogId;
                        newGameEvent.GenericObjects = ((ScenarioEventGenerateNpcSpaceShip)scenarioEvent).Execute(result);
                        break;
                    case GameEventTypes.WreckSpaceShipFound:
                        newGameEvent.Type = GameEventTypes.WreckSpaceShipFound;
                        newGameEvent.DialogId = ((ScenarioEventGenerateNpcSpaceShip)scenarioEvent).DialogId;
                        newGameEvent.GenericObjects = ((ScenarioEventGenerateNpcSpaceShip)scenarioEvent).Execute(result);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                newGameEvent.Turn = gameSession.Turn + 1;

                newGameEvent.IsPause = true;
                newGameEvent.IsOpenWindow = true;

                result.AddEvent(newGameEvent);
            }

            return result;
        }
    }
}
