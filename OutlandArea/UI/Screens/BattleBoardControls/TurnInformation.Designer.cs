namespace OutlandArea.UI.Screens.BattleBoardControls
{
    partial class TurnInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TurnInformation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.oaButton1 = new OutlandAreaLogic.Controls.OaButton();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTurnNumber = new System.Windows.Forms.Label();
            this.commandApplicationExit = new OutlandAreaLogic.Controls.OaButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.commandApplicationExit);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.oaButton1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 347);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelTurnNumber);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 39);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turn ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // oaButton1
            // 
            this.oaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton1.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton1.Location = new System.Drawing.Point(94, 272);
            this.oaButton1.Name = "oaButton1";
            this.oaButton1.Size = new System.Drawing.Size(117, 23);
            this.oaButton1.TabIndex = 1;
            this.oaButton1.Text = "End Turn";
            this.oaButton1.UseVisualStyleBackColor = false;
            this.oaButton1.Click += new System.EventHandler(this.Event_EndTurn);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(51, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Turn ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Visible = false;
            // 
            // labelTurnNumber
            // 
            this.labelTurnNumber.BackColor = System.Drawing.Color.Transparent;
            this.labelTurnNumber.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTurnNumber.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTurnNumber.Location = new System.Drawing.Point(63, 7);
            this.labelTurnNumber.Name = "labelTurnNumber";
            this.labelTurnNumber.Size = new System.Drawing.Size(72, 23);
            this.labelTurnNumber.TabIndex = 1;
            this.labelTurnNumber.Text = "1";
            // 
            // commandApplicationExit
            // 
            this.commandApplicationExit.BackColor = System.Drawing.Color.Maroon;
            this.commandApplicationExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandApplicationExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandApplicationExit.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandApplicationExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandApplicationExit.Location = new System.Drawing.Point(94, 301);
            this.commandApplicationExit.Name = "commandApplicationExit";
            this.commandApplicationExit.Size = new System.Drawing.Size(117, 23);
            this.commandApplicationExit.TabIndex = 2;
            this.commandApplicationExit.Text = "Exit";
            this.commandApplicationExit.UseVisualStyleBackColor = false;
            this.commandApplicationExit.Click += new System.EventHandler(this.Event_ApplicationExit);
            // 
            // TurnInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "TurnInformation";
            this.Size = new System.Drawing.Size(336, 347);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private OutlandAreaLogic.Controls.OaButton oaButton1;
        private System.Windows.Forms.Label labelTurnNumber;
        private OutlandAreaLogic.Controls.OaButton commandApplicationExit;
    }
}
