using System;
using System.Drawing;
using OutlandArea.TacticalBattleLayer.Spacecrafts;

namespace OutlandArea.Data.Battle
{
    public class Generator
    {
        public static TacticalBattleLayer.Battle GetBasicBattle()
        {
            var battle = new TacticalBattleLayer.Battle();

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

            battle.AddCelestialObjects(new Dragoon
            {
                Direction = 270,
                Location = new Point(9800, 10100),
                Velocity = 562,
                Name = "Pilot N" + new Random().Next(1, 10000)
            });


            battle.AddCelestialObjects(new Dragoon
            {
                Direction = 180,
                Location = new Point(9700, 10100),
                Velocity = 562,
                Name = "Pilot N" + new Random().Next(1, 10000)
            });

            return battle;
        }
    }
}
