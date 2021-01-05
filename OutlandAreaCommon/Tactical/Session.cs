using System;
using System.Collections;
using System.Collections.Generic;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
{
    [Serializable]
    public class GameSession
    { 
        public int Id { get; set; }

        public int Turn { get; set; }

        public CelestialMap SpaceMap { get; set; }

        public List<Command> Commands { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();

        public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();

        public Hashtable History { get; set; } = new Hashtable();

        public ICelestialObject SelectedObject { get; set; }
    }
}
