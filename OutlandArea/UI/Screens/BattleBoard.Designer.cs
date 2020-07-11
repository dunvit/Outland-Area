namespace OutlandArea.UI.Screens
{
    partial class BattleBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdNavigation = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton2 = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton5 = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton3 = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton6 = new OutlandAreaLogic.Controls.OaButton();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.commandClose = new OutlandAreaLogic.Controls.OaButton();
            this.controlNavigationCommands = new OutlandArea.UI.Screens.BattleBoardControls.NavigationCommands();
            this.turnInformation1 = new OutlandArea.UI.Screens.BattleBoardControls.TurnInformation();
            this.controlTacticalMap = new OutlandArea.UI.Screens.BattleBoardControls.TacticalMap();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.oaButton6);
            this.panel1.Controls.Add(this.turnInformation1);
            this.panel1.Controls.Add(this.controlTacticalMap);
            this.panel1.Controls.Add(this.commandClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1080);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdNavigation);
            this.panel2.Controls.Add(this.oaButton2);
            this.panel2.Controls.Add(this.controlNavigationCommands);
            this.panel2.Controls.Add(this.oaButton5);
            this.panel2.Controls.Add(this.oaButton3);
            this.panel2.Location = new System.Drawing.Point(1409, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 438);
            this.panel2.TabIndex = 7;
            // 
            // cmdNavigation
            // 
            this.cmdNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdNavigation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdNavigation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdNavigation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNavigation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cmdNavigation.Location = new System.Drawing.Point(3, 3);
            this.cmdNavigation.Name = "cmdNavigation";
            this.cmdNavigation.Size = new System.Drawing.Size(120, 23);
            this.cmdNavigation.TabIndex = 5;
            this.cmdNavigation.Text = "Navigation";
            this.cmdNavigation.UseVisualStyleBackColor = false;
            this.cmdNavigation.Click += new System.EventHandler(this.Event_ShowNavigationCommandsControl);
            // 
            // oaButton2
            // 
            this.oaButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.oaButton2.Location = new System.Drawing.Point(129, 3);
            this.oaButton2.Name = "oaButton2";
            this.oaButton2.Size = new System.Drawing.Size(120, 23);
            this.oaButton2.TabIndex = 5;
            this.oaButton2.Text = "Weapon C1";
            this.oaButton2.UseVisualStyleBackColor = false;
            // 
            // oaButton5
            // 
            this.oaButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.oaButton5.Location = new System.Drawing.Point(381, 3);
            this.oaButton5.Name = "oaButton5";
            this.oaButton5.Size = new System.Drawing.Size(120, 23);
            this.oaButton5.TabIndex = 5;
            this.oaButton5.Text = "Engineering";
            this.oaButton5.UseVisualStyleBackColor = false;
            // 
            // oaButton3
            // 
            this.oaButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.oaButton3.Location = new System.Drawing.Point(255, 3);
            this.oaButton3.Name = "oaButton3";
            this.oaButton3.Size = new System.Drawing.Size(120, 23);
            this.oaButton3.TabIndex = 5;
            this.oaButton3.Text = "Weapon C2";
            this.oaButton3.UseVisualStyleBackColor = false;
            // 
            // oaButton6
            // 
            this.oaButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton6.ForeColor = System.Drawing.Color.Gold;
            this.oaButton6.Location = new System.Drawing.Point(1412, 9);
            this.oaButton6.Name = "oaButton6";
            this.oaButton6.Size = new System.Drawing.Size(498, 23);
            this.oaButton6.TabIndex = 6;
            this.oaButton6.Text = "Compartments";
            this.oaButton6.UseVisualStyleBackColor = false;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.Location = new System.Drawing.Point(11, 499);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(336, 221);
            this.txtLog.TabIndex = 2;
            // 
            // commandClose
            // 
            this.commandClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.commandClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandClose.Location = new System.Drawing.Point(1790, 1044);
            this.commandClose.Name = "commandClose";
            this.commandClose.Size = new System.Drawing.Size(117, 23);
            this.commandClose.TabIndex = 0;
            this.commandClose.Text = "Close";
            this.commandClose.UseVisualStyleBackColor = false;
            this.commandClose.Click += new System.EventHandler(this.Event_CloseApplication);
            // 
            // controlNavigationCommands
            // 
            this.controlNavigationCommands.BackColor = System.Drawing.Color.Black;
            this.controlNavigationCommands.Location = new System.Drawing.Point(4, 32);
            this.controlNavigationCommands.Manager = null;
            this.controlNavigationCommands.Name = "controlNavigationCommands";
            this.controlNavigationCommands.Size = new System.Drawing.Size(500, 400);
            this.controlNavigationCommands.SpacecraftId = ((long)(0));
            this.controlNavigationCommands.TabIndex = 4;
            this.controlNavigationCommands.Visible = false;
            // 
            // turnInformation1
            // 
            this.turnInformation1.BackColor = System.Drawing.Color.Black;
            this.turnInformation1.Location = new System.Drawing.Point(11, 12);
            this.turnInformation1.Manager = null;
            this.turnInformation1.Name = "turnInformation1";
            this.turnInformation1.Size = new System.Drawing.Size(336, 384);
            this.turnInformation1.TabIndex = 3;
            // 
            // controlTacticalMap
            // 
            this.controlTacticalMap.BackColor = System.Drawing.Color.Black;
            this.controlTacticalMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlTacticalMap.Location = new System.Drawing.Point(0, 0);
            this.controlTacticalMap.Manager = null;
            this.controlTacticalMap.Margin = new System.Windows.Forms.Padding(6);
            this.controlTacticalMap.Name = "controlTacticalMap";
            this.controlTacticalMap.Size = new System.Drawing.Size(1918, 1078);
            this.controlTacticalMap.TabIndex = 1;
            // 
            // BattleBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BattleBoard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BattleBoard";
            this.Load += new System.EventHandler(this.Event_BoardLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OutlandAreaLogic.Controls.OaButton commandClose;
        private BattleBoardControls.TacticalMap controlTacticalMap;
        private BattleBoardControls.TurnInformation turnInformation1;
        private System.Windows.Forms.TextBox txtLog;
        private OutlandAreaLogic.Controls.OaButton oaButton2;
        private OutlandAreaLogic.Controls.OaButton cmdNavigation;
        private BattleBoardControls.NavigationCommands controlNavigationCommands;
        private OutlandAreaLogic.Controls.OaButton oaButton6;
        private OutlandAreaLogic.Controls.OaButton oaButton5;
        private OutlandAreaLogic.Controls.OaButton oaButton3;
        private System.Windows.Forms.Panel panel2;
    }
}