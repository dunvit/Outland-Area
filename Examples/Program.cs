using System;
using System.Windows.Forms;
using Autofac;
using Examples.Scheduler;

namespace Examples
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new GameManagerScheduler());
        }
    }
}
