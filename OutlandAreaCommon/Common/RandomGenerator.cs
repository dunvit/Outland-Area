using System;
using System.Linq;

namespace OutlandAreaCommon.Common
{
    public static class RandomGenerator
    {
        private static readonly Random RandomBase = new Random((int)DateTime.UtcNow.Ticks);

        public static int GetInteger(int max = 0, int min = 0)
        {
            return RandomBase.Next(min, max);
        }

        public static double GetDouble(double minimum = 0, double maximum = 0)
        {
            return RandomBase.NextDouble() * (maximum - minimum) + minimum;
        }

        public static double DiceRoller(int numberOfSides = 100)
        {
            return RandomBase.NextDouble() * numberOfSides;
        }

        public static double Direction()
        {
            return GetDouble(0, 359);
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
