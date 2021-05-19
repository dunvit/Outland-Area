
namespace Engine.UI.Controls
{
    partial class ProgressBarVertical
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
            this.crlFilledSurface = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.crlFilledSurface)).BeginInit();
            this.SuspendLayout();
            // 
            // crlFilledSurface
            // 
            this.crlFilledSurface.BackColor = System.Drawing.Color.Beige;
            this.crlFilledSurface.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crlFilledSurface.Location = new System.Drawing.Point(0, 38);
            this.crlFilledSurface.Name = "crlFilledSurface";
            this.crlFilledSurface.Size = new System.Drawing.Size(22, 78);
            this.crlFilledSurface.TabIndex = 1;
            this.crlFilledSurface.TabStop = false;
            // 
            // ProgressBarVertical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.crlFilledSurface);
            this.Name = "ProgressBarVertical";
            this.Size = new System.Drawing.Size(22, 116);
            ((System.ComponentModel.ISupportInitialize)(this.crlFilledSurface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox crlFilledSurface;
    }
}
