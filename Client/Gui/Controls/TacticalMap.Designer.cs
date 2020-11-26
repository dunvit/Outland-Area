﻿namespace Engine.Gui.Controls
{
    partial class TacticalMap
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
            this.SuspendLayout();
            // 
            // TacticalMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DoubleBuffered = true;
            this.Name = "TacticalMap";
            this.Size = new System.Drawing.Size(148, 148);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AlignToCommand);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapMouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
