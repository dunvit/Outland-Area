﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Engine.Gui.Controls.Common
{
    public partial class ActionButton : UserControl
    {
        public ActionButton()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public Image Picture
        {
            get => pictureBox1.Image;

            set
            {
                pictureBox1.Image = value;
                Refresh();
            }
        }

        private void borderImage_MouseEnter(object sender, EventArgs e)
        {
            borderImage.Image = Properties.Resources.BordersSelected;
        }

        private void borderImage_MouseLeave(object sender, EventArgs e)
        {
            borderImage.Image = Properties.Resources.BordersUnselected;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            borderImage.Image = Properties.Resources.BordersSelected;
        }
    }
}
