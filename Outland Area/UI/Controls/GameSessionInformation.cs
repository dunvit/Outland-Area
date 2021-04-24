using System.Windows.Forms;
using Engine.Tools;
using EngineCore;
using EngineCore.Session;

namespace Engine.UI.Controls
{
    public partial class GameSessionInformation : UserControl
    {
        private GameSession _gameSession;
        private const string MessageResume = "Resume";
        private const string MessagePause = "Pause";
        public GameSessionInformation()
        {
            InitializeComponent();

            if (Global.Game != null)
                Global.Game.OnEndTurn += Event_EndTurn;
        }

        private void Event_EndTurn(GameSession gameSession)
        {
            _gameSession = gameSession;
            this.PerformSafely(RefreshControl);
        }

        private void RefreshControl()
        {
            txtTurn.Text = _gameSession.Turn + "";

            if (_gameSession.IsPause)
            {
                if (cmdPauseResume.Text != MessageResume)
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
            if (_gameSession.IsPause)
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
