using System;
using OutlandAreaCommon.Equipment.Ammunition.Missiles.LightMissiles;

namespace OutlandAreaCommon.Equipment.Ammunition.Missiles
{
    public class MissilesFactory
    {
        public static IMissile GetMissile(int id)
        {
            switch (id)
            {
                case 101:
                    return new InfernoLightMissile();

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
