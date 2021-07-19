using System;
using EngineCore.Session;
using EngineCore.Universe.Equipment;
using EngineCore.Universe.Model;
using EngineCore.Universe.Objects;
using log4net;
using Newtonsoft.Json.Linq;

namespace EngineCore.DataProcessing.CommandsExecution
{
    public class Navigation
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GameSession Execution(GameSession gameSession, EngineSettings settings, Command command)
        {
            var currentCelestialObject = gameSession.GetCelestialObject(command.CelestialObjectId);

            var jObject = JObject.Parse(command.Body);
            var moduleId = int.Parse(jObject["ModuleId"].ToString());

            var module = gameSession.GetCelestialObject(command.CelestialObjectId).ToSpaceship().GetModule(moduleId);


            if(command.UntilTurnId == 0)
                command.UntilTurnId = (int)(gameSession.Turn + module.ReloadTime * settings.UnitsPerSecond);


            Logger.Debug($"[{GetType().Name}][Execution] Execution Navigation command - {command.Type} turn '{gameSession.Turn}' " +
                        $"until turn {command.UntilTurnId}");

            switch (command.Type)
            {
                case CommandTypes.MoveForward:
                    break;
                case CommandTypes.TurnLeft:
                    return TurnLeft(gameSession, currentCelestialObject, module, settings);
                case CommandTypes.TurnRight:
                    return TurnRight(gameSession, currentCelestialObject, module, settings);
                case CommandTypes.StopShip:
                    return StopShip(gameSession, currentCelestialObject, module, settings);
                case CommandTypes.Acceleration:
                    return Acceleration(gameSession, currentCelestialObject, module, settings);
                    
            }


            return null;
        }

        

        private GameSession Acceleration(GameSession gameSession, ICelestialObject celestialObject, IModule module, EngineSettings settings)
        {
            // TODO: Add property Agility to Spacecraft
            const float SpacecraftAgility = 1;

            var spacecraft = (Spaceship)celestialObject;

            double turnSpeed = SpacecraftAgility / (settings.UnitsPerSecond * module.ReloadTime);

            var speedAfterCalculation = celestialObject.Speed + (float)turnSpeed;

            if (spacecraft.Speed > spacecraft.MaxSpeed) speedAfterCalculation = spacecraft.MaxSpeed;

            celestialObject.SetSpeed(speedAfterCalculation);

            module.Reload();

            return gameSession;
        }


        private GameSession StopShip(GameSession gameSession, ICelestialObject celestialObject, IModule module, EngineSettings settings)
        {
            // TODO: Add property Agility to Spacecraft
            const float SpacecraftAgility = 1;

            double turnSpeed = SpacecraftAgility / (settings.UnitsPerSecond * module.ReloadTime);

            var speedAfterCalculation = celestialObject.Speed - (float)turnSpeed;

            if (celestialObject.Speed < 0) speedAfterCalculation = 0;

            celestialObject.SetSpeed(speedAfterCalculation);

            module.Reload();

            return gameSession;
        }

        private GameSession TurnLeft(GameSession gameSession, ICelestialObject celestialObject, IModule module, EngineSettings settings)
        {
            // TODO: Add property Mobility to Spacecraft
            const float MobilityInDegrees = 10.0f;

            var spacecraft = (Spaceship)celestialObject;

            double turnRotationSpeed = MobilityInDegrees / (settings.UnitsPerSecond * module.ReloadTime);

            double directionBeforeManeuver = celestialObject.Direction;
            double directionAfterManeuver = (directionBeforeManeuver - turnRotationSpeed > 0) ? directionBeforeManeuver - turnRotationSpeed : 360 - (directionBeforeManeuver - turnRotationSpeed);

            celestialObject.SetDirection(directionAfterManeuver);

            module.Reload();

            gameSession.AddHistoryMessage($"The ship '{spacecraft.Name}' changed direction {MobilityInDegrees} degrees from {Math.Round(directionBeforeManeuver,2)} to {Math.Round(directionAfterManeuver, 2)}. ");

            return gameSession;
        }

        private GameSession TurnRight(GameSession gameSession, ICelestialObject celestialObject, IModule module, EngineSettings settings)
        {
            // TODO: Add property Mobility to Spacecraft
            const float MobilityInDegrees = 10.0f;

            double turnRotationSpeed = MobilityInDegrees / (settings.UnitsPerSecond * module.ReloadTime);

            var spacecraft = (Spaceship)celestialObject;

            double directionBeforeManeuver = celestialObject.Direction;
            double directionAfterManeuver = (directionBeforeManeuver + turnRotationSpeed < 360.1) ? directionBeforeManeuver + turnRotationSpeed : (directionBeforeManeuver + turnRotationSpeed) - 360;

            celestialObject.SetDirection(directionAfterManeuver);

            module.Reload();

            gameSession.AddHistoryMessage($"The ship '{spacecraft.Name}' changed direction {MobilityInDegrees} degrees from {Math.Round(directionBeforeManeuver, 2)} to {Math.Round(directionAfterManeuver, 2)}. ");

            return gameSession;
        }
        
    }
}
