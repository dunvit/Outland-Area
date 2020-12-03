namespace Engine.Gui.Controls.TacticalLayer
{
    partial class BattleInformation
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
            this.crlTitlebar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.crlTitlebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // crlTitlebar
            // 
            this.crlTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.crlTitlebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlTitlebar.Controls.Add(this.label1);
            this.crlTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.crlTitlebar.Location = new System.Drawing.Point(0, 0);
            this.crlTitlebar.Name = "crlTitlebar";
            this.crlTitlebar.Size = new System.Drawing.Size(287, 21);
            this.crlTitlebar.TabIndex = 3;
            this.crlTitlebar.DoubleClick += new System.EventHandler(this.ChangeVisibilityMode);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 11);
            this.label1.TabIndex = 3;
            this.label1.Text = "BATTLE LOG";
            this.label1.DoubleClick += new System.EventHandler(this.ChangeVisibilityMode);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.DarkGray;
            this.txtLog.Location = new System.Drawing.Point(0, 21);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(287, 279);
            this.txtLog.TabIndex = 4;
            this.txtLog.DoubleClick += new System.EventHandler(this.ChangeVisibilityMode);
            // 
            // BattleInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.crlTitlebar);
            this.Name = "BattleInformation";
            this.Size = new System.Drawing.Size(287, 300);
            this.crlTitlebar.ResumeLayout(false);
            this.crlTitlebar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel crlTitlebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
    }
}
