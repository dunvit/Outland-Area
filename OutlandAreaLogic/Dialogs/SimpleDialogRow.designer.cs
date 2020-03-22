namespace WorkSpace.Prototypes
{
    partial class SimpleDialogRow
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
            this.txtMessage = new System.Windows.Forms.Label();
            this.simpleDialogCharacter2 = new WorkSpace.Prototypes.SimpleDialogCharacter();
            this.simpleDialogCharacter1 = new WorkSpace.Prototypes.SimpleDialogCharacter();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(195, 23);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(446, 183);
            this.txtMessage.TabIndex = 33;
            this.txtMessage.Visible = false;
            // 
            // simpleDialogCharacter2
            // 
            this.simpleDialogCharacter2.BackColor = System.Drawing.Color.Black;
            this.simpleDialogCharacter2.Location = new System.Drawing.Point(14, 3);
            this.simpleDialogCharacter2.Name = "simpleDialogCharacter2";
            this.simpleDialogCharacter2.Size = new System.Drawing.Size(175, 198);
            this.simpleDialogCharacter2.TabIndex = 35;
            this.simpleDialogCharacter2.Visible = false;
            // 
            // simpleDialogCharacter1
            // 
            this.simpleDialogCharacter1.BackColor = System.Drawing.Color.Black;
            this.simpleDialogCharacter1.Location = new System.Drawing.Point(647, 3);
            this.simpleDialogCharacter1.Name = "simpleDialogCharacter1";
            this.simpleDialogCharacter1.Size = new System.Drawing.Size(175, 198);
            this.simpleDialogCharacter1.TabIndex = 34;
            this.simpleDialogCharacter1.Visible = false;
            // 
            // SimpleDialogRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.simpleDialogCharacter2);
            this.Controls.Add(this.simpleDialogCharacter1);
            this.Controls.Add(this.txtMessage);
            this.DoubleBuffered = true;
            this.Name = "SimpleDialogRow";
            this.Size = new System.Drawing.Size(850, 206);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtMessage;
        private SimpleDialogCharacter simpleDialogCharacter1;
        private SimpleDialogCharacter simpleDialogCharacter2;
    }
}
