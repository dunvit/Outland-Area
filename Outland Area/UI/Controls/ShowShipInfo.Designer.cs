
namespace Engine.UI.Controls
{
    partial class ShowShipInfo
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
            this.txtCelestialObjectName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.containerData = new System.Windows.Forms.Panel();
            this.crlShields = new Engine.UI.Controls.ProgressBarVerticalHorizontal();
            this.progressBarVerticalHorizontal1 = new Engine.UI.Controls.ProgressBarVerticalHorizontal();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBarVerticalHorizontal2 = new Engine.UI.Controls.ProgressBarVerticalHorizontal();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.progressBarVerticalHorizontal3 = new Engine.UI.Controls.ProgressBarVerticalHorizontal();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.progressBarVerticalHorizontal4 = new Engine.UI.Controls.ProgressBarVerticalHorizontal();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.Label();
            this.txtDirection = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.containerData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCelestialObjectName
            // 
            this.txtCelestialObjectName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCelestialObjectName.Font = new System.Drawing.Font("Protomolecule", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCelestialObjectName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtCelestialObjectName.Location = new System.Drawing.Point(0, 0);
            this.txtCelestialObjectName.Name = "txtCelestialObjectName";
            this.txtCelestialObjectName.Size = new System.Drawing.Size(178, 20);
            this.txtCelestialObjectName.TabIndex = 9;
            this.txtCelestialObjectName.Text = "ENEMY SHIP NAME";
            this.txtCelestialObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(23, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "SHIELDS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(9, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(8, 8);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // containerData
            // 
            this.containerData.Controls.Add(this.txtSpeed);
            this.containerData.Controls.Add(this.txtDirection);
            this.containerData.Controls.Add(this.txtDistance);
            this.containerData.Controls.Add(this.label8);
            this.containerData.Controls.Add(this.label7);
            this.containerData.Controls.Add(this.label6);
            this.containerData.Controls.Add(this.progressBarVerticalHorizontal4);
            this.containerData.Controls.Add(this.label5);
            this.containerData.Controls.Add(this.pictureBox5);
            this.containerData.Controls.Add(this.progressBarVerticalHorizontal3);
            this.containerData.Controls.Add(this.label3);
            this.containerData.Controls.Add(this.pictureBox4);
            this.containerData.Controls.Add(this.progressBarVerticalHorizontal2);
            this.containerData.Controls.Add(this.label2);
            this.containerData.Controls.Add(this.pictureBox3);
            this.containerData.Controls.Add(this.progressBarVerticalHorizontal1);
            this.containerData.Controls.Add(this.label1);
            this.containerData.Controls.Add(this.pictureBox2);
            this.containerData.Controls.Add(this.crlShields);
            this.containerData.Controls.Add(this.label4);
            this.containerData.Controls.Add(this.pictureBox1);
            this.containerData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerData.Location = new System.Drawing.Point(0, 22);
            this.containerData.Name = "containerData";
            this.containerData.Size = new System.Drawing.Size(178, 106);
            this.containerData.TabIndex = 12;
            this.containerData.Visible = false;
            // 
            // crlShields
            // 
            this.crlShields.BackColor = System.Drawing.Color.Maroon;
            this.crlShields.BarLineColor = System.Drawing.Color.DarkSlateBlue;
            this.crlShields.CurrentValue = 100;
            this.crlShields.Location = new System.Drawing.Point(94, 3);
            this.crlShields.Maximum = 100;
            this.crlShields.Name = "crlShields";
            this.crlShields.Size = new System.Drawing.Size(74, 8);
            this.crlShields.TabIndex = 12;
            // 
            // progressBarVerticalHorizontal1
            // 
            this.progressBarVerticalHorizontal1.BackColor = System.Drawing.Color.Maroon;
            this.progressBarVerticalHorizontal1.BarLineColor = System.Drawing.Color.DarkSlateBlue;
            this.progressBarVerticalHorizontal1.CurrentValue = 100;
            this.progressBarVerticalHorizontal1.Location = new System.Drawing.Point(94, 15);
            this.progressBarVerticalHorizontal1.Maximum = 100;
            this.progressBarVerticalHorizontal1.Name = "progressBarVerticalHorizontal1";
            this.progressBarVerticalHorizontal1.Size = new System.Drawing.Size(74, 8);
            this.progressBarVerticalHorizontal1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "PROPULSION";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(9, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(8, 8);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // progressBarVerticalHorizontal2
            // 
            this.progressBarVerticalHorizontal2.BackColor = System.Drawing.Color.Maroon;
            this.progressBarVerticalHorizontal2.BarLineColor = System.Drawing.Color.DarkSlateBlue;
            this.progressBarVerticalHorizontal2.CurrentValue = 100;
            this.progressBarVerticalHorizontal2.Location = new System.Drawing.Point(94, 27);
            this.progressBarVerticalHorizontal2.Maximum = 100;
            this.progressBarVerticalHorizontal2.Name = "progressBarVerticalHorizontal2";
            this.progressBarVerticalHorizontal2.Size = new System.Drawing.Size(74, 8);
            this.progressBarVerticalHorizontal2.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "ENERGY";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(9, 27);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(8, 8);
            this.pictureBox3.TabIndex = 17;
            this.pictureBox3.TabStop = false;
            // 
            // progressBarVerticalHorizontal3
            // 
            this.progressBarVerticalHorizontal3.BackColor = System.Drawing.Color.Maroon;
            this.progressBarVerticalHorizontal3.BarLineColor = System.Drawing.Color.DarkSlateBlue;
            this.progressBarVerticalHorizontal3.CurrentValue = 100;
            this.progressBarVerticalHorizontal3.Location = new System.Drawing.Point(94, 39);
            this.progressBarVerticalHorizontal3.Maximum = 100;
            this.progressBarVerticalHorizontal3.Name = "progressBarVerticalHorizontal3";
            this.progressBarVerticalHorizontal3.Size = new System.Drawing.Size(74, 8);
            this.progressBarVerticalHorizontal3.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(23, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 19;
            this.label3.Text = "WEAPON";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(9, 39);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(8, 8);
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // progressBarVerticalHorizontal4
            // 
            this.progressBarVerticalHorizontal4.BackColor = System.Drawing.Color.Maroon;
            this.progressBarVerticalHorizontal4.BarLineColor = System.Drawing.Color.DarkSlateBlue;
            this.progressBarVerticalHorizontal4.CurrentValue = 100;
            this.progressBarVerticalHorizontal4.Location = new System.Drawing.Point(94, 51);
            this.progressBarVerticalHorizontal4.Maximum = 100;
            this.progressBarVerticalHorizontal4.Name = "progressBarVerticalHorizontal4";
            this.progressBarVerticalHorizontal4.Size = new System.Drawing.Size(74, 8);
            this.progressBarVerticalHorizontal4.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(23, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "DEFENSE";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(9, 51);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(8, 8);
            this.pictureBox5.TabIndex = 23;
            this.pictureBox5.TabStop = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.LightGray;
            this.label6.Location = new System.Drawing.Point(23, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "DISTANCE";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.LightGray;
            this.label7.Location = new System.Drawing.Point(23, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "DIRECTION";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(23, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "SPEED";
            // 
            // txtDistance
            // 
            this.txtDistance.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDistance.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDistance.Location = new System.Drawing.Point(94, 67);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(54, 12);
            this.txtDistance.TabIndex = 28;
            this.txtDistance.Text = "0";
            // 
            // txtDirection
            // 
            this.txtDirection.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDirection.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDirection.Location = new System.Drawing.Point(94, 79);
            this.txtDirection.Name = "txtDirection";
            this.txtDirection.Size = new System.Drawing.Size(54, 12);
            this.txtDirection.TabIndex = 29;
            this.txtDirection.Text = "0";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtSpeed.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSpeed.Location = new System.Drawing.Point(94, 91);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(54, 12);
            this.txtSpeed.TabIndex = 30;
            this.txtSpeed.Text = "0";
            // 
            // ShowShipInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.containerData);
            this.Controls.Add(this.txtCelestialObjectName);
            this.Name = "ShowShipInfo";
            this.Size = new System.Drawing.Size(178, 128);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.containerData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtCelestialObjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel containerData;
        private ProgressBarVerticalHorizontal crlShields;
        private System.Windows.Forms.Label txtSpeed;
        private System.Windows.Forms.Label txtDirection;
        private System.Windows.Forms.Label txtDistance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ProgressBarVerticalHorizontal progressBarVerticalHorizontal4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private ProgressBarVerticalHorizontal progressBarVerticalHorizontal3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private ProgressBarVerticalHorizontal progressBarVerticalHorizontal2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ProgressBarVerticalHorizontal progressBarVerticalHorizontal1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
