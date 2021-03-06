﻿using System;
using System.Globalization;
using EngineCore.Events;
using EngineCore.Session;
using System.Windows.Forms;
using EngineCore.Geometry;
using EngineCore.Universe.Objects;

namespace Engine.UI.Screens
{
    public partial class WindowGenericEvent : Form
    {
        private const string helloOfficerMessage = "1- Служба дальнего обнаружения. Лейтенант {PILOT}, протокол 201. Разрешите доложить, капитан?";
        private const string helloCaptainMessage = "1- Капитан {CAPTAIN}. Я вас слушаю. Докладывайте {PILOT}.";
        private const string foundNewSpaceshipDetailsMessage = "1- Идентификационный номер: {ID},/n" +
                                                        "1- Дистанция: {DISTANCE}/n" +
                                                        "1- Скорость: {SPEED}/n" +
                                                        "1- Сигнатура: {SIGNATURE}/n" +
                                                        "1- Направление: {DIRECTION}/n" +
                                                        "1- Отношение: {RELATIONSHIP}/n";

        private const string foundNewSpaceshipMessage = "1- Капитан. Системами дальнего обнаружения выявлен неизвестный объект искусственного происхождения.";

        public GameEvent GameEvent { get; set; }

        public GameSession Session { get; set; }

        public GameEventDecisionResult DecisionResult { get; private set; }

        public WindowGenericEvent(GameEvent gameEvent, GameSession session)
        {
            InitializeComponent();

            GameEvent = gameEvent;
            Session = session;

            var longRangeDefenseOfficer = session.GetCharacter(637066561468099897);

            rowFirstPilotImage.RefreshPersonInfo(longRangeDefenseOfficer);
            rowThriedPilotImage.RefreshPersonInfo(longRangeDefenseOfficer);

            var captain = session.GetCharacter(637066561468099898 );

            rowFirstPilotMessage.Text = helloOfficerMessage.Replace("{PILOT}", longRangeDefenseOfficer.Name);
            rowSecondCaptainMessage.Text = helloCaptainMessage.
                Replace("{PILOT}", longRangeDefenseOfficer.Name).
                Replace("{CAPTAIN}", captain.Name);

            rowSecondCaptainImage.RefreshPersonInfo(captain);

            cmdAnswearFirst.Text = rowSecondCaptainMessage.Text;

            var message = foundNewSpaceshipMessage;

            var spaceship = session.GetPlayerSpaceShip();

            foreach (var gameEventGenericObject in gameEvent.GenericObjects)
            {
                var celestialObject = session.GetCelestialObject(Convert.ToInt64(gameEventGenericObject.Value));

                message += Environment.NewLine + Environment.NewLine + foundNewSpaceshipDetailsMessage.
                    Replace("{ID}", celestialObject.Id.ToString()).
                    Replace("{DISTANCE}", Math.Round(
                        GeometryTools.Distance(spaceship.GetLocation(), celestialObject.GetLocation())
                        ,2).ToString(CultureInfo.InvariantCulture)).
                    Replace("{SPEED}", Math.Round(celestialObject.Speed, 2).ToString(CultureInfo.InvariantCulture)).
                    Replace("{SIGNATURE}", celestialObject.Signature.ToString()).
                    Replace("{DIRECTION}", Math.Round(celestialObject.Direction, 2).ToString(CultureInfo.InvariantCulture)).
                    Replace("{RELATIONSHIP}", "Unknown").
                    Replace(@"/n", Environment.NewLine);
            }

            rowThriedPilotMessage.Text = message;
        }

        private void cmdAnswearSecond_Click(object sender, EventArgs e)
        {
            DecisionResult = GameEventDecisionResult.TargetEvasionManeuver;
            Close();
        }

        private void cmdAnswearFirst_Click(object sender, EventArgs e)
        {
            if (cmdAnswearSecond.Visible)
            {
                DecisionResult = GameEventDecisionResult.ManeuverToApproachTarget;
                Close();
            }

            rowSecondCaptainImage.Visible = true;
            rowSecondCaptainMessage.Visible = true;

            rowThriedPilotImage.Visible = true;
            rowThriedPilotMessage.Visible = true;


            cmdAnswearFirst.Text = "Маневр сближения.";
            cmdAnswearSecond.Text = "Маневр уклонения.";
            cmdAnswearSecond.Visible = true;
        }
    }
}
