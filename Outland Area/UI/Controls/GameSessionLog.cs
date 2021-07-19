using System;
using System.Linq;
using System.Windows.Forms;
using Engine.Layers.Tactical;
using Engine.Tools;
using log4net;

namespace Engine.UI.Controls
{
    public partial class GameSessionLog : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TacticalEnvironment _environment;
        private int _lastProcessedTurn;

        private const int RowsInLog = 2;

        public GameSessionLog()
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
            var newHistoryMessages = _environment.Session.TurnHistory.Where(message => message.Turn > _lastProcessedTurn && message.IsTechnicalLog == false);

            foreach (var message in newHistoryMessages)
            {
                var update = $"[{message.Turn}] {message.Message}";

                LogWrite(update);
            }

            crlWindowTitle.Text = $@"Game Log. Turn {_environment.Session.Turn}";

            _lastProcessedTurn = _environment.Session.Turn;
        }

        private delegate void SetTextCallback(string text);

        private void LogWrite(string message)
        {
            if (txtLog.InvokeRequired)
            {
                var d = new SetTextCallback(LogWrite);
                Invoke(d, message);
            }
            else
            {
                txtLog.Text = message + Environment.NewLine + txtLog.Text;

                if (txtLog.Lines.Length > RowsInLog)
                {
                    var newLines = new string[RowsInLog];

                    Array.Copy(txtLog.Lines, 0, newLines, 0, RowsInLog);

                    txtLog.Lines = newLines;
                }

                txtLog.Refresh();
            }
        }
    }
}
