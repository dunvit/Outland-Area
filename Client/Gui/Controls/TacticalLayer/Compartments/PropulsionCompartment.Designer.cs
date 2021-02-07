
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Modules.PropulsionTurn commandTurn;
    }
}
