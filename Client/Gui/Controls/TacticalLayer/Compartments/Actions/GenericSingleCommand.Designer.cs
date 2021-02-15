
namespace Engine.Gui.Controls.TacticalLayer.Compartments.Actions
{
    partial class GenericSingleCommand
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
            this.imageCommand = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageCommand)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCommand
            // 
            this.imageCommand.Location = new System.Drawing.Point(3, 3);
            this.imageCommand.Name = "imageCommand";
            this.imageCommand.Size = new System.Drawing.Size(42, 42);
            this.imageCommand.TabIndex = 41;
            this.imageCommand.TabStop = false;
            // 
            // GenericSingleCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imageCommand);
            this.Name = "GenericSingleCommand";
            this.Load += new System.EventHandler(this.GenericSingleCommand_Load);
            this.Controls.SetChildIndex(this.moduleFirstReloadBar, 0);
            this.Controls.SetChildIndex(this.imageCommand, 0);
            ((System.ComponentModel.ISupportInitialize)(this.imageCommand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imageCommand;
    }
}
