using System.Collections;
using System.Collections.Generic;
using Engine.Common.Geometry;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Geometry;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;


namespace OutlandAreaCommon.Universe.Objects
{
    public class MovementLog
    {
        private Hashtable _movementHistory = new Hashtable();
        private readonly int _historyBufferSize;

        public MovementLog(int bufferSize = 2000)
        {
            _historyBufferSize = bufferSize;
        }

        public List<SpaceMapObjectLocation> GetHistoryForCelestialObject(int id)
        {
            return _movementHistory.ContainsKey(id) == false ? 
                new List<SpaceMapObjectLocation>() 
                : ((FixedSizedQueue< SpaceMapObjectLocation >)_movementHistory[id]).GetData();
        }

        public void Update(GameSession gameSession)
        {
            if(gameSession == null) return;

            foreach (var mapCelestialObject in gameSession.SpaceMap.CelestialObjects)
            {
                _movementHistory = EnqueueMovementHistory(mapCelestialObject, _movementHistory);
            }
        }

        private Hashtable EnqueueMovementHistory(ICelestialObject mapCelestialObject, Hashtable allObjectsHistory)
        {

            var previousIteration = new SpaceMapObjectLocation
            {
                Distance = SpaceMapTools.GetDistance(mapCelestialObject.GetLocation(), mapCelestialObject.GetLocation()),
                Direction = mapCelestialObject.Direction,
                Status = MovementType.Linear,
                Coordinates = mapCelestialObject.GetLocation()
            };

            if (allObjectsHistory.ContainsKey(mapCelestialObject.Id) == false)
            {
                // New celestial object in history collection
                var initialIteration = new SpaceMapObjectLocation
                {
                    Distance = SpaceMapTools.GetDistance(mapCelestialObject.GetLocation(), mapCelestialObject.GetLocation()),
                    Direction = mapCelestialObject.Direction,
                    Status = MovementType.Linear,
                    Coordinates = Coordinates.MoveObject(mapCelestialObject.GetLocation(), 2000,
                        (mapCelestialObject.Direction - 180).To360Degrees())
                };

                var initialHistory = new FixedSizedQueue<SpaceMapObjectLocation>(_historyBufferSize);

                initialHistory.Enqueue(initialIteration);

                initialHistory.Enqueue(previousIteration);

                allObjectsHistory.Add(mapCelestialObject.Id, initialHistory);

                return allObjectsHistory;
            }

            // Add new history point to exist celestial object movement history

            if (!(allObjectsHistory[mapCelestialObject.Id] is FixedSizedQueue<SpaceMapObjectLocation> currentObjectMovementHistory)) return allObjectsHistory;

            currentObjectMovementHistory.Enqueue(previousIteration);
            
            allObjectsHistory[mapCelestialObject.Id] = currentObjectMovementHistory;

            return allObjectsHistory;
        }
    }
}
