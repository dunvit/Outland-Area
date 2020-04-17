namespace OutlandArea
{
    partial class ScreenMenuSettings
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
            this.oaButton1 = new OutlandAreaLogic.Controls.OaButton();
            this.commandExit = new OutlandAreaLogic.Controls.OaButton();
            this.lblScreenResolution = new System.Windows.Forms.Label();
            this.controlScreenResolution = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.controlScreenResolution);
            this.panel1.Controls.Add(this.lblScreenResolution);
            this.panel1.Controls.Add(this.oaButton1);
            this.panel1.Controls.Add(this.commandExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 450);
            this.panel1.TabIndex = 3;
            // 
            // oaButton1
            // 
            this.oaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton1.Location = new System.Drawing.Point(165, 415);
            this.oaButton1.Name = "oaButton1";
            this.oaButton1.Size = new System.Drawing.Size(117, 23);
            this.oaButton1.TabIndex = 4;
            this.oaButton1.Text = "Save";
            this.oaButton1.UseVisualStyleBackColor = false;
            this.oaButton1.Click += new System.EventHandler(this.oaButton1_Click);
            // 
            // commandExit
            // 
            this.commandExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.commandExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandExit.Location = new System.Drawing.Point(42, 415);
            this.commandExit.Name = "commandExit";
            this.commandExit.Size = new System.Drawing.Size(117, 23);
            this.commandExit.TabIndex = 3;
            this.commandExit.Text = "Cancel";
            this.commandExit.UseVisualStyleBackColor = false;
            this.commandExit.Click += new System.EventHandler(this.commandExit_Click_1);
            // 
            // lblScreenResolution
            // 
            this.lblScreenResolution.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScreenResolution.ForeColor = System.Drawing.Color.White;
            this.lblScreenResolution.Location = new System.Drawing.Point(12, 24);
            this.lblScreenResolution.Name = "lblScreenResolution";
            this.lblScreenResolution.Size = new System.Drawing.Size(154, 23);
            this.lblScreenResolution.TabIndex = 5;
            this.lblScreenResolution.Text = "Screen Resolution:";
            // 
            // controlScreenResolution
            // 
            this.controlScreenResolution.FormattingEnabled = true;
            this.controlScreenResolution.Location = new System.Drawing.Point(96, 50);
            this.controlScreenResolution.Name = "controlScreenResolution";
            this.controlScreenResolution.Size = new System.Drawing.Size(204, 21);
            this.controlScreenResolution.TabIndex = 6;
            // 
            // ScreenMenuSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenMenuSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScreenMenuSettings";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private OutlandAreaLogic.Controls.OaButton oaButton1;
        private OutlandAreaLogic.Controls.OaButton commandExit;
        private System.Windows.Forms.Label lblScreenResolution;
        private System.Windows.Forms.ComboBox controlScreenResolution;
    }
}