using System;
using EngineCore.Tools;

namespace EngineCore.Universe.Pilots
{
    public class AbstractPilot: IPilot
    {
        public long Id { get; }
        public string Name { get; }
        public string Family { get; }
        public Gender Gender { get; }
        public int Age { get; }
        public double SkillsMissileLauncherOperation { get; private set; }
        public double SkillsAutoCannon { get; private set; }
        public int Health { get; }

        public AbstractPilot(Gender gender)
        {
            Id = RandomGenerator.GetId();
            Gender = gender;
            Health = 100;

            switch (gender)
            {
                case Gender.Female:
                    Name = RandomGenerator.FemaleFirstName();
                    break;
                case Gender.Male:
                    Name = RandomGenerator.MaleFirstName();
                    break;
            }

            Family = RandomGenerator.LastName();

            Age = RandomGenerator.GetInteger(18, 48);
        }

        public void SetSkill(Skills skill, double value)
        {
            switch (skill)
            {
                case Skills.MissileLauncherOperation:
                    SkillsMissileLauncherOperation = value;
                    break;
                case Skills.AutoCannon:
                    SkillsAutoCannon = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(skill), skill, null);
            }
        }
    }
}
