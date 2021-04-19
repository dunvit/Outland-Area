
namespace Engine.Gui.Prototype.TargetSelector
{
    partial class TargetSelector
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
            this.txtName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.SandyBrown;
            this.txtName.Location = new System.Drawing.Point(94, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(53, 11);
            this.txtName.TabIndex = 66;
            this.txtName.Text = "SPEED";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SandyBrown;
            this.label1.Location = new System.Drawing.Point(153, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 11);
            this.label1.TabIndex = 67;
            this.label1.Text = "DISTANCE";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SandyBrown;
            this.label2.Location = new System.Drawing.Point(236, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 11);
            this.label2.TabIndex = 68;
            this.label2.Text = "SIGNATURE";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SandyBrown;
            this.label3.Location = new System.Drawing.Point(21, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 11);
            this.label3.TabIndex = 69;
            this.label3.Text = "PILOT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 21);
            this.panel1.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Rod", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MistyRose;
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 11);
            this.label4.TabIndex = 71;
            this.label4.Text = "SELECT TARGET";
            // 
            // TargetSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.DoubleBuffered = true;
            this.Name = "TargetSelector";
            this.Size = new System.Drawing.Size(333, 144);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}
