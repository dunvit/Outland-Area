using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;

namespace Engine.UI.Controls
{
    public partial class GameSessionInformation : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TacticalEnvironment _environment;
        private const string MessageResume = "Resume";
        private const string MessagePause = "Pause";
        public GameSessionInformation()
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
            txtTurn.Text = _environment.Session.Turn + "";

            if (_environment.Session.IsPause)
            {
                if (cmdPauseResume.Text !=  MessageResume)
                {
                    cmdPauseResume.Text = MessageResume;
                }
            }
            else
            {
                if (cmdPauseResume.Text != MessagePause)
                {
                    cmdPauseResume.Text = MessagePause;
                }
            }
        }

        private void Event_ChangeGameStatus(object sender, System.EventArgs e)
        {
            if (_environment.Session.IsPause)
            {
                Global.Game.SessionResume();
            }
            else
            {
                Global.Game.SessionPause();
            }
        }

        private void Event_CloseApplication(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
