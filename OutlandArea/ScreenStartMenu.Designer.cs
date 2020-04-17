namespace OutlandArea
{
    partial class ScreenStartMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenStartMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlCurrentStatus = new System.Windows.Forms.Label();
            this.oaButton2 = new OutlandAreaLogic.Controls.OaButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.oaButton2);
            this.panel1.Controls.Add(this.controlCurrentStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 0;
            // 
            // controlCurrentStatus
            // 
            this.controlCurrentStatus.BackColor = System.Drawing.Color.DimGray;
            this.controlCurrentStatus.Location = new System.Drawing.Point(11, 697);
            this.controlCurrentStatus.Name = "controlCurrentStatus";
            this.controlCurrentStatus.Size = new System.Drawing.Size(228, 13);
            this.controlCurrentStatus.TabIndex = 0;
            this.controlCurrentStatus.Text = "Current status:";
            // 
            // oaButton2
            // 
            this.oaButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton2.Location = new System.Drawing.Point(1252, 3);
            this.oaButton2.Name = "oaButton2";
            this.oaButton2.Size = new System.Drawing.Size(23, 23);
            this.oaButton2.TabIndex = 3;
            this.oaButton2.Text = "x";
            this.oaButton2.UseVisualStyleBackColor = false;
            // 
            // ScreenStartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenStartMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScreenStartMenu";
            this.Activated += new System.EventHandler(this.Event_ActivateWindow);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label controlCurrentStatus;
        private OutlandAreaLogic.Controls.OaButton oaButton2;
    }
}