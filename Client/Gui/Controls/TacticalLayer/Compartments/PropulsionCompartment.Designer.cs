
namespace Engine.Gui.Controls.TacticalLayer.Compartments
{
    partial class PropulsionCompartment
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.commandTurn = new Engine.Gui.Controls.TacticalLayer.Modules.PropulsionTurn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDirection = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 68);
            this.panel2.TabIndex = 45;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtVelocity);
            this.panel3.Controls.Add(this.txtDirection);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(7, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(167, 68);
            this.panel3.TabIndex = 46;
            // 
            // commandTurn
            // 
            this.commandTurn.BackColor = System.Drawing.Color.Black;
            this.commandTurn.Location = new System.Drawing.Point(11, 4);
            this.commandTurn.Name = "commandTurn";
            this.commandTurn.Size = new System.Drawing.Size(48, 62);
            this.commandTurn.TabIndex = 47;
            this.commandTurn.Type = OutlandAreaCommon.Universe.CommandTypes.MoveForward;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 11);
            this.label2.TabIndex = 36;
            this.label2.Text = "DIRECTION";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 10);
            this.label3.TabIndex = 37;
            this.label3.Text = "VELOCITY";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(7, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 11);
            this.label4.TabIndex = 38;
            this.label4.Text = "AGILITY";
            // 
            // txtDirection
            // 
            this.txtDirection.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirection.ForeColor = System.Drawing.Color.Orange;
            this.txtDirection.Location = new System.Drawing.Point(87, 4);
            this.txtDirection.Name = "txtDirection";
            this.txtDirection.Size = new System.Drawing.Size(37, 11);
            this.txtDirection.TabIndex = 39;
            this.txtDirection.Text = "217";
            this.txtDirection.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtVelocity
            // 
            this.txtVelocity.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVelocity.ForeColor = System.Drawing.Color.Orange;
            this.txtVelocity.Location = new System.Drawing.Point(87, 25);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(37, 11);
            this.txtVelocity.TabIndex = 40;
            this.txtVelocity.Text = "217";
            this.txtVelocity.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(87, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 11);
            this.label7.TabIndex = 41;
            this.label7.Text = "1";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(126, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 22);
            this.label8.TabIndex = 42;
            this.label8.Text = "dgr";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(126, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 22);
            this.label9.TabIndex = 43;
            this.label9.Text = "m/s";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkGray;
            this.label10.Location = new System.Drawing.Point(126, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 22);
            this.label10.TabIndex = 44;
            this.label10.Text = "dgr/s";
            // 
            // PropulsionCompartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commandTurn);
            this.Controls.Add(this.panel3);
            this.Name = "PropulsionCompartment";
            this.Controls.SetChildIndex(this.moduleFirst, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.commandTurn, 0);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Modules.PropulsionTurn commandTurn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtVelocity;
        private System.Windows.Forms.Label txtDirection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
