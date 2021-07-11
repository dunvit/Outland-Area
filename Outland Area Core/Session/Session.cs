using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EngineCore.Events;
using EngineCore.Universe.Characters;
using EngineCore.Universe.Model;
using log4net;

namespace EngineCore.Session
{
    [Serializable]
    public class GameSession: IStatus, IHistory
    {
        public SessionDTO Data { get; set; }

        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private protected StatusController Status = new StatusController();     
        
        private protected HistoryController History = new HistoryController();

        private protected CharactersCollection Characters = new CharactersCollection();

        public int Id { get; set; }

        

        public int Turn => Data.Turn;

        public void NextTurn()
        {
            _logger.Debug($"Before - {Turn} ");

            Data.Turn++;

            _logger.Debug($"After - {Turn} ");
        }

        public Hashtable Commands { get; set; } = new Hashtable();

        public List<IScenarioEvent> ScenarioEvents { get; set; } = new List<IScenarioEvent>();
        
        public GameSession(SessionDTO data)
        {
            Data = data;
        }

        public Character GetCharacter(long id)
        {
            if (Characters.IsExist(id) == false)
            {
                Characters.Add(new Character(Data.ScenarioName, id));
            }

            return Characters.Get(id);
        }

        public void AddEvent(GameEvent gameEvent)
        {
            gameEvent.Turn = Turn + 1;

            _logger.Info($"Add event.Turn = {gameEvent.Turn} Turn = {Turn}");

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

        public void AddHistoryMessage(GameSession session, string message, string className = "", bool isTechnicalLog = false)
        {
            History.AddHistoryMessage(this, message, className, isTechnicalLog);
        }

        public void AddHistoryMessage(string message, string className = "", bool isTechnicalLog = false)
        {
            AddHistoryMessage(this, message, className, isTechnicalLog);
        }
    }
}
