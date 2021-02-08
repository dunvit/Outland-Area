
namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    partial class Propulsion_ForwardStop
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
            this.imageAcceleration = new System.Windows.Forms.PictureBox();
            this.imageStop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageAcceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageStop)).BeginInit();
            this.SuspendLayout();
            // 
            // imageAcceleration
            // 
            this.imageAcceleration.Image = global::Engine.Properties.Resources.Propulsion_ForwardInActive;
            this.imageAcceleration.Location = new System.Drawing.Point(3, 3);
            this.imageAcceleration.Name = "imageAcceleration";
            this.imageAcceleration.Size = new System.Drawing.Size(42, 21);
            this.imageAcceleration.TabIndex = 43;
            this.imageAcceleration.TabStop = false;
            this.imageAcceleration.Click += new System.EventHandler(this.Acceleration);
            // 
            // imageStop
            // 
            this.imageStop.Image = global::Engine.Properties.Resources.Propulsion_StopInActive;
            this.imageStop.Location = new System.Drawing.Point(3, 24);
            this.imageStop.Name = "imageStop";
            this.imageStop.Size = new System.Drawing.Size(42, 21);
            this.imageStop.TabIndex = 44;
            this.imageStop.TabStop = false;
            this.imageStop.Click += new System.EventHandler(this.Stop);
            // 
            // Propulsion_ForwardStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageStop);
            this.Controls.Add(this.imageAcceleration);
            this.Name = "Propulsion_ForwardStop";
            this.Load += new System.EventHandler(this.Propulsion_ForwardStop_Load);
            this.Controls.SetChildIndex(this.moduleFirstReloadBar, 0);
            this.Controls.SetChildIndex(this.imageAcceleration, 0);
            this.Controls.SetChildIndex(this.imageStop, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageAcceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageAcceleration;
        private System.Windows.Forms.PictureBox imageStop;
    }
}
