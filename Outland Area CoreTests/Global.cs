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

        public static LocalGameServer CreateGameServer(string sessionName)
        {
            var localServer = new LocalGameServer();

            localServer.Initialization(sessionName);

            localServer.ResumeSession(1);

            return localServer;
        }
    }
}
