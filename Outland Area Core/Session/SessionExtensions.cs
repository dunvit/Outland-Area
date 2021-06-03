using System.Linq;
using System.Reflection;
using EngineCore.Tools;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using LanguageExt;
using log4net;

namespace EngineCore.Session
{
    public static class SessionExtensions
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static Spaceship GetPlayerSpaceShip(this GameSession session)
        {
            foreach (var celestialObject in session.SpaceMap.CelestialObjects)
            {
                if (celestialObject.Classification == 200)
                {
                    return celestialObject.ToSpaceship();
                }
            }

            return null;
        }

        public static ICelestialObject GetCelestialObject(this GameSession gameSession, long id, bool isCopy = true)
        {
            if(isCopy)
                return (from celestialObjects in gameSession.SpaceMap.CelestialObjects where id == celestialObjects.Id select celestialObjects.DeepClone()).FirstOrDefault();

            return (from celestialObjects in gameSession.SpaceMap.CelestialObjects where id == celestialObjects.Id select celestialObjects).FirstOrDefault();
        }

        public static void AddHistoryMessage(this GameSession session, string message, string className, bool isTechnicalLog = false)
        {
            Logger.Debug($"[HistoryMessage]\t [{className}]\t {message} ");

            session.TurnHistory.Add(new HistoryMessage
            {
                Turn = session.Turn,
                Class = className,
                Message = message,
                IsTechnicalLog = isTechnicalLog
            });
        }
    }
}
