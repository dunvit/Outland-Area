using System;
using System.Drawing;
using System.Windows.Forms;
using EngineCore.Events;
using EngineCore.Session;
using EngineCore.Universe.Objects;

namespace Engine.UI.Screens
{
    public partial class WindowExplosionResult : Form, IGameEventScreen
    {
        public WindowExplosionResult(GameEvent gameEvent, GameSession session)
        {
            InitializeComponent();

            var color = Color.DarkOliveGreen;

            switch (gameEvent.GenericObjects[7])
            {
                case "MISS":
                    color = Color.Crimson;
                    break;
                case "HIT":
                    color = Color.DarkOliveGreen;
                    break;
                case "DESTROYED":
                    color = Color.DarkRed;
                    break;

            }

            txtResult.ForeColor = color;
            txtResult.Text = gameEvent.GenericObjects[7];

            txtDamage.Text = gameEvent.GenericObjects[5];

            txtDice.Text = gameEvent.GenericObjects[4];
            txtChance.Text = gameEvent.GenericObjects[6];

            var targetId = long.Parse(gameEvent.GenericObjects[1]);
            var targetSpaceship = session.GetCelestialObject(targetId).ToSpaceship();

            txtShields.Text = targetSpaceship.Shields + @"/" + targetSpaceship.ShieldsMax;
        }

        private void Event_CloseWindow(object sender, EventArgs e)
        {
            Close();
        }

        public GameEvent Event { get; set; }
    }
}
