using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;

namespace Engine.UI.Controls
{
    public partial class ActiveCelestialObject : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TacticalEnvironment _environment;

        public ActiveCelestialObject()
        {
            InitializeComponent();

            if (Global.Game != null)
                Global.Game.OnEndTurn += Event_EndTurn;
        }

        private void Event_EndTurn(TacticalEnvironment environment)
        {
            _environment = environment;

            Logger.Debug($"Refresh game information for turn '{_environment.Session.Turn}'.");

            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            var activeCelestialObject = _environment.GetActiveObject();

            txtInfo.Text = activeCelestialObject != null ? $@"Active object id is {_environment.GetActiveObject().Id}" : "";
        }
    }
}
