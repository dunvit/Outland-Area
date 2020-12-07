namespace Engine.Gui.Controls
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
            this.pnlObjectInfo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlObjectInfo
            // 
            this.pnlObjectInfo.BackColor = System.Drawing.Color.Maroon;
            this.pnlObjectInfo.Location = new System.Drawing.Point(23, 29);
            this.pnlObjectInfo.Name = "pnlObjectInfo";
            this.pnlObjectInfo.Size = new System.Drawing.Size(105, 38);
            this.pnlObjectInfo.TabIndex = 0;
            this.pnlObjectInfo.Visible = false;
            // 
            // TacticalMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlObjectInfo);
            this.DoubleBuffered = true;
            this.Name = "TacticalMap";
            this.Size = new System.Drawing.Size(148, 148);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MapClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapMouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlObjectInfo;
    }
}
