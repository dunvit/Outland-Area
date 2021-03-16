using System;
using System.Collections.Generic;
using OutlandAreaCommon.Tactical.Model;

namespace OutlandAreaCommon.Tactical.Scenario
{
    [Serializable]
    public class ScenarioEventGenerateNpcSpaceShip : ScenarioEventBase, IScenarioEvent
    {
        public int DialogId { get; set; }

        private List<Tuple<int, int, int, string>> _spaceShips;

        public ScenarioEventGenerateNpcSpaceShip(int dialogId)
        {
            DialogId = dialogId;

            _spaceShips = new List<Tuple<int, int, int, string>>();
        }

        public void AddSpaceShip(int spaceShipClass, int spaceShipType, int standing, string message)
        {
            _spaceShips.Add(new Tuple<int, int, int, string>(spaceShipClass, spaceShipType, standing, message));
        }

        public List<Tuple<int, int, int, string>> GetSpaceShips()
        {
            return _spaceShips.DeepClone();
        }

        public void Execute(GameSession session)
        {
            throw new NotImplementedException();
        }
    }
}
