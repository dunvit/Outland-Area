using System;
using System.Collections.Generic;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace EngineCore.Scenario
{
    [Serializable]
    public class ScenarioEventGenerateNpcSpaceShip : ScenarioEventBase, IScenarioEvent
    {
        public int DialogId { get; set; }

        private List<NpcSpaceshipGenerationModel> _spaceShips;

        public ScenarioEventGenerateNpcSpaceShip(int dialogId)
        {
            DialogId = dialogId;

            _spaceShips = new List<NpcSpaceshipGenerationModel>();
        }

        public void AddSpaceShip(int spaceShipClass, int spaceShipType, int standing, string message)
        {
            _spaceShips.Add(new NpcSpaceshipGenerationModel(spaceShipClass, spaceShipType, standing, message));
        }

        public List<NpcSpaceshipGenerationModel> GetSpaceShips()
        {
            return _spaceShips.DeepClone();
        }

        public List<string> Execute(GameSession session)
        {
            var result = new List<string>();

            foreach (var spaceShip in _spaceShips)
            {
                var generatedSpaceShip =
                    CelestialObjectsFactory.GenerateNpcShip(session, spaceShip.SpaceShipClass, spaceShip.SpaceShipType, spaceShip.Standing);

                spaceShip.Message = $"Found spaceship. Engine signature is '{generatedSpaceShip.Id}'";

                result.Add(generatedSpaceShip.Id.ToString());

                session.CelestialObjects.Add(generatedSpaceShip);
            }

            return result;
        }
    }
}
