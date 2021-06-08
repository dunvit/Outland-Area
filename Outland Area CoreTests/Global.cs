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

        public static LocalGameServer CreateGameServer(string sessionName, EngineCore.DataProcessing.TurnSettings settings = null)
        {
            var localServer = new LocalGameServer();

            if (settings == null)
                settings = new EngineCore.DataProcessing.TurnSettings();

            localServer.Initialization(sessionName, settings);

            //localServer.ResumeSession(1);

            return localServer;
        }

        

    }
}
