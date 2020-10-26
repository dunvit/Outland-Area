namespace Engine.Gui
{
    partial class WindowTacticalLayerContainer
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
            this.flatButton1 = new Engine.Gui.Controls.Common.FlatButton();
            this.crlCelestialMap = new Engine.Gui.Controls.TacticalLayer.CelestialMapControl();
            this.cmdRunGame = new Engine.Gui.Controls.Common.FlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlCommands = new Engine.Gui.Controls.TacticalLayer.CommandsControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.flatButton1.Location = new System.Drawing.Point(40, 52);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(117, 23);
            this.flatButton1.TabIndex = 0;
            this.flatButton1.Text = "Exit";
            this.flatButton1.UseVisualStyleBackColor = false;
            this.flatButton1.Click += new System.EventHandler(this.Event_Exit);
            // 
            // crlCelestialMap
            // 
            this.crlCelestialMap.BackColor = System.Drawing.Color.Black;
            this.crlCelestialMap.Location = new System.Drawing.Point(562, 208);
            this.crlCelestialMap.Name = "crlCelestialMap";
            this.crlCelestialMap.Size = new System.Drawing.Size(336, 288);
            this.crlCelestialMap.TabIndex = 1;
            // 
            // cmdRunGame
            // 
            this.cmdRunGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdRunGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdRunGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdRunGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRunGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.cmdRunGame.Location = new System.Drawing.Point(40, 23);
            this.cmdRunGame.Name = "cmdRunGame";
            this.cmdRunGame.Size = new System.Drawing.Size(117, 23);
            this.cmdRunGame.TabIndex = 2;
            this.cmdRunGame.Text = "Run";
            this.cmdRunGame.UseVisualStyleBackColor = false;
            this.cmdRunGame.Click += new System.EventHandler(this.Event_ResumeGame);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdRunGame);
            this.panel1.Controls.Add(this.flatButton1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // controlCommands
            // 
            this.controlCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.controlCommands.Location = new System.Drawing.Point(479, 12);
            this.controlCommands.Name = "controlCommands";
            this.controlCommands.Size = new System.Drawing.Size(334, 74);
            this.controlCommands.TabIndex = 4;
            // 
            // WindowTacticalLayerContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.controlCommands);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crlCelestialMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowTacticalLayerContainer";
            this.Text = "WindowTacticalLeyerContainer";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Common.FlatButton flatButton1;
        private Controls.TacticalLayer.CelestialMapControl crlCelestialMap;
        private Controls.Common.FlatButton cmdRunGame;
        private System.Windows.Forms.Panel panel1;
        private Controls.TacticalLayer.CommandsControl controlCommands;
    }
}