using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Ammunition.Missiles;
using OutlandAreaCommon.Equipment.Weapon;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace OutlandAreaLocalServer.ArtificialIntelligence
{
    public class Attack
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CelestialMap Execute(CelestialMap spaceMap, GameSession session)
        {
            Logger.Debug(TraceMessage.Execute(this, "Start NPC attack logic."));

            var npcSpaceships = spaceMap.CelestialObjects.
                Where(_ => _.IsSpaceship()).
                Where(_ => _.Classification == (int)CelestialObjectTypes.SpaceshipNpcEnemy).
                Map(_ => _.ToSpaceship()); // Convert to spaceship type

            var targetSpaceships = spaceMap.CelestialObjects.
                Where(_ => _.IsSpaceship()).
                Where(_ => _.Classification == (int)CelestialObjectTypes.SpaceshipPlayer || _.Classification == (int)CelestialObjectTypes.SpaceshipNpcFriend).
                Map(_ => _.ToSpaceship());


            foreach (var spaceship in npcSpaceships)
            {
                ImplementAttack(spaceship, targetSpaceships.FirstOrDefault(_ => _.Id == spaceship.TargetId), session, session.Commands);
            }

            return session.SpaceMap;
        }

        private void ImplementAttack(Spaceship npcShip, Spaceship targetSpaceship, GameSession session, List<Command> sessionCommands)
        {
            Logger.Debug(TraceMessage.Execute(this, $"Set attack npc-commend for {npcShip.Id} to {targetSpaceship.Id}."));

            var modulesWeapon = npcShip.Modules.
                Where(module => module.Category == Category.Weapon).
                //Map(_ => _.ToWeapon()). // Convert to weapon type
                Where(_ => _.ToWeapon().ReloadTime <= _.ToWeapon().Reloading); // GetInteger only modules with ready to use


            var distance = Coordinates.GetDistance(npcShip.GetLocation(), targetSpaceship.GetLocation());



            foreach (var weaponModule in modulesWeapon)
            {
                var missile = MissilesFactory.GetMissile(weaponModule.ToWeapon().AmmoId).ToCelestialObject();

                missile.Id = new Random().NextInt();
                missile.OwnerId = npcShip.Id;
                missile.PositionX = npcShip.PositionX;
                missile.PositionY = npcShip.PositionY;

                var weaponTargetPointInSpace = GetTargetLocation(targetSpaceship, missile, distance);

                var targetPointInSpace = new PointInSpace
                {
                    Id = new Random().NextInt(),
                    PositionY = weaponTargetPointInSpace.Y,
                    PositionX = weaponTargetPointInSpace.X,
                    Speed = 0,
                    Direction = 0,
                    Name = "Missile Target",
                    Signature = 1,
                    Classification = (int)CelestialObjectTypes.PointInMap,
                    IsScanned = true
                };

                session.AddCelestialObject(targetPointInSpace);
                session.AddCelestialObject(missile);

                var command = new Command
                {
                    CelestialObjectId = missile.Id,
                    TargetCelestialObjectId = targetPointInSpace.Id,
                    MemberId = 0,
                    TargetCellId = 0,
                    Type = CommandTypes.Fire
                };

                session.AddCommand(command);

                var commandReloadModule = new Command
                {
                    CelestialObjectId = npcShip.Id,
                    TargetCelestialObjectId = weaponModule.Id,
                    MemberId = 0,
                    TargetCellId = 0,
                    Type = CommandTypes.ReloadWeapon
                };

                session.AddCommand(commandReloadModule);
            }
        }

        private PointF GetTargetLocation(Spaceship targetSpaceship, ICelestialObject missile, double distance)
        {

            var firstIterationFlightTime = distance / missile.Speed;

            var targetSpaceshipNextPoint = Coordinates.MoveObject(
                targetSpaceship.GetLocation(), 
                (int) (targetSpaceship.Speed * firstIterationFlightTime),
                targetSpaceship.Direction);

            return targetSpaceshipNextPoint;
        }

    }
}
