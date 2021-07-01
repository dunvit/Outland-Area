using EngineCore;
using EngineCore.Session;

namespace Outland_Area_CoreTests
{
    public class EnvironmentGlobal
    {
        public static void Initialization()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static LocalGameServer CreateGameServer(string sessionName, EngineSettings settings = null)
        {
            var localServer = new LocalGameServer();

            if (settings == null)
                settings = new EngineSettings();

            localServer.Initialization(sessionName, settings, false);

            //localServer.ResumeSession(1);

            return localServer;
        }

        public static GameSession GetSession(LocalGameServer server)
        {
            return new GameSession(server.RefreshGameSession(server.SessionId));
        }

        public static GameSession GetSessionServerSide(LocalGameServer server)
        {
            return server.RefreshGameSessionServerSide(server.SessionId);
        }
    }
}
