﻿using System;
using System.Windows.Forms;
using Engine.Tools;

namespace Engine.Gui
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow 
    {
        public WindowTacticalLayerContainer()
        {
            InitializeComponent();

            crlTacticalMap.Dock = DockStyle.Fill;

            if (DebugTools.IsInDesignMode())
                return;

            Global.Game.OnSelectCelestialObject += controlCommands.Event_SelectCelestialObject;

            controlCommands.OnAlignToCelestialObject += Global.Game.AddCommandAlignTo;
            crlTacticalMap.OnAlignToCelestialObject += Global.Game.AddCommandAlignTo;
            crlTacticalMap.OnLaunchMissile += Global.Game.AddCommandOpenFire;
            controlCommands.OnAlignToCelestialObject += crlTacticalMap.CommandAlignTo;
            controlCommands.OnOrbitCelestialObject += Global.Game.AddCommandOrbit;
            controlCommands.OnOpenFire += Global.Game.AddCommandOpenFire;

            crlWeaponLauncher.OnActivateModule += crlTacticalMap.ActivateModule;
        }

        private void Event_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_ResumeGame(object sender, EventArgs e)
        {
            Global.Game.ResumeSession();
        }

        private void WindowTacticalLayerContainer_FormClosing(object sender, FormClosingEventArgs e)
        {
            crlTacticalMap.CloseTacticalMap();
        }
    }
}
