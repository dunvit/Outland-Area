﻿using System;
using System.Windows.Forms;
using OutlandAreaLogic.DialogSystems.Schemes;
using Prototypes.Dialogs;

namespace Prototypes
{
    public partial class Form1 : Form, IDialogWindow
    {
        private readonly Manager _dialogsManager;

        public Form1()
        {
            _dialogsManager = new Manager {Container = this};
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private bool _isWindowActivated;

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (_isWindowActivated == false)
            {
                _dialogsManager.Show(637066561468000000);
                _isWindowActivated = true;
            }
        }

        public void Execute(DialogRowScheme dialogRow)
        {
            //panel1

            

            //panel1.Controls.Clear();

            var windowSimpleDialog = new WindowSimpleDialog(_dialogsManager);

            windowSimpleDialog.DrawDialogRow(dialogRow);

            windowSimpleDialog.TopLevel = false;
            windowSimpleDialog.AutoScroll = true;

            panel1.Controls.Add(windowSimpleDialog);
            windowSimpleDialog.Show();

            Control controlForRemove = null;

            if (panel1.Controls.Count == 2)
            {
                foreach (Control panel1Control in panel1.Controls)
                {
                    if (controlForRemove == null)
                    {
                        controlForRemove = panel1Control;
                    }
                }

                if (controlForRemove != null)
                {
                    panel1.Controls.Remove(controlForRemove);
                }
            }

            

            //windowSimpleDialog.ShowDialog(this);

                //_dialogsManager.Show(windowSimpleDialog.ExitId);
        }
    }

    
}
