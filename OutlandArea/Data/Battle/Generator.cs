using System;
using System.Drawing;
using System.Threading;
using OutlandArea.TacticalBattleLayer.Spacecrafts;

namespace OutlandArea.Data.Battle
{
    public class Generator
    {
        public static TacticalBattleLayer.Battle GetBasicBattle(Action<string> logger)
        {
            var battle = new TacticalBattleLayer.Battle{Logger = logger};

            var playerShip = new Thorax
            {
                Direction = 15,
                Id = DateTime.UtcNow.Ticks,
                Name = "Cobra MkIV",
                Location = new Point(10000, 10000),
                Velocity = 340,
                IsPlayerSpacecraft = true
            };

            battle.InitializationCoreSpacecraft(playerShip);

            battle.AddCelestialObjects(playerShip);

            Thread.Sleep(100);

            battle.AddCelestialObjects(new Dragoon
            {
                Direction = 270,
                Id = DateTime.UtcNow.Ticks,
                Location = new Point(9800, 10100),
                Velocity = 562,
                Name = "Pilot N" + new Random().Next(1, 10000)
            });

            Thread.Sleep(100);

            battle.AddCelestialObjects(new Dragoon
            {
                Direction = 180,
                Id = DateTime.UtcNow.Ticks,
                Location = new Point(9700, 10100),
                Velocity = 562,
                Name = "Pilot N" + new Random().Next(1, 10000)
            });

            return battle;
        }
    }
}
