
namespace OutlandAreaCommon.Tactical.Scenario.Dialog
{
    public class Row
    {
        public Character Character;
        public Align Align;
        public string Message;

        public Row(Character character, string message, Align align = Align.Front)
        {
            Character = character;
            Align = align;
            Message = message;
        }

    }
}
