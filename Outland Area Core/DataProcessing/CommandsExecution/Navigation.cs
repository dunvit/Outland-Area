using EngineCore.Session;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;
using System.Linq;

namespace EngineCore.DataProcessing.CommandsExecution
{
    public class Navigation
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execution(GameSession gameSession, EngineSettings settings, Command command)
        {
            var currentCelestialObject = gameSession.GetCelestialObject(command.CelestialObjectId, false);

            Logger.Debug($"[{GetType().Name}][Execution] Execution Navigation command - {command.Type} turn '{gameSession.Turn}'");

            var module = gameSession.GetPlayerSpaceShip().GetPropulsionModules().First();

            if(module.Reloading < module.ReloadTime)
            {
                Logger.Info($"[{GetType().Name}][Execution] Module {module.Name} still on reloading. " +
                    $"Progress {module.Reloading}/{module.ReloadTime} .");

                return gameSession;
            }

            switch (command.Type)
            {
                case CommandTypes.MoveForward:
                    break;
                case CommandTypes.TurnLeft:
                    return TurnLeft(gameSession, currentCelestialObject, module);
                case CommandTypes.TurnRight:
                    return TurnRight(gameSession, currentCelestialObject, module);
                case CommandTypes.StopShip:
                    return StopShip(gameSession, currentCelestialObject, module);
                case CommandTypes.Acceleration:
                    return Acceleration(gameSession, currentCelestialObject, module);
                    
            }


            return null;
        }

        

        private GameSession Acceleration(GameSession gameSession, ICelestialObject celestialObject, IModule module)
        {
            // TODO: Add property Agility to Spacecraft
            const float SpacecraftAgility = 1;

            var spacecraft = (Spaceship)celestialObject;

            spacecraft.Speed += SpacecraftAgility;

            if (spacecraft.Speed > spacecraft.MaxSpeed) spacecraft.Speed = spacecraft.MaxSpeed;

            module.Reload();

            return gameSession;
        }


        private GameSession StopShip(GameSession gameSession, ICelestialObject celestialObject, IModule module)
        {
            // TODO: Add property Agility to Spacecraft
            const float SpacecraftAgility = 1;

            celestialObject.Speed = celestialObject.Speed - SpacecraftAgility;

            if (celestialObject.Speed < 0) celestialObject.Speed = 0;

            module.Reload();

            return gameSession;
        }

        private GameSession TurnLeft(GameSession gameSession, ICelestialObject celestialObject, IModule module)
        {
            // TODO: Add property Mobility to Spacecraft
            const float MobilityInDegrees = 10.0f;

            double directionBeforeManeuver = celestialObject.Direction;
            double directionAfterManeuver = (directionBeforeManeuver - MobilityInDegrees > 0) ? directionBeforeManeuver - MobilityInDegrees : 360 - (directionBeforeManeuver - MobilityInDegrees);

            celestialObject.Direction = directionAfterManeuver;

            module.Reload();

            return gameSession;
        }

        private GameSession TurnRight(GameSession gameSession, ICelestialObject celestialObject, IModule module)
        {
            // TODO: Add property Mobility to Spacecraft
            const float MobilityInDegrees = 10.0f;

            double directionBeforeManeuver = celestialObject.Direction;
            double directionAfterManeuver = (directionBeforeManeuver + MobilityInDegrees < 360.1) ? directionBeforeManeuver + MobilityInDegrees : (directionBeforeManeuver + MobilityInDegrees) - 360;

            celestialObject.Direction = directionAfterManeuver;

            module.Reload();

            return gameSession;
        }
        
    }
}
