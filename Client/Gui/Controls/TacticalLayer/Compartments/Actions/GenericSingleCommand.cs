using System;
using System.Drawing;
using System.Windows.Forms;
using Engine.Gui.Controls.Common;
using Engine.Gui.Controls.TacticalLayer.Modules;
using OutlandAreaCommon.Universe;

namespace Engine.Gui.Controls.TacticalLayer.Compartments.Actions
{
    public partial class GenericSingleCommand : GenericActiveModule
    {
        private MouseLocationTracker _mouseLocationTracker;

        public event Action<CommandTypes> OnExecute;

        public CommandTypes Type { get; set; }
        private CommandTypes CurrentType { get; set; }

        public Bitmap ImageActive { get; set; }
        public Bitmap ImageInActive { get; set; }
        public Bitmap ImageContinued { get; set; }

        public GenericSingleCommand()
        {
            InitializeComponent();

            Type = CommandTypes.MoveForward;

            imageCommand.Click += ExecuteCommand;
        }

        private void ExecuteCommand(object sender, EventArgs e)
        {
            OnExecute?.Invoke(Type);
        }

        private void GenericSingleCommand_Load(object sender, EventArgs e)
        {
            _mouseLocationTracker = new MouseLocationTracker(imageCommand);


            _mouseLocationTracker.OnMouseInControl += delegate
            {
                imageCommand.Image = ImageActive;
            };

            _mouseLocationTracker.OnMouseOutControl += delegate
            {
                imageCommand.Image = CurrentType == Type ? ImageContinued : ImageInActive;
            };
        }

        public void Update(CommandTypes commandType)
        {
            CurrentType = commandType;

            if (_mouseLocationTracker.IsActive) return;

            imageCommand.Invoke(new MethodInvoker(delegate () {
                imageCommand.Image = CurrentType == Type ? ImageContinued : ImageInActive;
            }));
        }
    }
}
