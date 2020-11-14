
namespace OutlandAreaCommon.Equipment
{
    public interface IModule
    {
        long Id { get; set; }
        string Name { get; set; }
        Category Category { get; set; }

        double ActivationCost { get; set; }
    }
}
