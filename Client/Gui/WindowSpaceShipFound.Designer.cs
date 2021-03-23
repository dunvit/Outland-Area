
namespace Engine.Gui
{
    partial class WindowSpaceShipFound
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtObjectClassification = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.flatButton1 = new Engine.Gui.Controls.Common.FlatButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.flatButton2 = new Engine.Gui.Controls.Common.FlatButton();
            this.label8 = new System.Windows.Forms.Label();
            this.flatButton3 = new Engine.Gui.Controls.Common.FlatButton();
            this.label9 = new System.Windows.Forms.Label();
            this.flatButton4 = new Engine.Gui.Controls.Common.FlatButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.flatButton4);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.flatButton3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.flatButton2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtObjectClassification);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.flatButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 2;
            // 
            // txtObjectClassification
            // 
            this.txtObjectClassification.BackColor = System.Drawing.Color.Transparent;
            this.txtObjectClassification.Font = new System.Drawing.Font("Protomolecule", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObjectClassification.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtObjectClassification.Location = new System.Drawing.Point(205, 21);
            this.txtObjectClassification.Name = "txtObjectClassification";
            this.txtObjectClassification.Size = new System.Drawing.Size(339, 26);
            this.txtObjectClassification.TabIndex = 17;
            this.txtObjectClassification.Text = "UNKNOWN SPACESHIP DISCOVERED";
            this.txtObjectClassification.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Orange;
            this.label15.Location = new System.Drawing.Point(611, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 11);
            this.label15.TabIndex = 30;
            this.label15.Text = "DANA MOOR";
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Black;
            this.flatButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.flatButton1.FlatAppearance.BorderSize = 0;
            this.flatButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.flatButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.White;
            this.flatButton1.Location = new System.Drawing.Point(236, 263);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(117, 23);
            this.flatButton1.TabIndex = 0;
            this.flatButton1.Text = "We keep moving";
            this.flatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton1.UseVisualStyleBackColor = false;
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(384, 98);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(206, 131);
            this.richTextBox1.TabIndex = 32;
            this.richTextBox1.Text = "Captain. The navigation service has discovered a new space object. It has a 97% c" +
    "hance of being an artificial body.\nSpeed - 200\nDirection - 200\nSignature - 200\nS" +
    "ize - frigate";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::Engine.Properties.Resources.Right1;
            this.pictureBox2.Location = new System.Drawing.Point(22, 231);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 141);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Engine.Properties.Resources.Left;
            this.pictureBox1.Location = new System.Drawing.Point(613, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(20, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 11);
            this.label1.TabIndex = 34;
            this.label1.Text = "RICHARD REDFORD";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(20, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 11);
            this.label2.TabIndex = 35;
            this.label2.Text = "CAPTAIN";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(611, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 11);
            this.label3.TabIndex = 36;
            this.label3.Text = "LIEUTENANT";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MintCream;
            this.label4.Location = new System.Drawing.Point(20, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 11);
            this.label4.TabIndex = 37;
            this.label4.Text = "COMMAND CENTER";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MintCream;
            this.label5.Location = new System.Drawing.Point(611, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 11);
            this.label5.TabIndex = 38;
            this.label5.Text = "SCAN CENTER";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Rod", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(205, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 19);
            this.label6.TabIndex = 39;
            this.label6.Text = "1";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Rod", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(205, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "2";
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.Black;
            this.flatButton2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.flatButton2.FlatAppearance.BorderSize = 0;
            this.flatButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.flatButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.flatButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton2.ForeColor = System.Drawing.Color.White;
            this.flatButton2.Location = new System.Drawing.Point(236, 292);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Size = new System.Drawing.Size(173, 23);
            this.flatButton2.TabIndex = 40;
            this.flatButton2.Text = "Connect with this spaceship";
            this.flatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton2.UseVisualStyleBackColor = false;
            this.flatButton2.Click += new System.EventHandler(this.flatButton2_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Rod", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(205, 323);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 19);
            this.label8.TabIndex = 43;
            this.label8.Text = "3";
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.Black;
            this.flatButton3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.flatButton3.FlatAppearance.BorderSize = 0;
            this.flatButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.flatButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.flatButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton3.ForeColor = System.Drawing.Color.White;
            this.flatButton3.Location = new System.Drawing.Point(236, 321);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Size = new System.Drawing.Size(173, 23);
            this.flatButton3.TabIndex = 42;
            this.flatButton3.Text = "Alert to all posts!";
            this.flatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton3.UseVisualStyleBackColor = false;
            this.flatButton3.Click += new System.EventHandler(this.flatButton3_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Rod", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(205, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 19);
            this.label9.TabIndex = 45;
            this.label9.Text = "4";
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.Black;
            this.flatButton4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.flatButton4.FlatAppearance.BorderSize = 0;
            this.flatButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.flatButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.flatButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton4.ForeColor = System.Drawing.Color.White;
            this.flatButton4.Location = new System.Drawing.Point(236, 350);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Size = new System.Drawing.Size(173, 23);
            this.flatButton4.TabIndex = 44;
            this.flatButton4.Text = "Evasion mode";
            this.flatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flatButton4.UseVisualStyleBackColor = false;
            this.flatButton4.Click += new System.EventHandler(this.flatButton4_Click);
            // 
            // WindowSpaceShipFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowSpaceShipFound";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WindowSpaceShipFound";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.Common.FlatButton flatButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtObjectClassification;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label9;
        private Controls.Common.FlatButton flatButton4;
        private System.Windows.Forms.Label label8;
        private Controls.Common.FlatButton flatButton3;
        private System.Windows.Forms.Label label7;
        private Controls.Common.FlatButton flatButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}