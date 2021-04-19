
namespace Engine.Gui.Prototype
{
    partial class screenPrototypeContainer
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
            this.weaponShotCalculation1 = new Engine.Gui.Prototype.WeaponShotCalculation.WeaponShotCalculation();
            this.moduleBase1 = new Engine.Gui.Prototype.ModuleBase();
            this.moduleReactor1 = new Engine.Gui.Prototype.ModuleReactor();
            this.moduleECM1 = new Engine.Gui.Prototype.ModuleECM();
            this.moduleWeaponLauncher1 = new Engine.Gui.Prototype.ModuleWeaponLauncher();
            this.modulePointDefenceTurret1 = new Engine.Gui.Prototype.ModulePointDefenceTurret();
            this.moduleNavigation1 = new Engine.Gui.Prototype.ModuleNavigation();
            this.containerTacticalScreen = new Engine.Gui.Prototype.controlPrototypeTacticalScreen();
            this.SuspendLayout();
            // 
            // weaponShotCalculation1
            // 
            this.weaponShotCalculation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(14)))), ((int)(((byte)(14)))));
            this.weaponShotCalculation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weaponShotCalculation1.Location = new System.Drawing.Point(551, 263);
            this.weaponShotCalculation1.Name = "weaponShotCalculation1";
            this.weaponShotCalculation1.Size = new System.Drawing.Size(586, 496);
            this.weaponShotCalculation1.TabIndex = 8;
            // 
            // moduleBase1
            // 
            this.moduleBase1.BackColor = System.Drawing.Color.Black;
            this.moduleBase1.Location = new System.Drawing.Point(1632, 849);
            this.moduleBase1.Name = "moduleBase1";
            this.moduleBase1.Size = new System.Drawing.Size(272, 219);
            this.moduleBase1.TabIndex = 7;
            // 
            // moduleReactor1
            // 
            this.moduleReactor1.BackColor = System.Drawing.Color.Black;
            this.moduleReactor1.Location = new System.Drawing.Point(984, 849);
            this.moduleReactor1.Name = "moduleReactor1";
            this.moduleReactor1.Size = new System.Drawing.Size(272, 219);
            this.moduleReactor1.TabIndex = 6;
            // 
            // moduleECM1
            // 
            this.moduleECM1.BackColor = System.Drawing.Color.Black;
            this.moduleECM1.Location = new System.Drawing.Point(1308, 849);
            this.moduleECM1.Name = "moduleECM1";
            this.moduleECM1.Size = new System.Drawing.Size(272, 219);
            this.moduleECM1.TabIndex = 5;
            // 
            // moduleWeaponLauncher1
            // 
            this.moduleWeaponLauncher1.BackColor = System.Drawing.Color.Black;
            this.moduleWeaponLauncher1.Location = new System.Drawing.Point(336, 849);
            this.moduleWeaponLauncher1.Name = "moduleWeaponLauncher1";
            this.moduleWeaponLauncher1.Size = new System.Drawing.Size(272, 219);
            this.moduleWeaponLauncher1.TabIndex = 4;
            // 
            // modulePointDefenceTurret1
            // 
            this.modulePointDefenceTurret1.BackColor = System.Drawing.Color.Black;
            this.modulePointDefenceTurret1.Location = new System.Drawing.Point(660, 849);
            this.modulePointDefenceTurret1.Name = "modulePointDefenceTurret1";
            this.modulePointDefenceTurret1.Size = new System.Drawing.Size(272, 219);
            this.modulePointDefenceTurret1.TabIndex = 2;
            // 
            // moduleNavigation1
            // 
            this.moduleNavigation1.BackColor = System.Drawing.Color.Black;
            this.moduleNavigation1.Location = new System.Drawing.Point(12, 849);
            this.moduleNavigation1.Name = "moduleNavigation1";
            this.moduleNavigation1.Size = new System.Drawing.Size(272, 219);
            this.moduleNavigation1.TabIndex = 1;
            // 
            // containerTacticalScreen
            // 
            this.containerTacticalScreen.BackColor = System.Drawing.Color.Black;
            this.containerTacticalScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.containerTacticalScreen.Location = new System.Drawing.Point(841, 331);
            this.containerTacticalScreen.Name = "containerTacticalScreen";
            this.containerTacticalScreen.Size = new System.Drawing.Size(62, 50);
            this.containerTacticalScreen.TabIndex = 0;
            // 
            // screenPrototypeContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.weaponShotCalculation1);
            this.Controls.Add(this.moduleBase1);
            this.Controls.Add(this.moduleReactor1);
            this.Controls.Add(this.moduleECM1);
            this.Controls.Add(this.moduleWeaponLauncher1);
            this.Controls.Add(this.modulePointDefenceTurret1);
            this.Controls.Add(this.moduleNavigation1);
            this.Controls.Add(this.containerTacticalScreen);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "screenPrototypeContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "screenPrototypeContainer";
            this.Load += new System.EventHandler(this.Event_WindowLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private controlPrototypeTacticalScreen containerTacticalScreen;
        private ModuleNavigation moduleNavigation1;
        private ModulePointDefenceTurret modulePointDefenceTurret1;
        private ModuleWeaponLauncher moduleWeaponLauncher1;
        private ModuleECM moduleECM1;
        private ModuleReactor moduleReactor1;
        private ModuleBase moduleBase1;
        private WeaponShotCalculation.WeaponShotCalculation weaponShotCalculation1;
    }
}