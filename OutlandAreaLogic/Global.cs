using OutlandAreaLogic.Configuration;
using OutlandAreaLogic.DialogSystems;

namespace OutlandAreaLogic
{
    public class Global
    {
        public static Settings ApplicationSettings = new Settings();

        public static Dialogs Dialogs = new Dialogs();

        public static void Initialization()
        {
            // Log system initialization
            log4net.Config.XmlConfigurator.Configure();

            Dialogs.Initialization();
        }
    }
}
