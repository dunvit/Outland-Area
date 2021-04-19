namespace Engine.Gui
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
            this.flatButton1 = new Engine.Gui.Controls.Common.FlatButton();
            this.cmdRunGame = new Engine.Gui.Controls.Common.FlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crlTacticalMap = new Engine.Gui.Controls.TacticalMap();
            this.battleInformation1 = new Engine.Gui.Controls.TacticalLayer.BattleInformation();
            this.crlSelectedObject = new Engine.Gui.Controls.TacticalLayer.SelectedBaseCelestialObject();
            this.weaponCompartment1 = new Engine.Gui.Controls.TacticalLayer.Compartments.WeaponCompartment();
            this.scanningCompartment = new Engine.Gui.Controls.TacticalLayer.Compartments.ScanningCompartment();
            this.propulsionCompartment1 = new Engine.Gui.Controls.TacticalLayer.Compartments.PropulsionCompartment();
            this.tacticalScreen1 = new Engine.Gui.TacticalScreen();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.flatButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.flatButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.flatButton1.Location = new System.Drawing.Point(3, 32);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(117, 23);
            this.flatButton1.TabIndex = 0;
            this.flatButton1.Text = "Exit";
            this.flatButton1.UseVisualStyleBackColor = false;
            this.flatButton1.Click += new System.EventHandler(this.Event_Exit);
            // 
            // cmdRunGame
            // 
            this.cmdRunGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cmdRunGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmdRunGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.cmdRunGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRunGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.cmdRunGame.Location = new System.Drawing.Point(3, 3);
            this.cmdRunGame.Name = "cmdRunGame";
            this.cmdRunGame.Size = new System.Drawing.Size(117, 23);
            this.cmdRunGame.TabIndex = 2;
            this.cmdRunGame.Text = "Run";
            this.cmdRunGame.UseVisualStyleBackColor = false;
            this.cmdRunGame.Click += new System.EventHandler(this.Event_ResumeGame);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdRunGame);
            this.panel1.Controls.Add(this.flatButton1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 60);
            this.panel1.TabIndex = 3;
            // 
            // crlTacticalMap
            // 
            this.crlTacticalMap.BackColor = System.Drawing.Color.Black;
            this.crlTacticalMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlTacticalMap.Location = new System.Drawing.Point(88, 131);
            this.crlTacticalMap.Name = "crlTacticalMap";
            this.crlTacticalMap.Size = new System.Drawing.Size(755, 634);
            this.crlTacticalMap.TabIndex = 5;
            // 
            // battleInformation1
            // 
            this.battleInformation1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.battleInformation1.Location = new System.Drawing.Point(-2, 109);
            this.battleInformation1.Name = "battleInformation1";
            this.battleInformation1.Size = new System.Drawing.Size(200, 244);
            this.battleInformation1.TabIndex = 12;
            this.battleInformation1.Visible = false;
            // 
            // crlSelectedObject
            // 
            this.crlSelectedObject.BackColor = System.Drawing.Color.Black;
            this.crlSelectedObject.Location = new System.Drawing.Point(1588, 12);
            this.crlSelectedObject.Name = "crlSelectedObject";
            this.crlSelectedObject.SelectedCelestialObject = null;
            this.crlSelectedObject.Size = new System.Drawing.Size(320, 184);
            this.crlSelectedObject.TabIndex = 14;
            // 
            // weaponCompartment1
            // 
            this.weaponCompartment1.BackColor = System.Drawing.Color.Black;
            this.weaponCompartment1.CompartmentModuleName = "WEAPON COMPARTMENT";
            this.weaponCompartment1.Location = new System.Drawing.Point(12, 903);
            this.weaponCompartment1.Name = "weaponCompartment1";
            this.weaponCompartment1.Size = new System.Drawing.Size(180, 165);
            this.weaponCompartment1.TabIndex = 18;
            // 
            // scanningCompartment
            // 
            this.scanningCompartment.BackColor = System.Drawing.Color.Black;
            this.scanningCompartment.CompartmentModuleName = "SCANNING COMPARTMENT";
            this.scanningCompartment.Location = new System.Drawing.Point(208, 903);
            this.scanningCompartment.Name = "scanningCompartment";
            this.scanningCompartment.Size = new System.Drawing.Size(180, 165);
            this.scanningCompartment.TabIndex = 19;
            // 
            // propulsionCompartment1
            // 
            this.propulsionCompartment1.BackColor = System.Drawing.Color.Black;
            this.propulsionCompartment1.CompartmentModuleName = "PROPULSION COMPARTMENT";
            this.propulsionCompartment1.Location = new System.Drawing.Point(407, 903);
            this.propulsionCompartment1.Name = "propulsionCompartment1";
            this.propulsionCompartment1.Size = new System.Drawing.Size(180, 165);
            this.propulsionCompartment1.TabIndex = 20;
            // 
            // tacticalScreen1
            // 
            this.tacticalScreen1.BackColor = System.Drawing.Color.Black;
            this.tacticalScreen1.Location = new System.Drawing.Point(284, 44);
            this.tacticalScreen1.Name = "tacticalScreen1";
            this.tacticalScreen1.Size = new System.Drawing.Size(150, 150);
            this.tacticalScreen1.TabIndex = 21;
            // 
            // WindowTacticalLayerContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tacticalScreen1);
            this.Controls.Add(this.propulsionCompartment1);
            this.Controls.Add(this.scanningCompartment);
            this.Controls.Add(this.weaponCompartment1);
            this.Controls.Add(this.crlSelectedObject);
            this.Controls.Add(this.battleInformation1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crlTacticalMap);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowTacticalLayerContainer";
            this.Text = "WindowTacticalLeyerContainer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowTacticalLayerContainer_FormClosing);
            this.Shown += new System.EventHandler(this.WindowTacticalLayerContainer_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Common.FlatButton flatButton1;
        private Controls.Common.FlatButton cmdRunGame;
        private System.Windows.Forms.Panel panel1;
        private Controls.TacticalMap crlTacticalMap;
        private Controls.TacticalLayer.BattleInformation battleInformation1;
        private Controls.TacticalLayer.SelectedBaseCelestialObject crlSelectedObject;
        private Controls.TacticalLayer.Compartments.WeaponCompartment weaponCompartment1;
        private Controls.TacticalLayer.Compartments.ScanningCompartment scanningCompartment;
        private Controls.TacticalLayer.Compartments.PropulsionCompartment propulsionCompartment1;
        private TacticalScreen tacticalScreen1;
    }
}