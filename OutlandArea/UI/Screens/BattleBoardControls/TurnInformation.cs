using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using OutlandArea.TacticalBattleLayer;

namespace OutlandArea.UI.Screens.BattleBoardControls
{
    public partial class TurnInformation : UserControl, IBattleManager
    {
        public Manager Manager { get; set; }
        private Turn CurrentTurn { get; set; }

        public TurnInformation()
        {
            InitializeComponent();
        }

        public void Activate(Manager manager)
        {
            Manager = manager;

            Manager.OnStartNewTurn += Event_StartNewTurn;
            Manager.OnChangeCommandsQueue += Event_ChangeCommandsQueue;
        }

        private void Event_StartNewTurn(Turn obj)
        {
            var commands = Manager.GetCurrentTurnCommands();

            DrawScreen(commands);
        }

        private void Event_ChangeCommandsQueue()
        {
            var commands = Manager.GetCurrentTurnCommands();

            DrawScreen(commands);
        }

        private void DrawScreen(List<ICommand> commands)
        {
            Image image = new Bitmap(Width, Height);

            var graphics = Graphics.FromImage(image);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.Bicubic;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;


            var row = 1;

            foreach (var command in commands)
            {
                var baseYPosition = 55 * row;

                var bmpPilotPortrait = Tools.UI.LoadGenericImage(@"Data\Characters\" + command.PilotID + @"\Front");

                graphics.DrawImage(bmpPilotPortrait, 9, baseYPosition + 4, 50 , 50);
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.DimGray)),new Rectangle(9, baseYPosition + 4, 50, 50) );

                

                using (var font = new Font("Mongolian Baiti", 14, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    graphics.DrawString("Lt. Elmer D. McKnight", font, new SolidBrush(Color.FromArgb(129, 168, 204)), new PointF(65, baseYPosition + 4));
                }

                var bmpCommandImage = Tools.UI.LoadGenericImage(@"Images\Commands\" + command.Image);

                graphics.DrawImage(bmpCommandImage, 68, baseYPosition + 23, 30, 30);
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.DimGray)), new Rectangle(68, baseYPosition + 23, 30, 30));


                using (var font = new Font("Mongolian Baiti", 13, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    graphics.DrawString(command.Description, font, new SolidBrush(Color.FromArgb(46, 67, 100)), new PointF(104, baseYPosition + 23));
                }

                using (var font = new Font("Mongolian Baiti", 13, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    graphics.DrawString("Success:", font, new SolidBrush(Color.Goldenrod), new PointF(104, baseYPosition + 39));
                }

                using (var font = new Font("Mongolian Baiti", 13, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    graphics.DrawString("Time:", font, new SolidBrush(Color.Goldenrod), new PointF(225, baseYPosition + 39));
                }
                using (var font = new Font("Mongolian Baiti", 13, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    graphics.DrawString(command.SuccessChance.ToString("D3"), font, new SolidBrush(Color.DarkOliveGreen), new PointF(172, baseYPosition + 39));
                }
                using (var font = new Font("Mongolian Baiti", 13, FontStyle.Bold, GraphicsUnit.Pixel))
                {
                    graphics.DrawString(command.TimePointCost.ToString("D3"), font, new SolidBrush(Color.DarkOliveGreen), new PointF(272, baseYPosition + 39));
                }

                row++;
            }

            panel1.BackgroundImage = image;


        }

        public void Refresh(Turn turn)
        {
            if (turn == null) return;

            CurrentTurn = turn;

            labelTurnNumber.Text = CurrentTurn.Number.ToString();
        }

        private void Event_ApplicationExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Event_EndTurn(object sender, EventArgs e)
        {
            Manager.EndTurn();
        }

        
    }
}
