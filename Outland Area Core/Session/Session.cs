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
    public class GameSession: IStatus
    {
        public SessionDTO Data { get; set; } = new SessionDTO();

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private protected StatusController Status = new StatusController();        

        public int Id { get; set; }

        public int Turn { get
            {
                return Data.Turn;
            } 
        }

        public void NextTurn()
        {
            Data.Turn++;
        }

        public Hashtable Commands { get; set; } = new Hashtable();

        public List<IScenarioEvent> ScenarioEvents { get; set; } = new List<IScenarioEvent>();
        
        public GameSession(SessionDTO data)
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

        #region IStatus implementation

        public void Resume() => Status.Resume();

        public void Pause() => Status.Pause();

        public bool IsPause => Status.IsPause;

        #endregion
    }
}
