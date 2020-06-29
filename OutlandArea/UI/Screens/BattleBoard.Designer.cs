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
            this.turnInformation1 = new OutlandArea.UI.Screens.BattleBoardControls.TurnInformation();
            this.controlTacticalMap = new OutlandArea.UI.Screens.BattleBoardControls.TacticalMap();
            this.commandClose = new OutlandAreaLogic.Controls.OaButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.turnInformation1);
            this.panel1.Controls.Add(this.controlTacticalMap);
            this.panel1.Controls.Add(this.commandClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1080);
            this.panel1.TabIndex = 0;
            // 
            // turnInformation1
            // 
            this.turnInformation1.BackColor = System.Drawing.Color.Black;
            this.turnInformation1.Location = new System.Drawing.Point(22, 21);
            this.turnInformation1.Margin = new System.Windows.Forms.Padding(12);
            this.turnInformation1.Name = "turnInformation1";
            this.turnInformation1.Size = new System.Drawing.Size(620, 667);
            this.turnInformation1.TabIndex = 2;
            // 
            // controlTacticalMap
            // 
            this.controlTacticalMap.BackColor = System.Drawing.Color.Black;
            this.controlTacticalMap.Location = new System.Drawing.Point(1, 0);
            this.controlTacticalMap.Margin = new System.Windows.Forms.Padding(12);
            this.controlTacticalMap.Name = "controlTacticalMap";
            this.controlTacticalMap.Size = new System.Drawing.Size(1918, 1078);
            this.controlTacticalMap.TabIndex = 1;
            // 
            // commandClose
            // 
            this.commandClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.commandClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandClose.Location = new System.Drawing.Point(3580, 2008);
            this.commandClose.Margin = new System.Windows.Forms.Padding(6);
            this.commandClose.Name = "commandClose";
            this.commandClose.Size = new System.Drawing.Size(234, 44);
            this.commandClose.TabIndex = 0;
            this.commandClose.Text = "Close";
            this.commandClose.UseVisualStyleBackColor = false;
            this.commandClose.Click += new System.EventHandler(this.Event_CloseApplication);
            // 
            // BattleBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BattleBoard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BattleBoard";
            this.Load += new System.EventHandler(this.Event_BoardLoad);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OutlandAreaLogic.Controls.OaButton commandClose;
        private BattleBoardControls.TacticalMap controlTacticalMap;
        private BattleBoardControls.TurnInformation turnInformation1;
    }
}