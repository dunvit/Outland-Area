using System;
using System.Windows.Forms;
using log4net;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer.Compartments
{
    public partial class BaseCompartment : UserControl
    {
        protected static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event Action<ICelestialObject> OnActivateModule;

        public string CompartmentModuleName 
        { 
            get => txtName.Text; 

            set
            {
                txtName.Text = value.ToUpper();
                Refresh();
            }
        }

        public BaseCompartment()
        {
            InitializeComponent();

            moduleFirst.OnActivateModule += ActivateFirstModule;
        }

        private void ActivateFirstModule(ICelestialObject celestialObject)
        {
            OnActivateModule?.Invoke(celestialObject);
        }

        public void Initialization(IModule module)
        {
            moduleFirst.Initialization(module);
        }

        public void ResetData(GameSession gameSession, IWeaponModule module)
        {
            moduleFirst.ResetData(gameSession, module);
        }

        private void Event_MouseLeave(object sender, EventArgs e)
        {
            moduleFirst.Unselect();
        }
    }
}
