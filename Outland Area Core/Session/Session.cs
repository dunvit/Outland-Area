using System;
using System.Collections;
using System.Collections.Concurrent;
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
        public SessionData Data { get; set; } = new SessionData();

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string ScenarioName { get; set; }

        public bool IsPause { get; set; }

        public int Id { get; set; }

        public int Turn { get; set; }        

        public Hashtable Commands { get; set; } = new Hashtable();

        public List<IScenarioEvent> ScenarioEvents { get; set; }

        

        public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();        

        public void AddEvent(GameEvent gameEvent)
        {
            gameEvent.Turn = Turn + 1;

            Logger.Info($"Add event.Turn = {gameEvent.Turn} Turn = {Turn}");

            Data.GameEvents.Add(gameEvent);
        }

        //public void AddCommand(string commandBody)
        //{
        //    Commands.Add(new Command(commandBody));
        //}

        public List<Command> GetCommands(long Id)
        {
            return (from Command command in Commands.Values select command).ToList();
        }

        public List<GameEvent> GetTurnEvents(int turn)
        {
            return Data.GameEvents.Where(_ => _.Turn == turn).Map(message => message).ToList();
        }

        public List<GameEvent> GetCurrentTurnEvents()
        {
            return Data.GameEvents.Where(_ => _.Turn + 5 > Turn).Map(message => message).ToList();
        }

        public List<IScenarioEvent> GetScenarioEvents()
        {
            return ScenarioEvents.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        }
    }
}
