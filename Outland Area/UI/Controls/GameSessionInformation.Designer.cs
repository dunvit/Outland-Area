
namespace Engine.UI.Controls
{
    partial class GameSessionInformation
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTurn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdPauseResume = new System.Windows.Forms.Button();
            this.cmdExitGame = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMode = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Turn...................";
            // 
            // txtTurn
            // 
            this.txtTurn.ForeColor = System.Drawing.Color.White;
            this.txtTurn.Location = new System.Drawing.Point(101, 38);
            this.txtTurn.Name = "txtTurn";
            this.txtTurn.Size = new System.Drawing.Size(38, 15);
            this.txtTurn.TabIndex = 1;
            this.txtTurn.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 26);
            this.panel1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(226, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "x";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Information";
            // 
            // cmdPauseResume
            // 
            this.cmdPauseResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdPauseResume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdPauseResume.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdPauseResume.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdPauseResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPauseResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdPauseResume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.cmdPauseResume.Location = new System.Drawing.Point(12, 108);
            this.cmdPauseResume.Name = "cmdPauseResume";
            this.cmdPauseResume.Size = new System.Drawing.Size(107, 23);
            this.cmdPauseResume.TabIndex = 3;
            this.cmdPauseResume.Text = "Pause";
            this.cmdPauseResume.UseVisualStyleBackColor = false;
            this.cmdPauseResume.Click += new System.EventHandler(this.Event_ChangeGameStatus);
            // 
            // cmdExitGame
            // 
            this.cmdExitGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdExitGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdExitGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdExitGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdExitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmdExitGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.cmdExitGame.Location = new System.Drawing.Point(125, 108);
            this.cmdExitGame.Name = "cmdExitGame";
            this.cmdExitGame.Size = new System.Drawing.Size(107, 23);
            this.cmdExitGame.TabIndex = 4;
            this.cmdExitGame.Text = "Exit game";
            this.cmdExitGame.UseVisualStyleBackColor = false;
            this.cmdExitGame.Click += new System.EventHandler(this.Event_CloseApplication);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtMode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.cmdExitGame);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmdPauseResume);
            this.panel2.Controls.Add(this.txtTurn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 148);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mode...................";
            // 
            // txtMode
            // 
            this.txtMode.ForeColor = System.Drawing.Color.White;
            this.txtMode.Location = new System.Drawing.Point(101, 53);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(131, 15);
            this.txtMode.TabIndex = 6;
            this.txtMode.Text = "0";
            // 
            // GameSessionInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Name = "GameSessionInformation";
            this.Size = new System.Drawing.Size(246, 148);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtTurn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdPauseResume;
        private System.Windows.Forms.Button cmdExitGame;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtMode;
        private System.Windows.Forms.Label label4;
    }
}
