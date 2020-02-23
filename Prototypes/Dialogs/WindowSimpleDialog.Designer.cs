namespace Prototypes.Dialogs
{
    partial class WindowSimpleDialog
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.Label();
            this.btnAnswearFirst = new System.Windows.Forms.Button();
            this.btnAnswearSecond = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(637, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtMessage.Location = new System.Drawing.Point(12, 12);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(619, 376);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.Text = "label1";
            // 
            // btnAnswearFirst
            // 
            this.btnAnswearFirst.BackColor = System.Drawing.Color.Black;
            this.btnAnswearFirst.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAnswearFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswearFirst.ForeColor = System.Drawing.Color.Orange;
            this.btnAnswearFirst.Location = new System.Drawing.Point(273, 404);
            this.btnAnswearFirst.Name = "btnAnswearFirst";
            this.btnAnswearFirst.Size = new System.Drawing.Size(329, 36);
            this.btnAnswearFirst.TabIndex = 2;
            this.btnAnswearFirst.Text = "button1";
            this.btnAnswearFirst.UseVisualStyleBackColor = false;
            this.btnAnswearFirst.Visible = false;
            this.btnAnswearFirst.Click += new System.EventHandler(this.Event_Exit);
            // 
            // btnAnswearSecond
            // 
            this.btnAnswearSecond.BackColor = System.Drawing.Color.Black;
            this.btnAnswearSecond.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAnswearSecond.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswearSecond.ForeColor = System.Drawing.Color.Orange;
            this.btnAnswearSecond.Location = new System.Drawing.Point(273, 446);
            this.btnAnswearSecond.Name = "btnAnswearSecond";
            this.btnAnswearSecond.Size = new System.Drawing.Size(329, 36);
            this.btnAnswearSecond.TabIndex = 3;
            this.btnAnswearSecond.Text = "button2";
            this.btnAnswearSecond.UseVisualStyleBackColor = false;
            this.btnAnswearSecond.Visible = false;
            this.btnAnswearSecond.Click += new System.EventHandler(this.Event_Exit);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(619, 466);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(218, 32);
            this.txtId.TabIndex = 4;
            this.txtId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WindowSimpleDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(849, 507);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAnswearSecond);
            this.Controls.Add(this.btnAnswearFirst);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowSimpleDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WindowSimpleDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtMessage;
        private System.Windows.Forms.Button btnAnswearFirst;
        private System.Windows.Forms.Button btnAnswearSecond;
        private System.Windows.Forms.Label txtId;
    }
}