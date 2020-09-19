using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlandArea;

namespace Examples.Scheduler
{
    public partial class GameManagerScheduler : Form
    {
        private GameManager _gameManager;

        public GameManagerScheduler()
        {
            InitializeComponent();
        }

        private void GameManagerScheduler_Load(object sender, EventArgs e)
        {
            _gameManager = new GameManager();

            //_gameManager.OnRefreshMap += Event_RefreshMap;
            var result = _gameManager.Initialization(LogWrite);
        }

        #region Write log to text box
        private delegate void SetTextCallback(string text);

        private void LogWrite(string message)
        {
            if (textBox1.InvokeRequired)
            {
                var d = new SetTextCallback(LogWrite);
                Invoke(d, message);
            }
            else
            {
                textBox1.Text = DateTime.Now.ToString("HH:mm:ss:ffff") + @" - " + message + Environment.NewLine + textBox1.Text;

                if (textBox1.Lines.Length > 35)
                {
                    var newLines = new string[35];

                    Array.Copy(textBox1.Lines, 0, newLines, 0, 35);

                    textBox1.Lines = newLines;
                }

                textBox1.Refresh();

            }

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            _gameManager.ResumeSession();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _gameManager.PauseSession();
        }
    }
}
