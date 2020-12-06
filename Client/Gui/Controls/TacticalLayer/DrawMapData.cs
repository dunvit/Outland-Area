using System.Collections;
using System.Drawing;
using OutlandAreaCommon;
using OutlandAreaCommon.Tactical;

namespace Engine.Gui.Controls.TacticalLayer
{
    public class DrawMapData
    {
        private Hashtable celestialObjects;
        private GameSession gameSession;

        public PointF PositionFrom { get; set; }
        public PointF PositionTo { get; set; }

        public DrawMapData(GameSession previous, GameSession current)
        {
            var previousGameSession = previous.DeepClone();
            var currentGameSession = current.DeepClone();

            gameSession = current;

            celestialObjects = new Hashtable();

            foreach (var preCelestialObject in previousGameSession.SpaceMap.CelestialObjects)
            {
                foreach (var curCelestialObject in currentGameSession.SpaceMap.CelestialObjects)
                {
                    if (preCelestialObject.Id == curCelestialObject.Id)
                    {
                        var celestialObject = new DrawMapDataObject(preCelestialObject, curCelestialObject, current.Turn);

                        celestialObjects.Add(celestialObject.Id, celestialObject.DeepClone());

                        if (preCelestialObject.Id == 5005)
                        {
                            PositionFrom = new PointF(preCelestialObject.PositionX, preCelestialObject.PositionY);
                            PositionTo = new PointF(curCelestialObject.PositionX, curCelestialObject.PositionY);
                        }
                    }
                }
            }
        }

        public CelestialMap GetCelestialMap()
        {
            return gameSession.SpaceMap;
        }

        public Hashtable GetData()
        {
            return celestialObjects.DeepClone();
        }


    }
}
