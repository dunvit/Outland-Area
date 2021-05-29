using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Universe.Model;
using log4net;
using Newtonsoft.Json.Linq;

namespace EngineCore.Session
{
    [Serializable]
    public class GameSession
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string ScenarioName { get; set; }

        public bool IsPause { get; set; }

        public int Id { get; set; }

        public int Turn { get; set; }

        public CelestialMap SpaceMap { get; set; }

        public Rules Rules { get; set; } = new Rules();

        public List<Command> Commands { get; set; } = new List<Command>();

        public List<IScenarioEvent> ScenarioEvents { get; set; }

        public List<GameEvent> GameEvents { get; set; } = new List<GameEvent>();

        public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();

        public void AddEvent(GameEvent gameEvent)
        {
            gameEvent.Turn = Turn + 1;

            Logger.Info($"Add event.Turn = {gameEvent.Turn} Turn = {Turn}");

            GameEvents.Add(gameEvent);
        }

        public void AddCommand(string commandBody)
        {
            Commands.Add(new Command(commandBody));
        }

        public List<Command> GetCommands(long Id)
        {
            return Commands.Where(_ => _.CelestialObjectId == Id).ToList();
        }

        public List<GameEvent> GetTurnEvents(int turn)
        {
            return GameEvents.Where(_ => _.Turn == turn).Map(message => message).ToList();
        }

        public List<GameEvent> GetCurrentTurnEvents()
        {
            return GameEvents.Where(_ => _.Turn + 5 > Turn).Map(message => message).ToList();
        }

        public List<IScenarioEvent> GetScenarioEvents()
        {
            return ScenarioEvents.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        }
    }
}
