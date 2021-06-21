using EngineCore;

namespace Outland_Area_CoreTests
{
    public class EnvironmentGlobal
    {
        public static void Initialization()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        private static int sessionID = 0;

        public static LocalGameServer CreateGameServer(string sessionName, EngineSettings settings = null)
        {
            var localServer = new LocalGameServer();

            if (settings == null)
                settings = new EngineSettings();

            localServer.Initialization(sessionName, settings, false);

            //localServer.ResumeSession(1);

            return localServer;
        }

        

    }
}
