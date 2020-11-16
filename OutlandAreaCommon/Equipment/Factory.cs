using OutlandAreaCommon.Equipment.General.Reactor;
using OutlandAreaCommon.Equipment.Propulsion;
using OutlandAreaCommon.Equipment.Shield;
using OutlandAreaCommon.Equipment.Weapon;

namespace OutlandAreaCommon.Equipment
{
    public class Factory
    {
        public static IModule CreateMicroWarpDrive(string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "PMV5002":
                    resultModule = new MicroWarpDrive {
                        ActivationCost = 100, 
                        Power = 2000, 
                        Category = Category.Propulsion, 
                        Name = "Civilian Prototype Mk I"};
                    break;
            }

            return resultModule;
        }

        public static IModule CreateWeaponModule(string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "WRS5002":
                    resultModule = new RailGun
                    {
                        ActivationCost = 100,
                        CriticalHit = 10,
                        Category = Category.Weapon,
                        ReloadTime = 5,
                        ShieldDamage = 200,
                        Name = "125mm Railgun I"
                    };
                    break;
            }

            return resultModule;
        }

        public static IModule CreateGeneralModule(string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "GRM5002":
                    resultModule = new Reactor
                    {
                        ActivationCost = 100,
                        Power = 2000,
                        Category = Category.Reactor,
                        Name = "Reactor Mk I"
                    };
                    break;
            }

            return resultModule;
        }

        public static IModule CreateShieldModule(string id)
        {
            IModule resultModule = null;

            switch (id)
            {
                case "SSM5001":
                    resultModule = new ShieldModule
                    {
                        ActivationCost = 100,
                        Power = 200,
                        Category = Category.Shield,
                        Name = "Shield Mk I"
                    };
                    break;

                case "SSM5002":
                    resultModule = new ShieldModule
                    {
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
