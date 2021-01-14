using System.Reflection;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;

namespace OutlandAreaLocalServer.ArtificialIntelligence
{
    public class AI
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CelestialMap Execute(GameSession gameSession)
        {
            Logger.Debug(TraceMessage.Execute(this, "Start execute artificial intelligence logic."));

            var result = gameSession.SpaceMap.DeepClone();

            result = new Targeting().Execute(result);

            result = new Navigation().Execute(result, gameSession.Commands);

            result = new Attack().Execute(result, gameSession);

            return result;
        }
    }
}
