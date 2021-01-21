using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Engine.Gui.Controls.TacticalLayer.Modules
{
    public partial class GenericActiveModule : UserControl
    {
        protected static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IModule _module;
        public event Action<IModule> OnExecuteModule;
        public event Action<IModule> OnActivateModule;
        public event Action<IModule> OnDeactivateModule;

        public GenericActiveModule()
        {
            InitializeComponent();

            moduleFirstReloadBar.BarLineColor = Color.DarkOliveGreen;
        }

        public void Initialization(IModule module)
        {
            _module = module;

            actionIcon.Picture = Properties.Resources.Radar;
            actionIcon.OnMouseEnter += delegate
            {
                OnActivateModule?.Invoke(module);
            };
            actionIcon.OnMouseLeave += delegate
            {
                OnDeactivateModule?.Invoke(module);
            };
        }

        private delegate void ProgressBarCallback(GameSession gameSession, IWeaponModule module);

        public void ResetData(GameSession gameSession, IWeaponModule module)
        {
            _module = (IModule)module.DeepClone();

            if (moduleFirstReloadBar.InvokeRequired)
            {
                ProgressBarCallback d = ResetData;
                Invoke(d, gameSession, module);
            }
            else
            {
                moduleFirstReloadBar.Maximum = (int)(module.ReloadTime * 10);

                moduleFirstReloadBar.Value = (int)(module.Reloading * 10);

                var barTextValue = ((double)moduleFirstReloadBar.Value / (double)moduleFirstReloadBar.Maximum) * 100;

                //moduleFirstReloadBar.BarText = (int)barTextValue + "%";

                moduleFirstReloadBar.Refresh();

                Logger.Debug($"Turn {gameSession.Turn} ReloadTime {module.ReloadTime} Reloading {module.Reloading}");
            }


        }

        private void ExecuteModule(object sender, EventArgs e)
        {
            if (_module.ToWeapon().Reloading < _module.ToWeapon().ReloadTime)
            {
                // TODO: Add log information
                return;
            }

            OnExecuteModule?.Invoke(_module);
        }

        public void Unselect()
        {
            actionIcon.Unselect();
        }
    }
}
