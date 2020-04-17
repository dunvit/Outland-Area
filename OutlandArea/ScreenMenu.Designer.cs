namespace OutlandArea
{
    partial class ScreenMenu
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
            this.commandExit = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton1 = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton2 = new OutlandAreaLogic.Controls.OaButton();
            this.oaButton3 = new OutlandAreaLogic.Controls.OaButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.oaButton3);
            this.panel1.Controls.Add(this.oaButton2);
            this.panel1.Controls.Add(this.oaButton1);
            this.panel1.Controls.Add(this.commandExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 450);
            this.panel1.TabIndex = 0;
            // 
            // commandExit
            // 
            this.commandExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.commandExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandExit.Location = new System.Drawing.Point(100, 385);
            this.commandExit.Name = "commandExit";
            this.commandExit.Size = new System.Drawing.Size(117, 23);
            this.commandExit.TabIndex = 0;
            this.commandExit.Text = "Exit";
            this.commandExit.UseVisualStyleBackColor = false;
            this.commandExit.Click += new System.EventHandler(this.commandExit_Click);
            // 
            // oaButton1
            // 
            this.oaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton1.Location = new System.Drawing.Point(100, 55);
            this.oaButton1.Name = "oaButton1";
            this.oaButton1.Size = new System.Drawing.Size(117, 23);
            this.oaButton1.TabIndex = 1;
            this.oaButton1.Text = "Resume game";
            this.oaButton1.UseVisualStyleBackColor = false;
            // 
            // oaButton2
            // 
            this.oaButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton2.Location = new System.Drawing.Point(100, 93);
            this.oaButton2.Name = "oaButton2";
            this.oaButton2.Size = new System.Drawing.Size(117, 23);
            this.oaButton2.TabIndex = 2;
            this.oaButton2.Text = "Start new game";
            this.oaButton2.UseVisualStyleBackColor = false;
            // 
            // oaButton3
            // 
            this.oaButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton3.Location = new System.Drawing.Point(100, 132);
            this.oaButton3.Name = "oaButton3";
            this.oaButton3.Size = new System.Drawing.Size(117, 23);
            this.oaButton3.TabIndex = 3;
            this.oaButton3.Text = "Settings";
            this.oaButton3.UseVisualStyleBackColor = false;
            // 
            // ScreenMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScreenMenu";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OutlandAreaLogic.Controls.OaButton commandExit;
        private OutlandAreaLogic.Controls.OaButton oaButton1;
        private OutlandAreaLogic.Controls.OaButton oaButton3;
        private OutlandAreaLogic.Controls.OaButton oaButton2;
    }
}