namespace EngineCore.Session.Actions
{
    public class ModuleAction
    {
        public int ModuleId { get; }

        public int ActionId { get; }

        public ModuleAction(int moduleId, int actionId)
        {
            ModuleId = moduleId;
            ActionId = actionId;
        }
    }
}
