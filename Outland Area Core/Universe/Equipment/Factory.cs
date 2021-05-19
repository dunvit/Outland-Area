using System.IO;
using EngineCore.Tools;
using EngineCore.Universe.Equipment.General.Reactor;
using EngineCore.Universe.Equipment.General.Scanner;
using EngineCore.Universe.Equipment.Propulsion;
using EngineCore.Universe.Equipment.Shield;
using EngineCore.Universe.Equipment.Weapon;

namespace EngineCore.Universe.Equipment
{
    public class Factory
    {
        const int ticksInSecond = 10;

        public static IModule CreateMicroWarpDrive(int ownerId, string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "PMV5002":
                    resultModule = new MicroWarpDrive {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100, 
                        Power = 2000,
                        ReloadTime = 1 * ticksInSecond,
                        Reloading = 1 * ticksInSecond,
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
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Category = Category.Weapon,
                        ReloadTime = 12 * ticksInSecond,
                        Reloading = 12 * ticksInSecond,
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
                case "DSCR001":
                    resultModule = new DeepScanner
                    {
                        Category = Category.DeepScanner,
                        ScanRange = 300,
                        Power = 60,
                        ActivationCost = 70,
                        ReloadTime = 25 * ticksInSecond,
                        Reloading = 25 * ticksInSecond,
                        Name = "DeepScanner Mk I"
                    };
                    break;
                case "SCR5001":
                    resultModule = new SpaceScanner
                    {
                        Category = Category.SpaceScanner,
                        ScanRange = 2000,
                        Power = 55,
                        ActivationCost = 10,
                        ReloadTime = 5 * ticksInSecond,
                        Reloading = 5 * ticksInSecond,
                        Name = "SpaceScanner Mk I"
                    };
                    break;
                case "GRM5002":
                    resultModule = new Reactor
                    {
                        ActivationCost = 100,
                        Power = 2000,
                        ReloadTime = 1 * ticksInSecond,
                        Reloading = 1 * ticksInSecond,
                        Category = Category.Reactor,
                        Name = "Reactor Mk I"
                    };
                    break;

                default:
                    throw new InvalidDataException("Module not converted successfully.");
            }

            resultModule.Id = RandomGenerator.GetId();
            resultModule.OwnerId = ownerId;

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
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 100,
                        Power = 200,
                        ReloadTime = 1 * ticksInSecond,
                        Reloading = 1 * ticksInSecond,
                        Category = Category.Shield,
                        Name = "Shield Mk I"
                    };
                    break;

                case "SSM5002":
                    resultModule = new ShieldModule
                    {
                        Id = RandomGenerator.GetId(),
                        OwnerId = ownerId,
                        ActivationCost = 110,
                        Power = 250,
                        ReloadTime = 1 * ticksInSecond,
                        Reloading = 1 * ticksInSecond,
                        Category = Category.Shield,
                        Name = "Shield Mk II"
                    };
                    break;
            }

            return resultModule;
        }
    }
}
