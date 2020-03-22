using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using log4net;
using OutlandAreaLogic.CharacterSystem;
using OutlandAreaLogic.DialogSystems;

namespace WorkSpace.Prototypes
{
    public partial class SimpleDialogCharacter : UserControl
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SimpleDialogCharacter));

        public SimpleDialogCharacter()
        {
            InitializeComponent();
        }

        public bool TryInitializeCharacter(Character character, Alignment align)
        {
            Log.Info($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] " +
                     $" Character: {character.Name} Align: {align.ToString()}");

            try
            {
                txtName.Text = character.Name;

                // TODO: Add celestial object to dialog
                txtCelestialObjectName.Text = "AAAAA";//character.CelestialName;
                txtRank.Text = character.Rank;
                txtRelations.Text = character.Relation;

                switch (align)
                {
                    case Alignment.Right:
                        imageAvatar.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Data\Characters\" + character.Id + @"\Left.png"));
                        break;

                    case Alignment.Left:
                        imageAvatar.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Data\Characters\" + character.Id + @"\Right.png"));
                        break;

                    case Alignment.Front:
                        imageAvatar.Image = new Bitmap(Path.Combine(Environment.CurrentDirectory, @"Data\Characters\" + character.Id + @"\Front.png"));
                        break;
                }
            }
            catch (Exception e)
            {
                Log.Error($"[{System.Reflection.MethodBase.GetCurrentMethod().Name}] Critical error. Exception is {e.Message}");

                throw;
            }

            InitializeComponent();

            return true;
        }
    }
}
