using log4net;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Tactical;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Engine.Gui.Controls.TacticalLayer.Compartments
{
    public partial class BaseCompartment : UserControl
    {
        protected static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event Action<IModule> OnActivateModule;
        public event Action<IModule> OnPreActivateModule;

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

            moduleFirst.OnActivateModule += ActivateModule;
            moduleSecond.OnActivateModule += ActivateModule;
            moduleThird.OnActivateModule += ActivateModule;
        }

        private void ActivateModule(IModule module)
        {
            Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' activated from slot {module.Slot} for compartment {module.Compartment}"));

            OnActivateModule?.Invoke(module);
        }

        public void Initialization(List<IModule> modules)
        {
            Logger.Debug(TraceMessage.Execute(this, "Modules initialization started."));

            foreach (var module in modules)
            {
                switch (module.Slot)
                {
                    case 1:
                        Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' docked to slot {module.Slot} for compartment {module.Compartment}"));
                        moduleFirst.Initialization(module);
                        moduleFirst.Tag = module;
                        moduleFirst.Visible = true;
                        break;

                    case 2:
                        Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' docked to slot {module.Slot} for compartment {module.Compartment}"));
                        moduleSecond.Initialization(module);
                        moduleSecond.Tag = module;
                        moduleSecond.Visible = true;
                        break;

                    case 3:
                        Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' docked to slot {module.Slot} for compartment {module.Compartment}"));
                        moduleThird.Initialization(module);
                        moduleThird.Tag = module;
                        moduleThird.Visible = true;
                        break;
                }
            }
        }

        public void ResetData(GameSession gameSession, List<IModule> modules)
        {
            Logger.Debug(TraceMessage.Execute(this, "Modules update started."));

            foreach (var module in modules)
            {
                switch (module.Slot)
                {
                    case 1:
                        Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' updated in slot {module.Slot} for compartment {module.Compartment}"));
                        if(module is IWeaponModule slot1Module)
                            moduleFirst.ResetData(gameSession, slot1Module);
                        break;

                    case 2:
                        Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' updated in slot {module.Slot} for compartment {module.Compartment}"));
                        if (module is IWeaponModule slot2Module)
                            moduleSecond.ResetData(gameSession, slot2Module);
                        break;

                    case 3:
                        Logger.Debug(TraceMessage.Execute(this, $"Module '{module.Name}' updated in slot {module.Slot} for compartment {module.Compartment}"));
                        if (module is IWeaponModule slot3Module)
                            moduleThird.ResetData(gameSession, slot3Module);
                        break;
                }
            }
        }

        private void Event_MouseLeave(object sender, EventArgs e)
        {
            moduleFirst.Unselect();
        }
    }
}
