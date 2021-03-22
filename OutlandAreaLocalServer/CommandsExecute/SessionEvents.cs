using System;
using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Tactical.Scenario;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships.NPC;

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
                        newGameEvent.DialogId = ((ScenarioEventGenerateNpcSpaceShip) scenarioEvent).DialogId;
                        newGameEvent.GenericObjects = ((ScenarioEventGenerateNpcSpaceShip)scenarioEvent).Execute(result);
                        //var npcSpaceShip = Fury.Generate(gameSession);
                        //gameSession.SpaceMap.CelestialObjects.Add(npcSpaceShip);
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
