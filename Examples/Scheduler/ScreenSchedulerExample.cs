using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Forms;


namespace Examples.Scheduler
{
    public partial class ScreenSchedulerExample : Form
    {
        private static readonly Random Random = new Random((int) DateTime.UtcNow.Ticks);
        private static readonly ConcurrentDictionary<long, string> GameTurnsCollection = new ConcurrentDictionary<long, string>();

        public ScreenSchedulerExample()
        {
            InitializeComponent();
        }

        private void ScreenSchedulerExample_Load(object sender, EventArgs e)
        {
            LogWrite($"Scheduler started. Delay is ${5000} milliseconds.");

            OutlandArea.BL.TaskScheduler.Instance.ScheduleTask(5000, 200, Task, LogWrite);
        }

        private int _turn = 0;

        private void Task()
        {
            var cell = Random.Next(10);

            GameTurnsCollection.AddOrUpdate(cell, "value is " + cell, (key, oldValue) => "value is " + cell);

            Thread.Sleep(500);

            LogWrite($"Task runner. Cell ${cell}");
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
    }
}
