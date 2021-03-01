using System.Collections.Generic;
using System.Diagnostics;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Server;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;
using OutlandAreaLocalServer;

namespace Engine.Management.Server
{
    public class LocalStaticGameServer: IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GameSession _gameSession;


        public LocalStaticGameServer(string map = "Map_004")
        {
            Initialization(map);
        }

        public GameSession Initialization()
        {
            _gameSession = ScenarioConvertor.ToGameSession(ScenarioConvertor.GetSavedMap("Map_003"));

            return _gameSession;
        }

        public GameSession Initialization(string map = "Map_004")
        {
            _gameSession = ScenarioConvertor.ToGameSession(ScenarioConvertor.GetSavedMap(map));

            _gameSession.Commands = new List<Command>();

            return _gameSession;
        }

        public GameSession RefreshGameSession(int id)
        {
            return _gameSession;
        }

        public void ResumeSession(int id)
        {
            _gameSession.SpaceMap.IsEnabled = true;
        }

        public void PauseSession(int id)
        {
            _gameSession.SpaceMap.IsEnabled = false;
        }

        public void Command(int sessionId, int objectId, int targetObjectId, int memberId, int targetCell, int typeId)
        {
            Logger.Debug($"[{GetType().Name}]\t Add command sessionId={sessionId} objectId={objectId} targetObjectId={targetObjectId} typeId={typeId}");
            var command = new Command
            {
                CelestialObjectId = objectId,
                TargetCelestialObjectId = targetObjectId,
                MemberId = memberId,
                TargetCellId = targetCell,
                Type = (CommandTypes)typeId
            };

            _gameSession.AddCommand(command);
        }

        public void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed, int classification, string name)
        {
            Logger.Debug($"[{GetType().Name}]\t Add celestial object sessionId={sessionId} objectId={objectId} positionX={positionX} positionY={positionY} classification={classification}");

            ICelestialObject celestialObject;

            switch (classification)
            {
                case 300:
                    celestialObject = new Missile
                    {
                        Id = objectId,
                        PositionX = positionX,
                        PositionY = positionY,
                        Classification = classification,
                        Direction = direction,
                        Speed = speed,
                        Name = name
                    };
                    break;

                default:
                    celestialObject = new PointInSpace
                    {
                        Id = objectId,
                        PositionX = positionX,
                        PositionY = positionY,
                        Classification = classification,
                        Direction = direction,
                        Speed = speed,
                        Name = name
                    };
                    break;
            }

            _gameSession.AddCelestialObject(celestialObject);
        }

        public void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name, int ammoId, int moduleId, int shipOwnerId)
        {
            
        }

        public void TurnCalculation()
        {
            Logger.Debug($"[{GetType().Name}]\t [TurnCalculation] Start");

            var stopwatch1 = Stopwatch.StartNew();

            var turnGameSession = _gameSession.DeepClone();

            turnGameSession = new Commands().Execute(turnGameSession);

            turnGameSession.SpaceMap = new Coordinates().Recalculate(turnGameSession.SpaceMap);

            turnGameSession.Turn++;

            _gameSession = turnGameSession;

            Logger.Info($"[{GetType().Name}]\t [TurnCalculation] Finish {stopwatch1.Elapsed.TotalMilliseconds} ms");

        }
    }
}
