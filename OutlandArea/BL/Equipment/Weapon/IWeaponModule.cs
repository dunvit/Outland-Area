using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.BL.Equipment.Weapon
{
    public interface IWeaponModule
    {
        double ReloadTime { get; set; }
        double ShieldDamage { get; set; }

        double CriticalHit { get; set; }
    }
}
