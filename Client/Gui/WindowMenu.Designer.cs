namespace Engine.Gui
{
    partial class WindowMenu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtShipName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.flatButton5 = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton4 = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton3 = new Engine.Gui.Controls.Common.FlatButton();
            this.cmdStartNewGame = new Engine.Gui.Controls.Common.FlatButton();
            this.flatButton1 = new Engine.Gui.Controls.Common.FlatButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtShipName);
            this.panel1.Controls.Add(this.flatButton5);
            this.panel1.Controls.Add(this.flatButton4);
            this.panel1.Controls.Add(this.flatButton3);
            this.panel1.Controls.Add(this.cmdStartNewGame);
            this.panel1.Controls.Add(this.flatButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 450);
            this.panel1.TabIndex = 0;
            // 
            // txtShipName
            // 
            this.txtShipName.BackColor = System.Drawing.Color.Transparent;
            this.txtShipName.Font = new System.Drawing.Font("Protomolecule", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtShipName.Location = new System.Drawing.Point(66, 50);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(203, 33);
            this.txtShipName.TabIndex = 13;
            this.txtShipName.Text = "OUTLAND AREA";
            this.txtShipName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(11, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "v1.0.1";
            // 
            // flatButton5
            // 
            this.flatButton5.BackColor = System.Drawing.Color.DarkRed;
            this.flatButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.flatButton5.Location = new System.Drawing.Point(99, 396);
            this.flatButton5.Name = "flatButton5";
            this.flatButton5.Size = new System.Drawing.Size(117, 23);
            this.flatButton5.TabIndex = 4;
            this.flatButton5.Text = "Exit";
            this.flatButton5.UseVisualStyleBackColor = false;
            this.flatButton5.Click += new System.EventHandler(this.Event_ExitGame);
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.flatButton4.Location = new System.Drawing.Point(99, 218);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Size = new System.Drawing.Size(117, 23);
            this.flatButton4.TabIndex = 3;
            this.flatButton4.Text = "Settings";
            this.flatButton4.UseVisualStyleBackColor = false;
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.flatButton3.Location = new System.Drawing.Point(99, 189);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Size = new System.Drawing.Size(117, 23);
            this.flatButton3.TabIndex = 2;
            this.flatButton3.Text = "Single battle";
            this.flatButton3.UseVisualStyleBackColor = false;
            // 
            // cmdStartNewGame
            // 
            this.cmdStartNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdStartNewGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdStartNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdStartNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdStartNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.cmdStartNewGame.Location = new System.Drawing.Point(99, 131);
            this.cmdStartNewGame.Name = "cmdStartNewGame";
            this.cmdStartNewGame.Size = new System.Drawing.Size(117, 23);
            this.cmdStartNewGame.TabIndex = 1;
            this.cmdStartNewGame.Text = "Start new game";
            this.cmdStartNewGame.UseVisualStyleBackColor = false;
            this.cmdStartNewGame.Click += new System.EventHandler(this.Event_StartNewGame);
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.flatButton1.Location = new System.Drawing.Point(99, 160);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(117, 23);
            this.flatButton1.TabIndex = 0;
            this.flatButton1.Text = "Resume game";
            this.flatButton1.UseVisualStyleBackColor = false;
            // 
            // WindowMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(325, 450);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OUTLAND AREA";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.Common.FlatButton flatButton1;
        private Controls.Common.FlatButton flatButton3;
        private Controls.Common.FlatButton cmdStartNewGame;
        private Controls.Common.FlatButton flatButton5;
        private Controls.Common.FlatButton flatButton4;
        private System.Windows.Forms.Label txtShipName;
        private System.Windows.Forms.Label label8;
    }
}