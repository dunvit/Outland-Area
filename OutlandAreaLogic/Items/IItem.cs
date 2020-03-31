
namespace OutlandAreaLogic.Items
{
    public interface IItem
    {
        long Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string Picture { get; set; }
    }
}
