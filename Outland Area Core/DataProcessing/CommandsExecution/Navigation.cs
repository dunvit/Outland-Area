using EngineCore.Session;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;

namespace EngineCore.DataProcessing.CommandsExecution
{
    public class Navigation
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execution(GameSession gameSession, TurnSettings settings, Command command)
        {
            var currentCelestialObject = gameSession.GetCelestialObject(command.CelestialObjectId, false);

            Logger.Debug($"[{GetType().Name}][Execution] Execution Navigation command - {command.Type} turn '{gameSession.Turn}'");

            switch (command.Type)
            {
                case CommandTypes.MoveForward:
                    break;
                case CommandTypes.TurnLeft:
                    return TurnLeft(gameSession, currentCelestialObject);
                case CommandTypes.TurnRight:
                    return TurnRight(gameSession, currentCelestialObject);
                case CommandTypes.StopShip:
                    return StopShip(gameSession, currentCelestialObject);
                case CommandTypes.Acceleration:
                    return Acceleration(gameSession, currentCelestialObject);
                    
            }

            return null;
        }

        private GameSession Acceleration(GameSession gameSession, ICelestialObject celestialObject)
        {
            // TODO: Add property Agility to Spacecraft
            const float SpacecraftAgility = 1;

            var spacecraft = (Spaceship)celestialObject;

            spacecraft.Speed += SpacecraftAgility;

            if (spacecraft.Speed > spacecraft.MaxSpeed) spacecraft.Speed = spacecraft.MaxSpeed;

            return gameSession;
        }


        private GameSession StopShip(GameSession gameSession, ICelestialObject celestialObject)
        {
            // TODO: Add property Agility to Spacecraft
            const float SpacecraftAgility = 1;

            celestialObject.Speed = celestialObject.Speed - SpacecraftAgility;

            if (celestialObject.Speed < 0) celestialObject.Speed = 0;

            return gameSession;
        }

        private GameSession TurnLeft(GameSession gameSession, ICelestialObject celestialObject)
        {
            // TODO: Add property Mobility to Spacecraft
            const float MobilityInDegrees = 0.5f;

            double directionBeforeManeuver = celestialObject.Direction;
            double directionAfterManeuver = (directionBeforeManeuver - MobilityInDegrees > 0) ? directionBeforeManeuver - MobilityInDegrees : 360 - (directionBeforeManeuver - MobilityInDegrees);

            celestialObject.Direction = directionAfterManeuver;

            return gameSession;
        }

        private GameSession TurnRight(GameSession gameSession, ICelestialObject celestialObject)
        {
            // TODO: Add property Mobility to Spacecraft
            const float MobilityInDegrees = 0.5f;

            double directionBeforeManeuver = celestialObject.Direction;
            double directionAfterManeuver = (directionBeforeManeuver + MobilityInDegrees < 361) ? directionBeforeManeuver + MobilityInDegrees : (directionBeforeManeuver + MobilityInDegrees) - 360;

            celestialObject.Direction = directionAfterManeuver;

            return gameSession;
        }
        
    }
}
