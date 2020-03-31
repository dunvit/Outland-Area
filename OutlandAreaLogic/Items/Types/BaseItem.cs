
namespace OutlandAreaLogic.Items.Types
{
    public class BaseItem: IItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}
