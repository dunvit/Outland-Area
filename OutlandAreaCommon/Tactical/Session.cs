﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
{
    [Serializable]
    public class GameSession
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public int Id { get; set; }

        public int Turn { get; set; }

        public CelestialMap SpaceMap { get; set; }

        public List<Command> Commands { get; set; }

        private List<GameEvent> GameEvents { get; set; } = new List<GameEvent>();

        public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();

        public Hashtable History { get; set; } = new Hashtable();

        public ICelestialObject SelectedObject { get; set; }

        public void AddEvent(GameEvent gameEvent)
        {
            gameEvent.Turn = Turn + 1;

            Logger.Info(TraceMessage.Execute(this, $"Add event.Turn = {gameEvent.Turn} Turn = {Turn}"));

            GameEvents.Add(gameEvent);
        }

        public List<GameEvent> GetTurnEvents(int turn)
        {
            return GameEvents.Where(_ => _.Turn == turn).Map(message => message).ToList();
        }

        public List<GameEvent> GetCurrentTurnEvents()
        {
            return GameEvents.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        }
    }
}
