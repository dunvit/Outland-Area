using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace OutlandAreaLocalServer.ArtificialIntelligence
{
    public class Navigation
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CelestialMap Execute(CelestialMap spaceMap, List<Command> sessionCommands)
        {
            Logger.Debug(TraceMessage.Execute(this, "Start NPC navigation logic."));

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
                AddNavigationChange(spaceship, targetSpaceships.FirstOrDefault(_ => _.Id == spaceship.TargetId));
            }

            return spaceMap;
        }

        private void AddNavigationChange(Spaceship npcShip, Spaceship targetSpaceship)
        {
            Logger.Debug(TraceMessage.Execute(this, $"Set navigation npc-commend for {npcShip.Id} to {targetSpaceship.Id}."));

            npcShip.TargetId = targetSpaceship.Id;

        }
    }
}
