using System;
using System.Linq;
using System.Reflection;
using log4net;
using log4net.Repository.Hierarchy;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;

namespace OutlandAreaCommon.Common
{
    public static class RandomGenerator
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly Random RandomBase = new Random((int)DateTime.UtcNow.Ticks);

        public static int Get(int max = 0, int min = 0)
        {

            return RandomBase.Next(min, max);
        }

        public static int GetModuleId()
        {
            return RandomBase.Next(100000);
        }

        public static double Direction()
        {
            return Tools.Randomize(0, 359);
        }

        public static ICelestialObject Asteroid(GameSession gameSession)
        {
            return CelestialObjectsFactory.GenerateAsteroid(gameSession);
        }

        public static string GenerateCelestialObjectName()
        {
            return RandomString(6) + "-" + RandomNumber(4) + "-" + RandomNumber(4);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomBase.Next(s.Length)]).ToArray());
        }

        public static string RandomNumber(int length)
        {
            const string chars = "1234567890";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomBase.Next(s.Length)]).ToArray());
        }
    }
}
