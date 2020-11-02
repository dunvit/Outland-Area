namespace Engine.Gui.Controls.TacticalLayer
{
    partial class CommandsControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdOpenFire = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton4 = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton3 = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton2 = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton1 = new Engine.Gui.Controls.Common.FlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSelectedObjectLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdOpenFire);
            this.panel1.Controls.Add(this.flatButton4);
            this.panel1.Controls.Add(this.flatButton3);
            this.panel1.Controls.Add(this.flatButton2);
            this.panel1.Controls.Add(this.flatButton1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 74);
            this.panel1.TabIndex = 0;
            // 
            // cmdOpenFire
            // 
            this.cmdOpenFire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdOpenFire.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdOpenFire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdOpenFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdOpenFire.ForeColor = System.Drawing.Color.DimGray;
            this.cmdOpenFire.Location = new System.Drawing.Point(267, 28);
            this.cmdOpenFire.Name = "cmdOpenFire";
            this.cmdOpenFire.Size = new System.Drawing.Size(61, 37);
            this.cmdOpenFire.TabIndex = 6;
            this.cmdOpenFire.Text = "Fire";
            this.cmdOpenFire.UseVisualStyleBackColor = false;
            this.cmdOpenFire.Click += new System.EventHandler(this.Event_OpenFire);
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton4.ForeColor = System.Drawing.Color.DimGray;
            this.flatButton4.Location = new System.Drawing.Point(200, 28);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Size = new System.Drawing.Size(61, 37);
            this.flatButton4.TabIndex = 5;
            this.flatButton4.Text = "Lock";
            this.flatButton4.UseVisualStyleBackColor = false;
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton3.ForeColor = System.Drawing.Color.DimGray;
            this.flatButton3.Location = new System.Drawing.Point(133, 28);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Size = new System.Drawing.Size(61, 37);
            this.flatButton3.TabIndex = 4;
            this.flatButton3.Text = "Distance";
            this.flatButton3.UseVisualStyleBackColor = false;
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton2.ForeColor = System.Drawing.Color.DimGray;
            this.flatButton2.Location = new System.Drawing.Point(71, 28);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Size = new System.Drawing.Size(56, 37);
            this.flatButton2.TabIndex = 3;
            this.flatButton2.Text = "Orbit";
            this.flatButton2.UseVisualStyleBackColor = false;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.DimGray;
            this.flatButton1.Location = new System.Drawing.Point(9, 28);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(56, 37);
            this.flatButton1.TabIndex = 0;
            this.flatButton1.Text = "Align to";
            this.flatButton1.UseVisualStyleBackColor = false;
            this.flatButton1.Click += new System.EventHandler(this.Event_AlignTo);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtSelectedObjectLabel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 21);
            this.panel2.TabIndex = 2;
            // 
            // txtSelectedObjectLabel
            // 
            this.txtSelectedObjectLabel.AutoSize = true;
            this.txtSelectedObjectLabel.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedObjectLabel.ForeColor = System.Drawing.Color.Chocolate;
            this.txtSelectedObjectLabel.Location = new System.Drawing.Point(82, 5);
            this.txtSelectedObjectLabel.Name = "txtSelectedObjectLabel";
            this.txtSelectedObjectLabel.Size = new System.Drawing.Size(69, 11);
            this.txtSelectedObjectLabel.TabIndex = 4;
            this.txtSelectedObjectLabel.Text = "COMMANDS";
            this.txtSelectedObjectLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 11);
            this.label1.TabIndex = 3;
            this.label1.Text = "COMMANDS";
            // 
            // CommandsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "CommandsControl";
            this.Size = new System.Drawing.Size(334, 74);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Common.FlatButton flatButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Common.FlatButton cmdOpenFire;
        private Common.FlatButton flatButton4;
        private Common.FlatButton flatButton3;
        private Common.FlatButton flatButton2;
        private System.Windows.Forms.Label txtSelectedObjectLabel;
    }
}
