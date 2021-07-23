namespace EngineCore.Universe.Pilots
{
    public interface IPilot
    {
        long Id { get; }

        string Name { get; }

        string Family { get; }

        Gender Gender { get; }

        int Age { get; }

        double SkillsMissileLauncherOperation { get; }

        double SkillsAutoCannon { get; }

        int Health { get; }
    }
}