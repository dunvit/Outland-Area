using System;

namespace OutlandAreaLocalServer
{
    public static class RandomGenerator
    {
        private static readonly Random random = new Random((int)DateTime.UtcNow.Ticks);

        public static int Get(int max = 0, int min = 0)
        {

            return random.Next(min, max);
        }
    }
}
