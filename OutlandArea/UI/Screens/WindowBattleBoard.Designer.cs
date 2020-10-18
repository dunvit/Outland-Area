namespace OutlandArea.UI.Screens
{
    partial class WindowBattleBoard
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
            this.components = new System.ComponentModel.Container();
            this.crlRefreshMapTrigger = new System.Windows.Forms.Timer(this.components);
            this.commandApplicationExit = new OutlandAreaLogic.Controls.OaButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.crlRefreshMousePosition = new System.Windows.Forms.Timer(this.components);
            this.txtUpdateLastTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTurn = new System.Windows.Forms.Label();
            this.btnPause = new OutlandAreaLogic.Controls.OaButton();
            this.crlMapSettingsCoordinadesVisibility = new System.Windows.Forms.CheckBox();
            this.btnResume = new OutlandAreaLogic.Controls.OaButton();
            this.txtMapInfoStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMapInfoTurn = new System.Windows.Forms.Label();
            this.txtMapInfoObjectsCount = new System.Windows.Forms.Label();
            this.txtMapInfoID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.oaButton1 = new OutlandAreaLogic.Controls.OaButton();
            this.commandIncreaseSpeed = new OutlandAreaLogic.Controls.OaButton();
            this.crlTargetInfo = new OutlandArea.UI.Screens.ShipInfo.ShipInformation();
            this.targetingCommands1 = new OutlandArea.UI.Screens.TargetingCommands();
            this.controlNavigationCommands = new OutlandArea.UI.Screens.BattleBoardControls.NavigationCommands();
            this.crlPanelCelestialObjectInfo = new OutlandArea.UI.Screens.Controls.PanelObjectView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crlRefreshMapTrigger
            // 
            this.crlRefreshMapTrigger.Interval = 500;
            this.crlRefreshMapTrigger.Tick += new System.EventHandler(this.crlRefreshMapTrigger_Tick);
            // 
            // commandApplicationExit
            // 
            this.commandApplicationExit.BackColor = System.Drawing.Color.Maroon;
            this.commandApplicationExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandApplicationExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandApplicationExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandApplicationExit.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandApplicationExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.commandApplicationExit.Location = new System.Drawing.Point(1862, 1045);
            this.commandApplicationExit.Name = "commandApplicationExit";
            this.commandApplicationExit.Size = new System.Drawing.Size(46, 23);
            this.commandApplicationExit.TabIndex = 3;
            this.commandApplicationExit.Text = "Exit";
            this.commandApplicationExit.UseVisualStyleBackColor = false;
            this.commandApplicationExit.Click += new System.EventHandler(this.commandApplicationExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Event_MapMouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Event_MapMouseMove);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.DimGray;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Location = new System.Drawing.Point(12, 15);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(220, 145);
            this.txtLog.TabIndex = 5;
            this.txtLog.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DimGray;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(12, 166);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 145);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // crlRefreshMousePosition
            // 
            this.crlRefreshMousePosition.Enabled = true;
            this.crlRefreshMousePosition.Tick += new System.EventHandler(this.crlRefreshMousePosition_Tick);
            // 
            // txtUpdateLastTime
            // 
            this.txtUpdateLastTime.ForeColor = System.Drawing.Color.White;
            this.txtUpdateLastTime.Location = new System.Drawing.Point(33, 109);
            this.txtUpdateLastTime.Name = "txtUpdateLastTime";
            this.txtUpdateLastTime.Size = new System.Drawing.Size(186, 14);
            this.txtUpdateLastTime.TabIndex = 8;
            this.txtUpdateLastTime.Text = "Updated: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTurn);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.crlMapSettingsCoordinadesVisibility);
            this.panel1.Controls.Add(this.btnResume);
            this.panel1.Controls.Add(this.txtUpdateLastTime);
            this.panel1.Controls.Add(this.txtMapInfoStatus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMapInfoTurn);
            this.panel1.Controls.Add(this.txtMapInfoObjectsCount);
            this.panel1.Controls.Add(this.txtMapInfoID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNameLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 250);
            this.panel1.TabIndex = 9;
            this.panel1.Visible = false;
            // 
            // txtTurn
            // 
            this.txtTurn.ForeColor = System.Drawing.Color.White;
            this.txtTurn.Location = new System.Drawing.Point(33, 127);
            this.txtTurn.Name = "txtTurn";
            this.txtTurn.Size = new System.Drawing.Size(134, 14);
            this.txtTurn.TabIndex = 14;
            this.txtTurn.Text = "Turn: ";
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.IndianRed;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.Black;
            this.btnPause.Location = new System.Drawing.Point(112, 209);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(86, 23);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.oaButton1_Click);
            // 
            // crlMapSettingsCoordinadesVisibility
            // 
            this.crlMapSettingsCoordinadesVisibility.AutoSize = true;
            this.crlMapSettingsCoordinadesVisibility.Checked = true;
            this.crlMapSettingsCoordinadesVisibility.CheckState = System.Windows.Forms.CheckState.Checked;
            this.crlMapSettingsCoordinadesVisibility.ForeColor = System.Drawing.Color.White;
            this.crlMapSettingsCoordinadesVisibility.Location = new System.Drawing.Point(15, 157);
            this.crlMapSettingsCoordinadesVisibility.Name = "crlMapSettingsCoordinadesVisibility";
            this.crlMapSettingsCoordinadesVisibility.Size = new System.Drawing.Size(111, 17);
            this.crlMapSettingsCoordinadesVisibility.TabIndex = 12;
            this.crlMapSettingsCoordinadesVisibility.Text = "Show coordinates";
            this.crlMapSettingsCoordinadesVisibility.UseVisualStyleBackColor = true;
            this.crlMapSettingsCoordinadesVisibility.CheckStateChanged += new System.EventHandler(this.Event_MapSettingsChange_SetCoordinatesVisibility);
            // 
            // btnResume
            // 
            this.btnResume.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnResume.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnResume.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResume.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.ForeColor = System.Drawing.Color.Black;
            this.btnResume.Location = new System.Drawing.Point(20, 209);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(86, 23);
            this.btnResume.TabIndex = 11;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = false;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // txtMapInfoStatus
            // 
            this.txtMapInfoStatus.BackColor = System.Drawing.Color.Transparent;
            this.txtMapInfoStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMapInfoStatus.Location = new System.Drawing.Point(101, 89);
            this.txtMapInfoStatus.Name = "txtMapInfoStatus";
            this.txtMapInfoStatus.Size = new System.Drawing.Size(73, 17);
            this.txtMapInfoStatus.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Status:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMapInfoTurn
            // 
            this.txtMapInfoTurn.BackColor = System.Drawing.Color.Transparent;
            this.txtMapInfoTurn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMapInfoTurn.Location = new System.Drawing.Point(101, 72);
            this.txtMapInfoTurn.Name = "txtMapInfoTurn";
            this.txtMapInfoTurn.Size = new System.Drawing.Size(73, 17);
            this.txtMapInfoTurn.TabIndex = 8;
            // 
            // txtMapInfoObjectsCount
            // 
            this.txtMapInfoObjectsCount.BackColor = System.Drawing.Color.Transparent;
            this.txtMapInfoObjectsCount.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMapInfoObjectsCount.Location = new System.Drawing.Point(101, 55);
            this.txtMapInfoObjectsCount.Name = "txtMapInfoObjectsCount";
            this.txtMapInfoObjectsCount.Size = new System.Drawing.Size(73, 17);
            this.txtMapInfoObjectsCount.TabIndex = 7;
            // 
            // txtMapInfoID
            // 
            this.txtMapInfoID.BackColor = System.Drawing.Color.Transparent;
            this.txtMapInfoID.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMapInfoID.Location = new System.Drawing.Point(101, 38);
            this.txtMapInfoID.Name = "txtMapInfoID";
            this.txtMapInfoID.Size = new System.Drawing.Size(73, 17);
            this.txtMapInfoID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Turn:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Object count:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNameLabel
            // 
            this.txtNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.txtNameLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtNameLabel.Location = new System.Drawing.Point(12, 38);
            this.txtNameLabel.Name = "txtNameLabel";
            this.txtNameLabel.Size = new System.Drawing.Size(73, 17);
            this.txtNameLabel.TabIndex = 3;
            this.txtNameLabel.Text = "ID:";
            this.txtNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map Information";
            // 
            // oaButton1
            // 
            this.oaButton1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.oaButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.oaButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.oaButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oaButton1.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oaButton1.ForeColor = System.Drawing.Color.Black;
            this.oaButton1.Location = new System.Drawing.Point(134, 276);
            this.oaButton1.Name = "oaButton1";
            this.oaButton1.Size = new System.Drawing.Size(86, 23);
            this.oaButton1.TabIndex = 15;
            this.oaButton1.Text = "Refresh";
            this.oaButton1.UseVisualStyleBackColor = false;
            this.oaButton1.Visible = false;
            this.oaButton1.Click += new System.EventHandler(this.oaButton1_Click_1);
            // 
            // commandIncreaseSpeed
            // 
            this.commandIncreaseSpeed.BackColor = System.Drawing.Color.DarkSlateGray;
            this.commandIncreaseSpeed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.commandIncreaseSpeed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.commandIncreaseSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandIncreaseSpeed.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandIncreaseSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.commandIncreaseSpeed.Location = new System.Drawing.Point(251, 15);
            this.commandIncreaseSpeed.Name = "commandIncreaseSpeed";
            this.commandIncreaseSpeed.Size = new System.Drawing.Size(86, 23);
            this.commandIncreaseSpeed.TabIndex = 16;
            this.commandIncreaseSpeed.Text = "Forward";
            this.commandIncreaseSpeed.UseVisualStyleBackColor = false;
            this.commandIncreaseSpeed.Visible = false;
            this.commandIncreaseSpeed.Click += new System.EventHandler(this.commandIncreaseSpeed_Click);
            // 
            // crlTargetInfo
            // 
            this.crlTargetInfo.BackColor = System.Drawing.Color.Black;
            this.crlTargetInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crlTargetInfo.Location = new System.Drawing.Point(358, 15);
            this.crlTargetInfo.Name = "crlTargetInfo";
            this.crlTargetInfo.Size = new System.Drawing.Size(266, 128);
            this.crlTargetInfo.TabIndex = 17;
            this.crlTargetInfo.Visible = false;
            // 
            // targetingCommands1
            // 
            this.targetingCommands1.BackColor = System.Drawing.Color.Black;
            this.targetingCommands1.Location = new System.Drawing.Point(1408, 429);
            this.targetingCommands1.Name = "targetingCommands1";
            this.targetingCommands1.Size = new System.Drawing.Size(500, 400);
            this.targetingCommands1.SpacecraftId = ((long)(0));
            this.targetingCommands1.TabIndex = 11;
            this.targetingCommands1.Visible = false;
            // 
            // controlNavigationCommands
            // 
            this.controlNavigationCommands.BackColor = System.Drawing.Color.Black;
            this.controlNavigationCommands.Location = new System.Drawing.Point(1408, 12);
            this.controlNavigationCommands.Manager = null;
            this.controlNavigationCommands.Name = "controlNavigationCommands";
            this.controlNavigationCommands.Size = new System.Drawing.Size(500, 400);
            this.controlNavigationCommands.SpacecraftId = ((long)(0));
            this.controlNavigationCommands.TabIndex = 10;
            this.controlNavigationCommands.Visible = false;
            // 
            // crlPanelCelestialObjectInfo
            // 
            this.crlPanelCelestialObjectInfo.BackColor = System.Drawing.Color.Black;
            this.crlPanelCelestialObjectInfo.Location = new System.Drawing.Point(12, 326);
            this.crlPanelCelestialObjectInfo.Name = "crlPanelCelestialObjectInfo";
            this.crlPanelCelestialObjectInfo.Size = new System.Drawing.Size(224, 169);
            this.crlPanelCelestialObjectInfo.TabIndex = 7;
            this.crlPanelCelestialObjectInfo.Visible = false;
            // 
            // WindowBattleBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.crlTargetInfo);
            this.Controls.Add(this.commandIncreaseSpeed);
            this.Controls.Add(this.oaButton1);
            this.Controls.Add(this.targetingCommands1);
            this.Controls.Add(this.controlNavigationCommands);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.crlPanelCelestialObjectInfo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.commandApplicationExit);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowBattleBoard";
            this.Text = "WindowBattleBoard";
            this.Load += new System.EventHandler(this.WindowBattleBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer crlRefreshMapTrigger;
        private OutlandAreaLogic.Controls.OaButton commandApplicationExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer crlRefreshMousePosition;
        private Controls.PanelObjectView crlPanelCelestialObjectInfo;
        private System.Windows.Forms.Label txtUpdateLastTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtMapInfoTurn;
        private System.Windows.Forms.Label txtMapInfoObjectsCount;
        private System.Windows.Forms.Label txtMapInfoID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtNameLabel;
        private System.Windows.Forms.Label txtMapInfoStatus;
        private System.Windows.Forms.Label label4;
        private OutlandAreaLogic.Controls.OaButton btnResume;
        private System.Windows.Forms.CheckBox crlMapSettingsCoordinadesVisibility;
        private BattleBoardControls.NavigationCommands controlNavigationCommands;
        private TargetingCommands targetingCommands1;
        private OutlandAreaLogic.Controls.OaButton btnPause;
        private System.Windows.Forms.Label txtTurn;
        private OutlandAreaLogic.Controls.OaButton oaButton1;
        private OutlandAreaLogic.Controls.OaButton commandIncreaseSpeed;
        private ShipInfo.ShipInformation crlTargetInfo;
    }
}