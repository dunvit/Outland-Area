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

            switch (gameEvent.GetParameter(GameEventParameterTypes.Result))
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
            txtResult.Text = gameEvent.GetParameter(GameEventParameterTypes.Result);

            txtDamage.Text = gameEvent.GetParameter(GameEventParameterTypes.Damage);

            txtDice.Text = gameEvent.GetParameter(GameEventParameterTypes.Dice);
            txtChance.Text = gameEvent.GetParameter(GameEventParameterTypes.Chance);

            var targetId = long.Parse(gameEvent.GetParameter(GameEventParameterTypes.TargetId));
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
