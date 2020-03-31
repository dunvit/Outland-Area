using OutlandAreaLogic.CharacterSystem;
using OutlandAreaLogic.Configuration;

namespace OutlandAreaLogic
{
    public class Global
    {
        public static Settings ApplicationSettings = new Settings();

        public static Characters Characters = new Characters();

        public static GameManager GameManager = new GameManager();

        public static void Initialization()
        {
            // Log system initialization
            log4net.Config.XmlConfigurator.Configure();

        }
    }
}
