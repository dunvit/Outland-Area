
namespace Engine.UI.Screens
{
    partial class WindowTacticalLayerContainer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.crlCommandsContainer = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gameSessionInformation1 = new Engine.UI.Controls.GameSessionInformation();
            this.crlTacticalMap = new Engine.UI.Controls.TacticalMap();
            this.panel1.SuspendLayout();
            this.crlCommandsContainer.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.crlCommandsContainer);
            this.panel1.Controls.Add(this.gameSessionInformation1);
            this.panel1.Controls.Add(this.crlTacticalMap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // crlCommandsContainer
            // 
            this.crlCommandsContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.crlCommandsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlCommandsContainer.Controls.Add(this.panel3);
            this.crlCommandsContainer.Location = new System.Drawing.Point(11, 181);
            this.crlCommandsContainer.Name = "crlCommandsContainer";
            this.crlCommandsContainer.Size = new System.Drawing.Size(246, 168);
            this.crlCommandsContainer.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 26);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(226, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "x";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Commands";
            // 
            // gameSessionInformation1
            // 
            this.gameSessionInformation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.gameSessionInformation1.Location = new System.Drawing.Point(11, 11);
            this.gameSessionInformation1.Name = "gameSessionInformation1";
            this.gameSessionInformation1.Size = new System.Drawing.Size(246, 148);
            this.gameSessionInformation1.TabIndex = 0;
            // 
            // crlTacticalMap
            // 
            this.crlTacticalMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.crlTacticalMap.Location = new System.Drawing.Point(302, 85);
            this.crlTacticalMap.Name = "crlTacticalMap";
            this.crlTacticalMap.Size = new System.Drawing.Size(274, 247);
            this.crlTacticalMap.TabIndex = 1;
            this.crlTacticalMap.Load += new System.EventHandler(this.crlTacticalMap_Load);
            // 
            // WindowTacticalLayerContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowTacticalLayerContainer";
            this.Text = "WindowTacticalLayerContainer";
            this.Load += new System.EventHandler(this.Event_LoadTacticalLayer);
            this.panel1.ResumeLayout(false);
            this.crlCommandsContainer.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controls.GameSessionInformation gameSessionInformation1;
        private Controls.TacticalMap crlTacticalMap;
        private System.Windows.Forms.Panel crlCommandsContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}