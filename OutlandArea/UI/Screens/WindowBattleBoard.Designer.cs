namespace OutlandArea.UI.Screens
{
    partial class WindowBattleBoard
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
            this.components = new System.ComponentModel.Container();
            this.crlRefreshMapTrigger = new System.Windows.Forms.Timer(this.components);
            this.commandApplicationExit = new OutlandAreaLogic.Controls.OaButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.crlRefreshMousePosition = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // crlRefreshMapTrigger
            // 
            this.crlRefreshMapTrigger.Interval = 500;
            this.crlRefreshMapTrigger.Tick += new System.EventHandler(this.crlRefreshMapTrigger_Tick);
            // 
            // commandApplicationExit
            // 
            this.commandApplicationExit.BackColor = System.Drawing.Color.Maroon;
            this.commandApplicationExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandApplicationExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandApplicationExit.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandApplicationExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandApplicationExit.Location = new System.Drawing.Point(1862, 12);
            this.commandApplicationExit.Name = "commandApplicationExit";
            this.commandApplicationExit.Size = new System.Drawing.Size(46, 23);
            this.commandApplicationExit.TabIndex = 3;
            this.commandApplicationExit.Text = "Exit";
            this.commandApplicationExit.UseVisualStyleBackColor = false;
            this.commandApplicationExit.Click += new System.EventHandler(this.commandApplicationExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Event_MapMouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MapMouseMove);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.DimGray;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Location = new System.Drawing.Point(12, 15);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(220, 145);
            this.txtLog.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(12, 166);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 145);
            this.textBox1.TabIndex = 6;
            // 
            // crlRefreshMousePosition
            // 
            this.crlRefreshMousePosition.Enabled = true;
            this.crlRefreshMousePosition.Tick += new System.EventHandler(this.crlRefreshMousePosition_Tick);
            // 
            // WindowBattleBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.commandApplicationExit);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowBattleBoard";
            this.Text = "WindowBattleBoard";
            this.Load += new System.EventHandler(this.WindowBattleBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer crlRefreshMapTrigger;
        private OutlandAreaLogic.Controls.OaButton commandApplicationExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer crlRefreshMousePosition;
    }
}