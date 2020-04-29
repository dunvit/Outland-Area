namespace Engine.Screens
{
    partial class ScreenNavigation
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.oaButton1 = new OutlandAreaLogic.Controls.OaButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.oaButton1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(623, 354);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 255);
            this.panel3.TabIndex = 18;
            // 
            // oaButton1
            // 
            this.oaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton1.Location = new System.Drawing.Point(25, 206);
            this.oaButton1.Name = "oaButton1";
            this.oaButton1.Size = new System.Drawing.Size(237, 23);
            this.oaButton1.TabIndex = 8;
            this.oaButton1.Text = "Trash It";
            this.oaButton1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.label5.Location = new System.Drawing.Point(45, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Commands";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1140, 676);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Cargo";
            // 
            // ScreenNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "ScreenNavigation";
            this.Size = new System.Drawing.Size(937, 618);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private OutlandAreaLogic.Controls.OaButton oaButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}
