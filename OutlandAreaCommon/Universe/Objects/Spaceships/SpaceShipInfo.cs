using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Shield;

namespace OutlandAreaCommon.Universe.Objects.Spaceships
{
    public class SpaceShipInfo
    {
        public double Shields { get; set; }
        public int Power { get; private set; }

        public SpaceShipInfo(Spaceship ship)
        {
            Shields = 0;

            foreach (var shipModule in ship.Modules)
            {
                if (shipModule.Category == Category.Shield)
                {
                    var shieldModule = (ShieldModule) shipModule;

                    Shields += shieldModule.Power;
                }
            }
        }
    }
}
