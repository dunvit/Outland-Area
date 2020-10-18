using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandArea.BL.Equipment;
using OutlandArea.BL.Equipment.Shield;

namespace OutlandArea.Map.Objects.Spaceships
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
