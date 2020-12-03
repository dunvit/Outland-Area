namespace Engine.Gui.Controls.TacticalLayer
{
    partial class GenericCompartment
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.crlTitlebar = new System.Windows.Forms.Panel();
            this.txtWeaponName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 33;
            this.pictureBox3.TabStop = false;
            // 
            // crlTitlebar
            // 
            this.crlTitlebar.BackColor = System.Drawing.Color.Firebrick;
            this.crlTitlebar.Location = new System.Drawing.Point(42, 3);
            this.crlTitlebar.Name = "crlTitlebar";
            this.crlTitlebar.Size = new System.Drawing.Size(246, 36);
            this.crlTitlebar.TabIndex = 32;
            this.crlTitlebar.Click += new System.EventHandler(this.Event_ChangeVisibility);
            this.crlTitlebar.DoubleClick += new System.EventHandler(this.Event_ChangeVisibility);
            // 
            // txtWeaponName
            // 
            this.txtWeaponName.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeaponName.ForeColor = System.Drawing.Color.Chocolate;
            this.txtWeaponName.Location = new System.Drawing.Point(3, 43);
            this.txtWeaponName.Name = "txtWeaponName";
            this.txtWeaponName.Size = new System.Drawing.Size(222, 11);
            this.txtWeaponName.TabIndex = 34;
            this.txtWeaponName.Text = "GENERIC MODULE NAME";
            // 
            // GenericCompartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtWeaponName);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.crlTitlebar);
            this.Name = "GenericCompartment";
            this.Size = new System.Drawing.Size(290, 207);
            this.Load += new System.EventHandler(this.GenericCompartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel crlTitlebar;
        private System.Windows.Forms.Label txtWeaponName;
    }
}
