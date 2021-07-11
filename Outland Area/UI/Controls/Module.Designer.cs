
namespace Engine.UI.Controls
{
    partial class Module
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
            this.crlModuleName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.crlReloading = new Engine.UI.Controls.ProgressBarVerticalHorizontal();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.actionsContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // crlModuleName
            // 
            this.crlModuleName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crlModuleName.Dock = System.Windows.Forms.DockStyle.Top;
            this.crlModuleName.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crlModuleName.ForeColor = System.Drawing.Color.Peru;
            this.crlModuleName.Location = new System.Drawing.Point(0, 0);
            this.crlModuleName.Name = "crlModuleName";
            this.crlModuleName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.crlModuleName.Size = new System.Drawing.Size(277, 26);
            this.crlModuleName.TabIndex = 5;
            this.crlModuleName.Text = "Module Name       ";
            this.crlModuleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(260, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(15, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Event_CloseModule);
            // 
            // crlReloading
            // 
            this.crlReloading.BackColor = System.Drawing.Color.DimGray;
            this.crlReloading.BarLineColor = System.Drawing.Color.DarkOliveGreen;
            this.crlReloading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlReloading.CurrentValue = 100;
            this.crlReloading.Location = new System.Drawing.Point(13, 27);
            this.crlReloading.Maximum = 100;
            this.crlReloading.Name = "crlReloading";
            this.crlReloading.Size = new System.Drawing.Size(251, 10);
            this.crlReloading.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(220, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(15, 26);
            this.button2.TabIndex = 8;
            this.button2.Text = "o";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(241, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(15, 26);
            this.button3.TabIndex = 9;
            this.button3.Text = "i";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // actionsContainer
            // 
            this.actionsContainer.Location = new System.Drawing.Point(13, 42);
            this.actionsContainer.Name = "actionsContainer";
            this.actionsContainer.Size = new System.Drawing.Size(250, 55);
            this.actionsContainer.TabIndex = 10;
            // 
            // Module
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.actionsContainer);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.crlReloading);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.crlModuleName);
            this.Name = "Module";
            this.Size = new System.Drawing.Size(277, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label crlModuleName;
        private System.Windows.Forms.Button button1;
        private ProgressBarVerticalHorizontal crlReloading;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel actionsContainer;
    }
}
