﻿using System;
using System.Windows.Forms;
using log4net;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens
{
    public partial class BattleBoard : Form
    {
        private ICelestialObject currentCelestialObject;

        ILog log = LogManager.GetLogger(typeof(BattleBoard));

        public BattleBoard()
        {
            InitializeComponent();

            controlTacticalMap.Size = new System.Drawing.Size(1918, 1078);
            controlTacticalMap.OnMouseMoveCelestialObject += EventMouseMoveCelestialObject;
            controlTacticalMap.OnMouseLeaveCelestialObject += EventMouseLeaveCelestialObject;
            Manager.OnStartNewTurn += Event_StartNewTurn;
        }

        private void EventMouseMoveCelestialObject(ICelestialObject celestialObject)
        {
            currentCelestialObject = celestialObject;
            LogWrite("MouseMove_CelestialObject - " + celestialObject.Name);
        }

        private void EventMouseLeaveCelestialObject(ICelestialObject celestialObject)
        {
            if (currentCelestialObject != null)
            {
                LogWrite("MouseLeave_CelestialObject - " + currentCelestialObject.Name);
            }

            currentCelestialObject = null;
        }

        private void Event_StartNewTurn(Turn turn)
        {
            turnInformation1.Refresh(turn);
            controlTacticalMap.Refresh(turn);
        }

        private void Event_CloseApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_BoardLoad(object sender, EventArgs e)
        {
            Manager.FinishInitialization();
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
                txtLog.Text = DateTime.Now.ToString("HH:mm:ss") + @" - " + message + Environment.NewLine + txtLog.Text;

                if (txtLog.Lines.Length > 35)
                {
                    var newLines = new string[35];

                    Array.Copy(txtLog.Lines, 0, newLines, 0, 35);

                    txtLog.Lines = newLines;
                }

                txtLog.Refresh();

                log.Debug(message);
            }

        }
    }
}
