using EngineCore.Tools;
using EngineCore.Universe.Equipment;

namespace EngineCore.Universe.Objects.Spaceships
{
    public class Fury 
    {
        public static Spaceship Generate()
        {
            var spaceShip = new Spaceship
            {
                Id = RandomGenerator.GetId(), 
                Name = "Fury - A" + RandomGenerator.RandomString(6), 
                MaxSpeed = 6,
                Speed = 6,
                Classification = CelestialObjectTypes.SpaceshipNpcEnemy.ToInt(),
                IsScanned = false,
                Signature = 12
            };

            spaceShip.Modules.Add(Factory.CreateShieldModule(spaceShip.Id, "SSM5001"));
            spaceShip.Modules.Add(Factory.CreateGeneralModule(spaceShip.Id, "GRM5002"));
            spaceShip.Modules.Add(Factory.CreateWeaponModule(spaceShip.Id, "WRS5003"));
            spaceShip.Modules.Add(Factory.CreateMicroWarpDrive(spaceShip.Id, "PMV5002"));
            //CreateMicroWarpDrive

            spaceShip.Initialization();

            return spaceShip;
        }
    }
}
