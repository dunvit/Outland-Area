namespace OutlandAreaLogic.Controls
{
    partial class OaButton
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
            this.SuspendLayout();
            // 
            // OaButton
            // 
            this.Size = new System.Drawing.Size(211, 69);
            this.MouseLeave += new System.EventHandler(this.OaButton_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OaButton_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
