using System;
using System.Collections.Generic;
using System.Linq;
using EngineCore.DataProcessing;
using EngineCore.Session;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;

namespace Engine.Tools
{
    public class OuterSpace
    {
        public event Action<int> OnChangeActiveObject;
        public event Action<int> OnChangeSelectedObject;

        private int activeObjectId;
        private int selectedObjectId;

        public void Refresh(GameSession gameSession, System.Drawing.PointF coordinates, int type)
        {
            var objectsInRange = GetCelestialObjectsByDistance(gameSession, coordinates);

            if (objectsInRange.Count == 0)
            {
                activeObjectId = 0;
                OnChangeActiveObject?.Invoke(activeObjectId);
                return;
            }

            var id = objectsInRange.First().Id;

            switch (type)
            {
                case 1:
                    if (selectedObjectId == id) return;
                    selectedObjectId = id;
                    OnChangeSelectedObject?.Invoke(id);
                    break;

                case 2:
                    if (activeObjectId == id) return;
                    activeObjectId = id;
                    OnChangeActiveObject?.Invoke(id);
                    break;
            }
        }

        public List<ICelestialObject> GetCelestialObjectsByDistance(GameSession gameSession, System.Drawing.PointF coordinates)
        {
            return gameSession.Data.CelestialObjects.Map(celestialObject => (celestialObject,
                        Coordinates.GetDistance(
                            coordinates,
                            celestialObject.GetLocation())
                    )).
                Where(e => e.Item2 < 20).
                OrderBy(e => e.Item2).
                Map(e => e.celestialObject).
                Where(celestialObject => celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).
                ToList();
        }
    }
}
