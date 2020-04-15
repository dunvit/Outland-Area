namespace Engine
{
    partial class WindowResizeTests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowResizeTests));
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleDialogCharacter2 = new WorkSpace.Prototypes.SimpleDialogCharacter();
            this.simpleDialogCharacter1 = new WorkSpace.Prototypes.SimpleDialogCharacter();
            this.testControl1 = new Engine.TestControl();
            this.oaButton1 = new OutlandAreaLogic.Controls.OaButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.simpleDialogCharacter2);
            this.panel1.Controls.Add(this.simpleDialogCharacter1);
            this.panel1.Controls.Add(this.testControl1);
            this.panel1.Controls.Add(this.oaButton1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 720);
            this.panel1.TabIndex = 0;
            // 
            // simpleDialogCharacter2
            // 
            this.simpleDialogCharacter2.BackColor = System.Drawing.Color.Transparent;
            this.simpleDialogCharacter2.Location = new System.Drawing.Point(135, 383);
            this.simpleDialogCharacter2.Name = "simpleDialogCharacter2";
            this.simpleDialogCharacter2.Size = new System.Drawing.Size(175, 198);
            this.simpleDialogCharacter2.TabIndex = 10;
            // 
            // simpleDialogCharacter1
            // 
            this.simpleDialogCharacter1.BackColor = System.Drawing.Color.Transparent;
            this.simpleDialogCharacter1.Location = new System.Drawing.Point(715, 61);
            this.simpleDialogCharacter1.Name = "simpleDialogCharacter1";
            this.simpleDialogCharacter1.Size = new System.Drawing.Size(175, 198);
            this.simpleDialogCharacter1.TabIndex = 9;
            // 
            // testControl1
            // 
            this.testControl1.Location = new System.Drawing.Point(924, 268);
            this.testControl1.Name = "testControl1";
            this.testControl1.Size = new System.Drawing.Size(150, 150);
            this.testControl1.TabIndex = 8;
            // 
            // oaButton1
            // 
            this.oaButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.oaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.oaButton1.Location = new System.Drawing.Point(599, 268);
            this.oaButton1.Name = "oaButton1";
            this.oaButton1.Size = new System.Drawing.Size(117, 23);
            this.oaButton1.TabIndex = 7;
            this.oaButton1.Text = "oaButton1";
            this.oaButton1.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1252, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "1366 × 768";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "1920 x 1080";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "1280 × 720";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WindowResizeTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowResizeTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WindowResizeTests";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private OutlandAreaLogic.Controls.OaButton oaButton1;
        private TestControl testControl1;
        private WorkSpace.Prototypes.SimpleDialogCharacter simpleDialogCharacter2;
        private WorkSpace.Prototypes.SimpleDialogCharacter simpleDialogCharacter1;
    }
}