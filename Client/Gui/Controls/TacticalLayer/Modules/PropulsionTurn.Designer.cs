
namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    partial class PropulsionTurn
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
            this.imageRightPart = new System.Windows.Forms.PictureBox();
            this.imageLeftPart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageRightPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLeftPart)).BeginInit();
            this.SuspendLayout();
            // 
            // imageRightPart
            // 
            this.imageRightPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageRightPart.Image = global::Engine.Properties.Resources.Propulsion_TurnRightInActive;
            this.imageRightPart.Location = new System.Drawing.Point(24, 3);
            this.imageRightPart.Name = "imageRightPart";
            this.imageRightPart.Size = new System.Drawing.Size(21, 42);
            this.imageRightPart.TabIndex = 41;
            this.imageRightPart.TabStop = false;
            // 
            // imageLeftPart
            // 
            this.imageLeftPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageLeftPart.Image = global::Engine.Properties.Resources.Propulsion_TurnLeftInActive;
            this.imageLeftPart.Location = new System.Drawing.Point(3, 3);
            this.imageLeftPart.Name = "imageLeftPart";
            this.imageLeftPart.Size = new System.Drawing.Size(21, 42);
            this.imageLeftPart.TabIndex = 42;
            this.imageLeftPart.TabStop = false;
            // 
            // PropulsionTurn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageLeftPart);
            this.Controls.Add(this.imageRightPart);
            this.Name = "PropulsionTurn";
            this.Load += new System.EventHandler(this.PropulsionTurn_Load);
            this.Controls.SetChildIndex(this.moduleFirstReloadBar, 0);
            this.Controls.SetChildIndex(this.imageRightPart, 0);
            this.Controls.SetChildIndex(this.imageLeftPart, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageRightPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLeftPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageRightPart;
        private System.Windows.Forms.PictureBox imageLeftPart;
    }
}
