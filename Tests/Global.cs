using OutlandAreaLocalServer;

namespace Tests
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

            localServer.ResumeSession();

            return localServer;
        }
    }
}
