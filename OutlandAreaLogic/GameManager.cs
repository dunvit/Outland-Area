using System.Windows.Forms;
using OutlandAreaLogic.DialogSystems;


namespace OutlandAreaLogic
{
    public class GameManager
    {
        //public Manager DialogsManager { get; set; }


        public IScreenCommands ScreenMain { get; set; }

        public Dialogs Dialogs = new Dialogs();

        public Items.Items Items = new Items.Items();

        public GameManager()
        {
            
        }

        private bool HealthCheck()
        {

            return true;
        }
    }
}
