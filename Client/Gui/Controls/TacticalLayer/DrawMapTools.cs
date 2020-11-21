using System.Collections.Generic;
using System.Drawing;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer
{
    public class DrawMapTools
    {
        public static PointF GetCurrentLocation(SortedDictionary<int, GranularObjectInformation> granularTurnInformation, ICelestialObject celestialObject, int turnStep, int drawInterval)
        {
            try
            {
                return granularTurnInformation[celestialObject.Id].WayPoints[turnStep];
            }
            catch
            {
                try
                {
                    try
                    {
                        return granularTurnInformation[celestialObject.Id].WayPoints[drawInterval - 1];
                    }
                    catch
                    {
                        try
                        {
                            return granularTurnInformation[celestialObject.Id].WayPoints[drawInterval - 2];
                        }
                        catch 
                        {
                            return granularTurnInformation[celestialObject.Id].WayPoints[drawInterval - 3];
                        }
                    }
                }
                catch
                {
                    return PointF.Empty;
                }
            }
        }
    }
}
