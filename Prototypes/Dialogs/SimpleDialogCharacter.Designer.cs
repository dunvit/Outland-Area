namespace WorkSpace.Prototypes
{
    partial class SimpleDialogCharacter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleDialogCharacter));
            this.txtRank = new System.Windows.Forms.Label();
            this.txtCelestialObjectName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.imageAvatar = new System.Windows.Forms.PictureBox();
            this.txtRelations = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRank
            // 
            this.txtRank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtRank.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRank.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.txtRank.Location = new System.Drawing.Point(1, 155);
            this.txtRank.Name = "txtRank";
            this.txtRank.Size = new System.Drawing.Size(171, 17);
            this.txtRank.TabIndex = 41;
            this.txtRank.Text = "Штурман";
            this.txtRank.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCelestialObjectName
            // 
            this.txtCelestialObjectName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCelestialObjectName.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelestialObjectName.ForeColor = System.Drawing.Color.OliveDrab;
            this.txtCelestialObjectName.Location = new System.Drawing.Point(1, 138);
            this.txtCelestialObjectName.Name = "txtCelestialObjectName";
            this.txtCelestialObjectName.Size = new System.Drawing.Size(171, 17);
            this.txtCelestialObjectName.TabIndex = 42;
            this.txtCelestialObjectName.Text = "ERL-829 \"Badsworth\"";
            this.txtCelestialObjectName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtName
            // 
            this.txtName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtName.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.NavajoWhite;
            this.txtName.Location = new System.Drawing.Point(1, 1);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(171, 17);
            this.txtName.TabIndex = 40;
            this.txtName.Text = "Аврора Беннет";
            this.txtName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imageAvatar
            // 
            this.imageAvatar.BackColor = System.Drawing.Color.DimGray;
            this.imageAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageAvatar.Image = ((System.Drawing.Image)(resources.GetObject("imageAvatar.Image")));
            this.imageAvatar.Location = new System.Drawing.Point(30, 21);
            this.imageAvatar.Name = "imageAvatar";
            this.imageAvatar.Size = new System.Drawing.Size(116, 114);
            this.imageAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageAvatar.TabIndex = 39;
            this.imageAvatar.TabStop = false;
            // 
            // txtRelations
            // 
            this.txtRelations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtRelations.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelations.ForeColor = System.Drawing.Color.DarkKhaki;
            this.txtRelations.Location = new System.Drawing.Point(1, 172);
            this.txtRelations.Name = "txtRelations";
            this.txtRelations.Size = new System.Drawing.Size(171, 17);
            this.txtRelations.TabIndex = 43;
            this.txtRelations.Text = "Дружелюбна";
            this.txtRelations.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SimpleDialogCharacter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtRelations);
            this.Controls.Add(this.txtRank);
            this.Controls.Add(this.txtCelestialObjectName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.imageAvatar);
            this.DoubleBuffered = true;
            this.Name = "SimpleDialogCharacter";
            this.Size = new System.Drawing.Size(175, 198);
            ((System.ComponentModel.ISupportInitialize)(this.imageAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtRank;
        private System.Windows.Forms.Label txtCelestialObjectName;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.PictureBox imageAvatar;
        private System.Windows.Forms.Label txtRelations;
    }
}
