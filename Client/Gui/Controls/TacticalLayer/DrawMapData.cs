using System.Collections;
using System.Drawing;
using Engine.Layers.Tactical;
using Engine.Tools;

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

            if (previous.Turn != current.Turn)
            {
                var a = "";
            }

            gameSession = current;

            celestialObjects = new Hashtable();

            foreach (var preCelestialObject in previousGameSession.Map.CelestialObjects)
            {
                foreach (var curCelestialObject in currentGameSession.Map.CelestialObjects)
                {
                    if (preCelestialObject.Id == curCelestialObject.Id)
                    {
                        //var weyPoints = new Hashtable();

                        //for (int i = 0; i < 10; i++)
                        //{
                        //    var weyPointCelestialObject = new DrawMapDataObject(preCelestialObject, curCelestialObject, current.Turn, i).CelestialObject;

                        //    weyPoints.Add(i, weyPointCelestialObject);
                        //}

                        //celestialObjects.Add(current.Turn, weyPoints);

                        var celestialObject = new DrawMapDataObject(preCelestialObject, curCelestialObject, current.Turn);

                        celestialObjects.Add(celestialObject.Id, celestialObject.DeepClone());

                        if (preCelestialObject.Id == 5005)
                        {
                            PositionFrom = new PointF(preCelestialObject.PositionX, preCelestialObject.PositionY);
                            PositionTo = new PointF(curCelestialObject.PositionX, curCelestialObject.PositionY);

                            if (currentGameSession.Turn == 2)
                            {
                                var a = "";
                            }
                        }
                    }
                }
            }
        }

        public CelestialMap GetCelestialMap()
        {
            return gameSession.Map;
        }

        public Hashtable GetData()
        {
            return celestialObjects.DeepClone();
        }
    }
}
