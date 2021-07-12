using System;
using System.Linq;
using EngineCore.Session;

namespace Engine.Tools
{
    public class OuterSpace
    {
        public event Action<int> OnChangeActiveObject;
        public event Action<int> OnChangeSelectedObject;

        private int _activeObjectId;
        private int _selectedObjectId;

        public void Refresh(GameSession gameSession, System.Drawing.PointF coordinates, MouseArguments type)
        {
            var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

            if (objectsInRange.Count == 0)
            {
                if (_activeObjectId != 0)
                {
                    // Mouse left from active celestial object
                    OnChangeActiveObject?.Invoke(0);
                }

                _activeObjectId = 0;

                return;
            }

            var id = objectsInRange.First().Id;

            switch (type)
            {
                case MouseArguments.LeftClick:
                    if (_selectedObjectId == id) return;
                    _selectedObjectId = id;
                    OnChangeSelectedObject?.Invoke(id);
                    break;

                case MouseArguments.Move:
                    if (_activeObjectId == id) return;
                    _activeObjectId = id;
                    OnChangeActiveObject?.Invoke(id);
                    break;
            }
        }
    }
}
