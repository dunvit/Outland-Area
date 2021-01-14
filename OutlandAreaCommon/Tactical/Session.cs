using System;
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

        private List<Message> Messages { get; set; } = new List<Message>();

        public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();

        public Hashtable History { get; set; } = new Hashtable();

        public ICelestialObject SelectedObject { get; set; }

        public void AddMessage(Message message)
        {
            message.Turn = Turn + 1;

            Logger.Info(TraceMessage.Execute(this, $"[AddMessage] message.Turn = {message.Turn} Turn = {Turn}"));

            Messages.Add(message);
        }

        public List<Message> GetTurnMessage(int turn)
        {
            return Messages.Where(_ => _.Turn == turn).Map(message => message).ToList();
        }

        public List<Message> GetCurrentTurnMessage()
        {
            return Messages.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        }
    }
}
