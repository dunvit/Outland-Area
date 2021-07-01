using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EngineCore.Events;
using EngineCore.Universe.Model;
using log4net;

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
        
        public GameSession(SessionData data)
        {
            Data = data;
        }

        public void AddEvent(GameEvent gameEvent)
        {
            gameEvent.Turn = Turn + 1;

            Logger.Info($"Add event.Turn = {gameEvent.Turn} Turn = {Turn}");

            Data.GameEvents.Add(gameEvent);
        }

        public List<IScenarioEvent> GetScenarioEvents()
        {
            return ScenarioEvents.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        }
    }
}
