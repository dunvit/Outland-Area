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
            this.tacticalMap1 = new OutlandArea.UI.Screens.BattleBoardControls.TacticalMap();
            this.commandClose = new OutlandAreaLogic.Controls.OaButton();
            this.turnInformation1 = new OutlandArea.UI.Screens.BattleBoardControls.TurnInformation();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.turnInformation1);
            this.panel1.Controls.Add(this.tacticalMap1);
            this.panel1.Controls.Add(this.commandClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1080);
            this.panel1.TabIndex = 0;
            // 
            // tacticalMap1
            // 
            this.tacticalMap1.BackColor = System.Drawing.Color.Black;
            this.tacticalMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tacticalMap1.Location = new System.Drawing.Point(0, 0);
            this.tacticalMap1.Name = "tacticalMap1";
            this.tacticalMap1.Size = new System.Drawing.Size(1918, 1078);
            this.tacticalMap1.TabIndex = 1;
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
            // turnInformation1
            // 
            this.turnInformation1.BackColor = System.Drawing.Color.Black;
            this.turnInformation1.Location = new System.Drawing.Point(11, 11);
            this.turnInformation1.Name = "turnInformation1";
            this.turnInformation1.Size = new System.Drawing.Size(310, 347);
            this.turnInformation1.TabIndex = 2;
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OutlandAreaLogic.Controls.OaButton commandClose;
        private BattleBoardControls.TacticalMap tacticalMap1;
        private BattleBoardControls.TurnInformation turnInformation1;
    }
}