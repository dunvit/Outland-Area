
namespace OutlandAreaXYZ
{
    partial class WindowGameBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAgility = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSpacecraftY = new System.Windows.Forms.TextBox();
            this.txtSpacecraftX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSpacecraftDirection = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMouseY = new System.Windows.Forms.TextBox();
            this.txtMouseX = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtTargetY = new System.Windows.Forms.TextBox();
            this.txtTargetX = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAgility);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSpacecraftY);
            this.panel1.Controls.Add(this.txtSpacecraftX);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSpacecraftDirection);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 167);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(118, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(118, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "x";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(125, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "grad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(125, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "grad/sec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Agility:";
            // 
            // txtAgility
            // 
            this.txtAgility.Location = new System.Drawing.Point(78, 47);
            this.txtAgility.Name = "txtAgility";
            this.txtAgility.Size = new System.Drawing.Size(34, 23);
            this.txtAgility.TabIndex = 6;
            this.txtAgility.Text = "5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Set Spacecraft";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Event_SetSpacecraftLocation);
            // 
            // txtSpacecraftY
            // 
            this.txtSpacecraftY.Location = new System.Drawing.Point(78, 106);
            this.txtSpacecraftY.Name = "txtSpacecraftY";
            this.txtSpacecraftY.Size = new System.Drawing.Size(34, 23);
            this.txtSpacecraftY.TabIndex = 4;
            this.txtSpacecraftY.Text = "180";
            // 
            // txtSpacecraftX
            // 
            this.txtSpacecraftX.Location = new System.Drawing.Point(78, 77);
            this.txtSpacecraftX.Name = "txtSpacecraftX";
            this.txtSpacecraftX.Size = new System.Drawing.Size(34, 23);
            this.txtSpacecraftX.TabIndex = 3;
            this.txtSpacecraftX.Text = "180";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Direction:";
            // 
            // txtSpacecraftDirection
            // 
            this.txtSpacecraftDirection.Location = new System.Drawing.Point(78, 13);
            this.txtSpacecraftDirection.Name = "txtSpacecraftDirection";
            this.txtSpacecraftDirection.Size = new System.Drawing.Size(34, 23);
            this.txtSpacecraftDirection.TabIndex = 0;
            this.txtSpacecraftDirection.Text = "180";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtMouseY);
            this.panel2.Controls.Add(this.txtMouseX);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(1191, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 72);
            this.panel2.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(116, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(116, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "x";
            // 
            // txtMouseY
            // 
            this.txtMouseY.Location = new System.Drawing.Point(76, 37);
            this.txtMouseY.Name = "txtMouseY";
            this.txtMouseY.ReadOnly = true;
            this.txtMouseY.Size = new System.Drawing.Size(34, 23);
            this.txtMouseY.TabIndex = 4;
            this.txtMouseY.Text = "0";
            // 
            // txtMouseX
            // 
            this.txtMouseX.Location = new System.Drawing.Point(76, 8);
            this.txtMouseX.Name = "txtMouseX";
            this.txtMouseX.ReadOnly = true;
            this.txtMouseX.Size = new System.Drawing.Size(34, 23);
            this.txtMouseX.TabIndex = 3;
            this.txtMouseX.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(12, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Mouse";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(137, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 15);
            this.label10.TabIndex = 17;
            this.label10.Text = "y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(137, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 148);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Set Spacecraft";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(34, 23);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "180";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 90);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(34, 23);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "180";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(33, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Location:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.txtTargetY);
            this.panel3.Controls.Add(this.txtTargetX);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Location = new System.Drawing.Point(12, 185);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 118);
            this.panel3.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(117, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 15);
            this.label14.TabIndex = 11;
            this.label14.Text = "y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(117, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 15);
            this.label15.TabIndex = 10;
            this.label15.Text = "x";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Set Target";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Event_SetTargetLocation);
            // 
            // txtTargetY
            // 
            this.txtTargetY.Location = new System.Drawing.Point(77, 50);
            this.txtTargetY.Name = "txtTargetY";
            this.txtTargetY.Size = new System.Drawing.Size(34, 23);
            this.txtTargetY.TabIndex = 4;
            this.txtTargetY.Text = "N/A";
            // 
            // txtTargetX
            // 
            this.txtTargetX.Location = new System.Drawing.Point(77, 21);
            this.txtTargetX.Name = "txtTargetX";
            this.txtTargetX.Size = new System.Drawing.Size(34, 23);
            this.txtTargetX.TabIndex = 3;
            this.txtTargetX.Text = "N/A";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(13, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 15);
            this.label19.TabIndex = 2;
            this.label19.Text = "Location:";
            // 
            // cmdExecute
            // 
            this.cmdExecute.Location = new System.Drawing.Point(12, 766);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(109, 23);
            this.cmdExecute.TabIndex = 12;
            this.cmdExecute.Text = "Draw";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // WindowGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1335, 801);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "WindowGameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WindowGameBoard_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowGameBoard_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSpacecraftDirection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSpacecraftY;
        private System.Windows.Forms.TextBox txtSpacecraftX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAgility;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMouseY;
        private System.Windows.Forms.TextBox txtMouseX;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtTargetY;
        private System.Windows.Forms.TextBox txtTargetX;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button cmdExecute;
    }
}

