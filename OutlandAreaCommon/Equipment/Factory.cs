using System;
using OutlandAreaCommon.Equipment.General.Reactor;
using OutlandAreaCommon.Equipment.General.Scanner;
using OutlandAreaCommon.Equipment.Propulsion;
using OutlandAreaCommon.Equipment.Shield;
using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Equipment
{
    public class Factory
    {
        public static IModule CreateMicroWarpDrive(int ownerId, string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "PMV5002":
                    resultModule = new MicroWarpDrive {
                        Id = new Random().NextInt(),
                        OwnerId = ownerId,
                        ActivationCost = 100, 
                        Power = 2000, 
                        Category = Category.Propulsion, 
                        Name = "Civilian Prototype Mk I"};
                    break;
            }
            return resultModule;
        }

        public static IModule CreateWeaponModule(int ownerId, string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "WRS5002":
                    resultModule = new LightMissileLauncher
                    {
                        Id = new Random().NextInt(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Category = Category.Weapon,
                        ReloadTime = 12,
                        Reloading = 12,
                        AmmoId = 101,
                        Name = "Light Missile Launcher I"
                    };
                    break;
            }

            return resultModule;
        }

        public static IModule CreateGeneralModule(int ownerId, string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "SCR5001":
                    resultModule = new Scanner
                    {
                        Id = new Random().NextInt(),
                        OwnerId = ownerId,
                        Category = Category.Scanner,
                        ScanRange = 2000,
                        Power = 55,
                        ActivationCost = 10,
                        Name = "Scanner Mk I"
                    };
                    break;
                case "GRM5002":
                    resultModule = new Reactor
                    {
                        Id = new Random().NextInt(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Power = 2000,
                        Category = Category.Reactor,
                        Name = "Reactor Mk I"
                    };
                    break;
            }

            return resultModule;
        }

        public static IModule CreateShieldModule(int ownerId, string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "SSM5001":
                    resultModule = new ShieldModule
                    {
                        Id = new Random().NextInt(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Power = 200,
                        Category = Category.Shield,
                        Name = "Shield Mk I"
                    };
                    break;

                case "SSM5002":
                    resultModule = new ShieldModule
                    {
                        Id = new Random().NextInt(),
                        OwnerId = ownerId,
                        ActivationCost = 110,
                        Power = 250,
                        Category = Category.Shield,
                        Name = "Shield Mk II"
                    };
                    break;
            }

            return resultModule;
        }
    }
}
