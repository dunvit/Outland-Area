using System;
using EngineCore.Universe.Equipment.Ammunition.Missiles.LightMissiles;

namespace EngineCore.Universe.Equipment.Ammunition.Missiles
{
    public class AmmoFactory
    {
        public static IMissile GetAmmo(int id)
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
