﻿using System;
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
    public class GameSession: IStatus, IHistory
    {
        public SessionDTO Data { get; set; }

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private protected StatusController Status = new StatusController();     
        
        private protected HistoryController History = new HistoryController();

        public int Id { get; set; }

        public int Turn => Data.Turn;

        public void NextTurn()
        {
            Logger.Debug($"[{GetType().Name}][IStatus] Before - {Turn} ");

            Data.Turn++;

            Logger.Debug($"[{GetType().Name}][IStatus] After - {Turn} ");
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
