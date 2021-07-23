using EngineCore.Tools;

namespace EngineCore.Universe.Pilots
{
    public static class PilotsFactory
    {
        private static AbstractPilot BlankPilot(Gender gender = Gender.NotDetermined)
        {
            if (gender == Gender.NotDetermined) gender = RandomGenerator.GetInteger(0, 1).ToGender();

            var gunner = new AbstractPilot(gender);

            gunner.SetSkill(Skills.MissileLauncherOperation, RandomGenerator.GetInteger(40, 55));

            return gunner;
        }

        public static IPilot GenerateGunner(Gender gender = Gender.NotDetermined)
        {
            var gunner = BlankPilot(gender);

            gunner.SetSkill(Skills.MissileLauncherOperation, RandomGenerator.GetInteger(50, 65));

            return gunner;
        }

        public static IPilot GeneratePointDefenseOperator(Gender gender = Gender.NotDetermined)
        {
            var gunner = BlankPilot(gender);

            gunner.SetSkill(Skills.AutoCannon, RandomGenerator.GetInteger(50, 65));

            return gunner;
        }
    }
}
