using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;

namespace EngineCore
{
    [Serializable]
    public class GameSession
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string ScenarioName { get; set; }

        public bool IsPause { get; set; }

        public int Id { get; set; }

        public int Turn { get; set; }

        //public CelestialMap SpaceMap { get; set; }

        //public Rules Rules { get; set; } = new Rules();

        //private Dialogs GameDialogs { get; set; }

        //public List<Command> Commands { get; set; }

        //public Characters Characters { get; set; } = new Characters();

        //public List<IScenarioEvent> ScenarioEvents { get; set; }

        //public List<GameEvent> GameEvents { get; set; } = new List<GameEvent>();

        //public List<HistoryMessage> TurnHistory { get; set; } = new List<HistoryMessage>();

        //public Hashtable History { get; set; } = new Hashtable();

        //public ICelestialObject SelectedObject { get; set; }

        //public void AddEvent(GameEvent gameEvent)
        //{
        //    gameEvent.Turn = Turn + 1;

        //    Logger.Info(TraceMessage.Execute(this, $"Add event.Turn = {gameEvent.Turn} Turn = {Turn}"));

        //    GameEvents.Add(gameEvent);
        //}

        //public List<GameEvent> GetTurnEvents(int turn)
        //{
        //    return GameEvents.Where(_ => _.Turn == turn).Map(message => message).ToList();
        //}

        //public List<GameEvent> GetCurrentTurnEvents()
        //{
        //    return GameEvents.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        //}


        //public List<IScenarioEvent> GetScenarioEvents()
        //{
        //    return ScenarioEvents.Where(_ => _.Turn == Turn).Map(message => message).ToList();
        //}

        //public Character GetCharacter(long id)
        //{
        //    if (Characters.IsExist(id) == false)
        //    {
        //        Characters.Add(new Character(ScenarioName, id));
        //    }

        //    return Characters.Get(id);
        //}

        //public DialogRowScheme GetDialogRow(long id)
        //{
        //    return GameDialogs.Get(id);
        //}

        //public void Initialization()
        //{
        //    GameDialogs = new Dialogs(ScenarioName);
        //}
    }
}
