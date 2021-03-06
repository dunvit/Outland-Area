﻿using System;
using OutlandAreaCommon.Equipment.Ammunition.Missiles;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Equipment
{
    public static class CategoryAmmoExtensions
    {
        public static string ToString(this CategoryAmmo ammo)
        {
            switch (ammo)
            {
                case CategoryAmmo.LightMissile:
                    return "Light Missile";
                case CategoryAmmo.SmallHybridCharge:
                    return "Small Hybrid Charge";
                default:
                    throw new ArgumentOutOfRangeException(nameof(ammo), ammo, null);
            }
        }

        public static ICelestialObject ToCelestialObject(this IMissile missile)
        {
            return (ICelestialObject) missile;
        }
    }
}
