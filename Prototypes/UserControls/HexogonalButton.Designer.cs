namespace Engine.UserControls
{
    partial class HexogonalButton
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imageAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Cambria", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(56, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "NAVIGATION";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(16, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.label1_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            // 
            // imageAvatar
            // 
            this.imageAvatar.BackColor = System.Drawing.Color.Transparent;
            this.imageAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imageAvatar.Image = global::Engine.Properties.Resources.Hex2ButtonPng;
            this.imageAvatar.Location = new System.Drawing.Point(3, 1);
            this.imageAvatar.Name = "imageAvatar";
            this.imageAvatar.Size = new System.Drawing.Size(116, 61);
            this.imageAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageAvatar.TabIndex = 40;
            this.imageAvatar.TabStop = false;
            this.imageAvatar.Click += new System.EventHandler(this.label1_Click);
            this.imageAvatar.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.imageAvatar.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // HexogonalButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imageAvatar);
            this.DoubleBuffered = true;
            this.Name = "HexogonalButton";
            this.Size = new System.Drawing.Size(196, 74);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imageAvatar;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
