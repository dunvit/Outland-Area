using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EngineCore.DTO;
using EngineCore.Events;
using EngineCore.Scenario;
using EngineCore.Tools;
using EngineCore.Universe.Characters;
using EngineCore.Universe.Model;
using log4net;

namespace EngineCore.Session
{
    [Serializable]
    public class GameSession: IStatus, IHistory, ISessionData
    {
        private SessionData Data { get; set; } = new SessionData();

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private protected StatusController Status = new StatusController();     
        
        private protected HistoryController History = new HistoryController();

        private protected CharactersCollection Characters = new CharactersCollection();

        public int Id { get; set; }

        public List<ICelestialObject> GetCelestialObjects() => Data.CelestialObjects;

        public List<HistoryMessage> GetTurnHistory() => Data.TurnHistory;

        public void NextTurn()
        {
            Logger.Debug($"Before - {Data.Turn} ");

            Data.Turn++;

            Logger.Debug($"After - {Data.Turn} ");
        }

        public Hashtable Commands { get; set; } = new Hashtable();

        public List<IScenarioEvent> ScenarioEvents { get; set; } = new List<IScenarioEvent>();
        
        public GameSession(SessionData data)
        {
            Data = data;

            if (Data.IsPause)
            {
                Status.Pause();
            }
            else
            {
                Status.Resume();
            }
        }

        public GameSession(SessionDataDto data)
        {
            Data = ToSessionData(data);

            if (Data.IsPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
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
            gameEvent.Turn = Data.Turn + 1;

            Logger.Info($"Add event.Turn = {gameEvent.Turn} Turn = {Data.Turn}");

            Data.GameEvents.Add(gameEvent);
        }

        public List<IScenarioEvent> GetScenarioEvents()
        {
            return ScenarioEvents.Where(_ => _.Turn == Data.Turn).Map(message => message).ToList();
        }

        #region IStatus implementation

        public void Resume() => Status.Resume();
        public void Pause() => Status.Pause();
        public bool IsPause => Status.IsPause;

        #endregion

        #region ISessionData implementation

        public int Turn => Data.Turn;
        public string ScenarioName => Data.ScenarioName;
        public Rules Rules => Data.Rules;
        public List<GameEvent> GameEvents => Data.GameEvents;
        public List<HistoryMessage> TurnHistory => Data.TurnHistory;
        public List<ICelestialObject> CelestialObjects => Data.CelestialObjects;

        #endregion

        public void AddHistoryMessage(GameSession session, string message, string className = "", bool isTechnicalLog = false)
        {
            History.AddHistoryMessage(this, message, className, isTechnicalLog);
        }

        public void AddHistoryMessage(string message, string className = "", bool isTechnicalLog = false)
        {
            AddHistoryMessage(this, message, className, isTechnicalLog);
        }

        public void SetScenarioName(string name) => Data.ScenarioName = name;

        public SessionDataDto ToSessionTransfer()
        {
            var data = new SessionDataDto
            {
                Turn = Data.Turn,
                ScenarioName = Data.ScenarioName,
                IsPause = IsPause,
                Rules = Data.Rules.DeepClone(),
                CelestialObjects = DataProcessing.Convert.VisibilityAreaFilter(this).DeepClone(),
                TurnHistory = Data.TurnHistory.DeepClone(),
                GameEvents = Data.GameEvents.DeepClone()
            };

            return data;
        }

        public SessionData ToSessionData(SessionDataDto data)
        {
            var sessionData = new SessionData
            {
                Turn = data.Turn,
                ScenarioName = data.ScenarioName,
                IsPause = data.IsPause,
                Rules = data.Rules,
                CelestialObjects = data.CelestialObjects,
                TurnHistory = data.TurnHistory,
                GameEvents = data.GameEvents
            };

            return sessionData;
        }

        public SessionData Clone()
        {
            return ToSessionData(ToSessionTransfer());
        }
    }
}
