using System;
using System.Drawing;
using System.Windows.Forms;
using Engine.Tools;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Ammunition.Missiles;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer
{
    public partial class CommandsWeaponCompartment : UserControl
    {
        public event Action<ICelestialObject> OnActivateModule;
        private IModule _module;
        private Point _location;

        public CommandsWeaponCompartment()
        {
            InitializeComponent();
        }

        private void CommandsWeaponCompartment_Load(object sender, EventArgs e)
        {
            if (DebugTools.IsInDesignMode())
                return;

            _location = Location;

            panel1_Click(null, null);

            picWeaponImage.Image = UI.LoadGenericImage("Ship_Equipment/Missile_Launchers/Light_Missile_Launcher_I");
            txtWeaponName.Text = @"LIGHT MISSILE LAUNCHER I";

            picCrewMember.Image = UI.LoadCharacterImage("637066561468099897");
        }

        private void panel1_Click(object sender, System.EventArgs e)
        {
            if (Height == 207)
            {
                Height = 56;
                Location = new Point(_location.X, 1010);
            }
            else
            {
                Height = 207;
                Location = new Point(_location.X, 861);
            }
        }

        private void Event_ActivateModule(object sender, EventArgs e)
        {
            //if(_module.Reloading < _module.ReloadTime)
            //{
            //    // TODO: Add log information
            //    return;
            //}

            var missile = MissilesFactory.GetMissile(_module.ToWeapon().AmmoId).ToCelestialObject();

            missile.OwnerId = (int)_module.Id;

            OnActivateModule?.Invoke(missile);
        }

        public void Initialization(IModule module)
        {
            _module = module;
        }
    }
}
