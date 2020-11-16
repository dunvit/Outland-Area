using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Server;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;

namespace OutlandAreaLocalServer
{
    public class LocalGameServer : IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GameSession _gameSession;
        private Timer turnCalculation;

        public GameSession Initialization()
        {
            Logger.Info($"[{GetType().Name}]\t [Initialization]");
            _gameSession = Convertor.ToGameSession(Convertor.GetSavedMap("Map_004"));

            _gameSession.Commands = new List<Command>();

            turnCalculation = new Timer();
            turnCalculation.Elapsed += ExecuteTurnCalculation;
            turnCalculation.Interval = 1000;
            turnCalculation.Enabled = true;

            return _gameSession;
        }

        private bool isDebug;

        private void ExecuteTurnCalculation(object sender, ElapsedEventArgs e)
        {
            if (isDebug) return;

            isDebug = true;

            TurnCalculation();

            isDebug = false;
        }

        public GameSession RefreshGameSession(int id)
        {
            Logger.Debug($"[{GetType().Name}]\t RefreshGameSession id={id}");
            return _gameSession;
        }

        public void ResumeSession(int id)
        {
            Logger.Debug($"[{GetType().Name}]\t ResumeSession id={id}");
            _gameSession.Map.IsEnabled = true;
        }

        public void PauseSession(int id)
        {
            Logger.Debug($"[{GetType().Name}]\t PauseSession id={id}");
            _gameSession.Map.IsEnabled = false;
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
                Type = (CommandTypes) typeId
            };

            _gameSession.AddCommand(command);
        }

        public void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name)
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


        private void TurnCalculation()
        {
            Logger.Debug($"[{GetType().Name}]\t [TurnCalculation] Start");

            var stopwatch1 = Stopwatch.StartNew();
            
            if (_gameSession.Map.IsEnabled == false)
                return;

            var turnGameSession = _gameSession.DeepClone();

            turnGameSession.Map = new Coordinates().Recalculate(turnGameSession.Map);

            turnGameSession = new Commands().Execute(turnGameSession);

            turnGameSession.Turn++;

            _gameSession = turnGameSession;

            Logger.Info($"[{GetType().Name}]\t [TurnCalculation] Finish {stopwatch1.Elapsed.TotalMilliseconds} ms");

        }
    }
}
