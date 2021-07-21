using System.Drawing;
using System.Reflection;
using Engine.Tools;
using Engine.UI;
using EngineCore.Session;
using EngineCore.Session.Actions;
using EngineCore.Universe.Model;
using log4net;

namespace Engine.Layers.Tactical
{
    public class TacticalEnvironment
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Session { get; private set; }

        public ModuleAction Action { get; private set; }

        public OuterSpace OuterSpaceTracker { get; } = new OuterSpace();

        public PointF MouseLocation { get; private set; } = new PointF(10000, 10000);

        public TacticalMode Mode { get; private set; } = TacticalMode.General;
        public TacticalMode PreviousMode { get; private set; } = TacticalMode.General;

        #region Local variables
        private int activeCelestialObjectId;
        #endregion

        public TacticalEnvironment()
        {
            OuterSpaceTracker.OnChangeActiveObject += Event_SetActiveObject;
            OuterSpaceTracker.OnChangeSelectedObject += Event_SetSelectedObject;
        }

        private void Event_SetSelectedObject(int obj)
        {
            if (Mode == TacticalMode.SelectingSpaceObjectWithActive)
            {
                Global.Game.ShowScreen("WindowOpenFire");
            }

        }

        private void Event_SetActiveObject(int celestialObjectId)
        {
            Logger.Info(celestialObjectId);

            activeCelestialObjectId = celestialObjectId;

            

            if (Mode != TacticalMode.General)
            {
                if (celestialObjectId > 0)
                {
                    PreviousMode = Mode;

                    Mode = TacticalMode.SelectingSpaceObjectWithActive;
                }
                else
                {
                    Mode = PreviousMode;
                }
            }
            
        }

        public ICelestialObject GetActiveObject()
        {
            return Session.GetCelestialObject(activeCelestialObjectId);
        }

        public PointF GetMouseCoordinates()
        {
            return OuterSpaceTracker.MouseCoordinates;
        }

        public void RefreshGameSession(GameSession session) => Session = session;

        public void SetAction(int moduleId, int actionId, TacticalMode mode)
        {

            Action = new ModuleAction(moduleId, actionId);

            Mode = mode;
            PreviousMode = mode;
        }

        public void SetMouseLocation(PointF location)
        {
            MouseLocation = location;
        }

        public void CancelAction()
        {
            Mode = TacticalMode.General;
        }
    }
}
