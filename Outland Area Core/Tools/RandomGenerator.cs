﻿using System;
using System.Linq;
using System.Net.NetworkInformation;
using RandomNameGeneratorLibrary;

namespace EngineCore.Tools
{
    public static class RandomGenerator
    {
        private static readonly Random RandomBase = new Random((int)DateTime.UtcNow.Ticks);

        private static readonly PersonNameGenerator PersonGenerator = new PersonNameGenerator(new Random((int)DateTime.UtcNow.Ticks));

        public static int GetInteger(int min = 0, int max = 0)
        {
            return RandomBase.Next(min, max);
        }

        public static int GetInteger(int min)
        {
            return RandomBase.Next(min);
        }

        public static int GetId()
        {
            return RandomBase.Next(1000000000, int.MaxValue);
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

        public static string GenerateGameEventId()
        {
            return RandomString(3) + "-" + RandomNumber(12) + "-" + RandomNumber(4);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomBase.Next(s.Length)]).ToArray());
        }

        public static string RandomName()
        {
            return PersonGenerator.GenerateRandomFemaleFirstAndLastName();
        }

        public static string FemaleFirstAndLastName()
        {
            return PersonGenerator.GenerateRandomFemaleFirstAndLastName();
        }

        public static string MaleFirstAndLastName()
        {
            return PersonGenerator.GenerateRandomMaleFirstAndLastName();
        }

        public static string FemaleFirstName()
        {
            return PersonGenerator.GenerateRandomFemaleFirstName();
        }

        public static string MaleFirstName()
        {
            return PersonGenerator.GenerateRandomMaleFirstName();
        }

        public static string LastName()
        {
            return PersonGenerator.GenerateRandomLastName();
        }


        public static string RandomNumber(int length)
        {
            const string chars = "1234567890";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[RandomBase.Next(s.Length)]).ToArray());
        }
    }
}
