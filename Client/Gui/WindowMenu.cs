﻿using System;
using System.Windows.Forms;

namespace Engine.Gui
{
    public partial class WindowMenu : Form
    {
        public WindowMenu()
        {
            InitializeComponent();
        }

        private void Event_ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
