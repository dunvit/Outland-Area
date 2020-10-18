using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OutlandArea.TacticalBattleLayer.Commands;
using OutlandArea.Tools;

namespace OutlandArea.TacticalBattleLayer
{
    public class Battle
    {
        public Action<string> Logger;

        public event Action OnChangeInformation;

        public int Turn { get; private set; }

        public State State { get; private set; }

        public ICelestialObject Spacecraft { get; private set; }

        public List<ICelestialObject> CelestialObjects { get; private set; }

        public Battle()
        {
            Initialization();
        }

        private void Initialization()
        {
            Turn = 1;
            State = State.Preparation;
            CelestialObjects = new List<ICelestialObject>();
        }

        public void InitializationCoreSpacecraft(ICelestialObject spacecraft)
        {
            Spacecraft = spacecraft;
        }
        public void AddCelestialObjects(ICelestialObject celestialObject)
        {
            CelestialObjects.Add(celestialObject);
        }

        private ICelestialObject GetCelestialObject(long id)
        {
            foreach (var celestialObject in CelestialObjects.Where(celestialObject => celestialObject.Id == id))
            {
                return celestialObject;
            }

            throw new Exception("Celestial object not found.");
        }

        internal void EndTurn(List<ICommand> commands)
        {
            if (Turn > 0)
            {
                RecalculateCelestialObjectsPositions(commands);

                Logger?.Invoke($"[Battle] End turn. New turn is {Turn}");
            }
            else
            {
                Logger?.Invoke("[Battle] Everything is prepared to start the battle.");
            }

            Turn++;

            OnChangeInformation?.Invoke();
        }

        private void RecalculateCelestialObjectsPositions(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                if (command is Navigation navigation)
                {
                    var celestialObject = GetCelestialObject(command.SpacecraftId);

                    celestialObject.Velocity += navigation.Request.VelocityDelta;
                    celestialObject.Direction += navigation.Request.DirectionDelta;
                }
            }

            foreach (var spacecraft in CelestialObjects.Where(celestialObject => celestialObject is BaseSpacecraft))
            {
                spacecraft.LocationInLastTurn = spacecraft.Location;

                spacecraft.Location = Common.MoveCelestialObjects(spacecraft.Location, spacecraft.Velocity / 10, spacecraft.Direction);

                Logger?.Invoke($"[Battle] Spacecraft id='{spacecraft.Id}' moved from ({spacecraft.LocationInLastTurn.X},{spacecraft.LocationInLastTurn.Y}) to ({spacecraft.Location.X},{spacecraft.Location.Y})");
            }
        }

        
    }
}
