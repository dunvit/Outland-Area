
namespace Engine.UI.Controls
{
    partial class ModulePreview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crlPilotImage = new System.Windows.Forms.PictureBox();
            this.crlModuleImage = new System.Windows.Forms.PictureBox();
            this.crlPilotStamina = new Engine.UI.Controls.ProgressBarVertical();
            this.crlModuleReload = new Engine.UI.Controls.ProgressBarVertical();
            this.crlModuleName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crlModuleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // crlPilotImage
            // 
            this.crlPilotImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crlPilotImage.Location = new System.Drawing.Point(4, 33);
            this.crlPilotImage.Name = "crlPilotImage";
            this.crlPilotImage.Size = new System.Drawing.Size(60, 60);
            this.crlPilotImage.TabIndex = 0;
            this.crlPilotImage.TabStop = false;
            this.crlPilotImage.Click += new System.EventHandler(this.Event_ModuleActivate);
            // 
            // crlModuleImage
            // 
            this.crlModuleImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crlModuleImage.Location = new System.Drawing.Point(98, 33);
            this.crlModuleImage.Name = "crlModuleImage";
            this.crlModuleImage.Size = new System.Drawing.Size(60, 60);
            this.crlModuleImage.TabIndex = 1;
            this.crlModuleImage.TabStop = false;
            this.crlModuleImage.Click += new System.EventHandler(this.Event_ModuleActivate);
            // 
            // crlPilotStamina
            // 
            this.crlPilotStamina.BackColor = System.Drawing.Color.Maroon;
            this.crlPilotStamina.BarLineColor = System.Drawing.Color.OliveDrab;
            this.crlPilotStamina.CurrentValue = 10;
            this.crlPilotStamina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crlPilotStamina.Location = new System.Drawing.Point(67, 33);
            this.crlPilotStamina.Maximum = 100;
            this.crlPilotStamina.Name = "crlPilotStamina";
            this.crlPilotStamina.Size = new System.Drawing.Size(15, 60);
            this.crlPilotStamina.TabIndex = 2;
            this.crlPilotStamina.Click += new System.EventHandler(this.Event_ModuleActivate);
            // 
            // crlModuleReload
            // 
            this.crlModuleReload.BackColor = System.Drawing.Color.DimGray;
            this.crlModuleReload.BarLineColor = System.Drawing.Color.LimeGreen;
            this.crlModuleReload.CurrentValue = 100;
            this.crlModuleReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crlModuleReload.Location = new System.Drawing.Point(161, 33);
            this.crlModuleReload.Maximum = 100;
            this.crlModuleReload.Name = "crlModuleReload";
            this.crlModuleReload.Size = new System.Drawing.Size(15, 60);
            this.crlModuleReload.TabIndex = 3;
            this.crlModuleReload.Click += new System.EventHandler(this.Event_ModuleActivate);
            // 
            // crlModuleName
            // 
            this.crlModuleName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crlModuleName.Dock = System.Windows.Forms.DockStyle.Top;
            this.crlModuleName.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crlModuleName.ForeColor = System.Drawing.Color.Peru;
            this.crlModuleName.Location = new System.Drawing.Point(0, 0);
            this.crlModuleName.Name = "crlModuleName";
            this.crlModuleName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.crlModuleName.Size = new System.Drawing.Size(178, 30);
            this.crlModuleName.TabIndex = 4;
            this.crlModuleName.Text = "Module Name";
            this.crlModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.crlModuleName.Click += new System.EventHandler(this.Event_ModuleActivate);
            // 
            // ModulePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.crlModuleName);
            this.Controls.Add(this.crlModuleReload);
            this.Controls.Add(this.crlPilotStamina);
            this.Controls.Add(this.crlModuleImage);
            this.Controls.Add(this.crlPilotImage);
            this.DoubleBuffered = true;
            this.Name = "ModulePreview";
            this.Size = new System.Drawing.Size(178, 98);
            this.Click += new System.EventHandler(this.Event_ModuleActivate);
            ((System.ComponentModel.ISupportInitialize)(this.crlPilotImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crlModuleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox crlPilotImage;
        private System.Windows.Forms.PictureBox crlModuleImage;
        private ProgressBarVertical crlPilotStamina;
        private ProgressBarVertical crlModuleReload;
        private System.Windows.Forms.Label crlModuleName;
    }
}
