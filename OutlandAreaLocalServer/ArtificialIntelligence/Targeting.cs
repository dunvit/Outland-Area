using System;
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
    public class Targeting
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CelestialMap Execute(CelestialMap spaceMap)
        {
            Logger.Info(TraceMessage.Execute(this, "Start NPC targeting logic."));

            var npcSpaceships = spaceMap.CelestialObjects.
                Where(_ => _.IsSpaceship()).
                Where(_ => _.Classification == (int)CelestialObjectTypes.SpaceshipNpcEnemy).
                Where(_ => _.ToSpaceship().TargetId < 1).ToList(); // Check if no need targeting process

            var targetSpaceships = spaceMap.CelestialObjects.
                Where(_ => _.IsSpaceship()).
                Where(_ => _.Classification == (int)CelestialObjectTypes.SpaceshipPlayer || _.Classification == (int)CelestialObjectTypes.SpaceshipNpcFriend).ToList();

            foreach (var celestialObject in npcSpaceships)
            {
                AddTarget(celestialObject.ToSpaceship(), targetSpaceships);
            }


            return spaceMap;
        }

        private void AddTarget(Spaceship npcShip, List<ICelestialObject> targetSpaceships)
        {
            var id = RandomGenerator.Get(targetSpaceships.Count);
            try
            {
                var targetSpaceship = targetSpaceships[id];

                npcShip.TargetId = targetSpaceship.Id;
            }
            catch (Exception e)
            {
                Logger.Error(TraceMessage.Execute(this, $"Add target critical error. Message is {e.Message}"));
            }
            

        }
    }
}
