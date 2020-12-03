using System;
using System.Windows.Forms;
using Engine.Tools;
using OutlandAreaCommon.Tactical;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class BattleInformation : UserControl
    {
        public BattleInformation()
        {
            InitializeComponent();

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnEndTurn += CalculateTurnInformation;
        }

        private void CalculateTurnInformation(GameSession gameSession)
        {
            foreach (var eventInBattle in gameSession.History)
            {
                Invoke(new MethodInvoker(delegate () {
                    txtLog.Text += $"Turn {gameSession.Turn} \t {eventInBattle}" + Environment.NewLine;
                }));
            }
        }

        private int _height;

        private void ChangeVisibilityMode(object sender, EventArgs e)
        {
            if (Height > crlTitlebar.Height)
            {
                _height = Height;
                Height = crlTitlebar.Height;
            }
            else
            {
                Height = _height;
            }
        }
    }
}
