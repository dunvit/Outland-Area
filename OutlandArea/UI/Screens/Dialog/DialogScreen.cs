using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Engine;
using OutlandAreaLogic;

namespace OutlandArea.UI.Screens.Dialog
{
    public partial class DialogScreen : BaseResizeWindowForm
    {
        private Form WindowMenu { get; set; } = new ScreenMenu();

        private bool IsActivated { get; set; }

        public long DialogId { get; set; }

        public DialogScreen()
        {
            InitializeComponent();

            // Resize window by application settings
            // Default 1280x720
            // Setting loading in Program.cs
            Initialization();
        }

        private void Event_ActivateWindow(object sender, System.EventArgs e)
        {
            // Exit from activation flow if window already active.
            if (IsActivated) return;

            if (DialogId == 0)
            {
                // 637227264521603438 - Default dialog metadata from file "StartGame.json" in folder "Dialogs"
                DialogId = 637227264521603438;
            }

            // Set window status is active.
            IsActivated = true;

            ShowGameDialog(DialogId);
        }

        public void ShowGameDialog(long id)
        {
            var dialogMetaData = Global.GameManager.Dialogs.Get(id);

            if (string.IsNullOrEmpty(dialogMetaData.Background) == false)
            {
                BackgroundImage = new Bitmap(@"C:\Users\Vitaly\Pictures\Tests\" + dialogMetaData.Background + @".png");
            }

            var characterImage = Path.Combine(Environment.CurrentDirectory,
                @"Data\Characters\" + dialogMetaData.CharacterId + @"\Front.png");

            pictureActiveCharacter.Image = new Bitmap(characterImage);

            controlText.Text = dialogMetaData.Message;

            controlExit1.Visible = false;
            controlExit2.Visible = false;
            controlExit3.Visible = false;

            switch (dialogMetaData.Exits.Count)
            {
                case 1:
                    controlExit1.Text = dialogMetaData.Exits[0].Text;
                    controlExit1.Visible = true;
                    break;
                case 2:
                    controlExit1.Text = dialogMetaData.Exits[0].Text;
                    controlExit2.Text = dialogMetaData.Exits[1].Text;

                    controlExit1.Visible = true;
                    controlExit2.Visible = true;
                    break;
                case 3:
                    controlExit1.Text = dialogMetaData.Exits[0].Text;
                    controlExit2.Text = dialogMetaData.Exits[1].Text;
                    controlExit3.Text = dialogMetaData.Exits[2].Text;

                    controlExit1.Visible = true;
                    controlExit2.Visible = true;
                    controlExit3.Visible = true;
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                {
                    WindowMenu.ShowDialog();

                    return true;
                }
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
