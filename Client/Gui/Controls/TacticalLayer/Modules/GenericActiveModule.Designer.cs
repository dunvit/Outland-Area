
namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    partial class GenericActiveModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericActiveModule));
            this.moduleFirstReloadBar = new Engine.Gui.Controls.Common.CustomProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.actionIcon = new Engine.Gui.Controls.Common.ActionButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // moduleFirstReloadBar
            // 
            this.moduleFirstReloadBar.BarLineColor = System.Drawing.Color.Empty;
            this.moduleFirstReloadBar.BarText = null;
            this.moduleFirstReloadBar.Location = new System.Drawing.Point(0, 51);
            this.moduleFirstReloadBar.Name = "moduleFirstReloadBar";
            this.moduleFirstReloadBar.Size = new System.Drawing.Size(48, 10);
            this.moduleFirstReloadBar.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // actionIcon
            // 
            this.actionIcon.BackColor = System.Drawing.Color.Black;
            this.actionIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.actionIcon.Location = new System.Drawing.Point(0, 0);
            this.actionIcon.Name = "actionIcon";
            this.actionIcon.Picture = null;
            this.actionIcon.Size = new System.Drawing.Size(48, 48);
            this.actionIcon.TabIndex = 40;
            this.actionIcon.Click += new System.EventHandler(this.ExecuteModule);
            // 
            // GenericActiveModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.actionIcon);
            this.Controls.Add(this.moduleFirstReloadBar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "GenericActiveModule";
            this.Size = new System.Drawing.Size(48, 62);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Common.CustomProgressBar moduleFirstReloadBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Common.ActionButton actionIcon;
    }
}
