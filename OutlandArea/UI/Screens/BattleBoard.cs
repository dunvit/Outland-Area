using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using OutlandArea.TacticalBattleLayer;
using OutlandArea.UI.Screens.BattleBoardControls;

namespace OutlandArea.UI.Screens
{
    public partial class BattleBoard : Form, IBattleManager
    {
        public Manager Manager { get; set; }
        

        private ICelestialObject currentCelestialObject;

        ILog log = LogManager.GetLogger(typeof(BattleBoard));

        private TargetingCommands targetingCommands1;

        public BattleBoard(Manager manager)
        {
            InitializeComponent();

            targetingCommands1 = new TargetingCommands
            {
                BackColor = Color.Black,
                Location = new Point(712, 350),
                Name = "targetingCommands1",
                Size = new Size(500, 400),
                SpacecraftId = ((long) (0)),
                TabIndex = 8,
                Visible = false
            };

            panel2.Controls.Add(targetingCommands1);

            Manager = manager;

            controlNavigationCommands.SpacecraftId = Manager.GetSpacecraftId();
            targetingCommands1.SpacecraftId = Manager.GetSpacecraftId();

            controlTacticalMap.Size = new Size(1918, 1078);
            controlTacticalMap.OnMouseMoveCelestialObject += EventMouseMoveCelestialObject;
            controlTacticalMap.OnMouseLeaveCelestialObject += EventMouseLeaveCelestialObject;

            controlNavigationCommands.OnSelectCommand += Event_ShowCommand;
            targetingCommands1.OnSelectCommand += Event_SelectCommand;

            turnInformation1.Activate(Manager);
            targetingCommands1.Activate(Manager);
            controlTacticalMap.Activate(Manager);

            Manager.OnStartNewTurn += Event_StartNewTurn;
            

            Manager.SetLogger(LogWrite);
        }

        private void Event_SelectCommand(ICommand command)
        {
            controlTacticalMap.StartLockTarget(command);
        }

        public void Activate(Manager manager)
        {

        }

        private void Event_ShowCommand(ICommand command)
        {
            var windowShowCommand = new WindowShowCommand {Command = command, Location = new Point(Cursor.Position.X - 100, Cursor.Position.Y - 100)};

            LogWrite("[BattleBoard] Open window AddCommand for " + command.Description);

            windowShowCommand.OnAddCommand += Event_AddCommandToTurn;

            windowShowCommand.ShowDialog(this);
        }

        private void Event_AddCommandToTurn(ICommand command)
        {
            LogWrite("[BattleBoard] Add command for " + command.Description);

            Manager.AddCommand(command);
        }

        private void EventMouseMoveCelestialObject(ICelestialObject celestialObject)
        {
            currentCelestialObject = celestialObject;
            LogWrite("[BattleBoard] MouseMove_CelestialObject - " + celestialObject.Name);
        }

        private void EventMouseLeaveCelestialObject(ICelestialObject celestialObject)
        {
            if (currentCelestialObject != null)
            {
                LogWrite("[BattleBoard] MouseLeave_CelestialObject - " + currentCelestialObject.Name);
            }

            currentCelestialObject = null;
        }

        private void Event_StartNewTurn(Turn turn)
        {
            turnInformation1.Refresh(turn);
            controlTacticalMap.Refresh(turn);
        }

        private void Event_CloseApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Event_BoardLoad(object sender, EventArgs e)
        {
            Manager.FinishInitialization();

            ControlExtension.Draggable(turnInformation1, true);

            this.AllowDrop = true;

            // Add event handlers for the drag & drop functionality
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);
        }
        // This event occurs when the user drags over the form with 
        // the mouse during a drag drop operation 
        void Form_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the Dataformat of the data can be accepted
            // (we only accept file drops from Explorer, etc.)
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; // Okay
            else
                e.Effect = DragDropEffects.None; // Unknown data, ignore it

        }

        // Occurs when the user releases the mouse over the drop target 
        void Form_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Do something with the data...

            // For example add all files into a simple label control:
            //foreach (string File in FileList)
                //this.label.Text += File + "\n";
        }

        private delegate void SetTextCallback(string text);

        private void LogWrite(string message)
        {
            if (txtLog.InvokeRequired)
            {
                var d = new SetTextCallback(LogWrite);
                Invoke(d, message);
            }
            else
            {
                txtLog.Text = DateTime.Now.ToString("HH:mm:ss") + @" - " + message + Environment.NewLine + txtLog.Text;

                if (txtLog.Lines.Length > 35)
                {
                    var newLines = new string[35];

                    Array.Copy(txtLog.Lines, 0, newLines, 0, 35);

                    txtLog.Lines = newLines;
                }

                txtLog.Refresh();

                log.Debug(message);
            }

        }

        private void Event_ShowNavigationCommandsControl(object sender, EventArgs e)
        {
            targetingCommands1.Visible = false;
            controlNavigationCommands.Visible = !controlNavigationCommands.Visible;
        }

        private void oaButton5_Click(object sender, EventArgs e)
        {
            targetingCommands1.Location = controlNavigationCommands.Location;

            targetingCommands1.Visible = true;
            controlNavigationCommands.Visible = false;
        }
    }
}
