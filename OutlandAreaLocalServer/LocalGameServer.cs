using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Ammunition.Missiles;
using OutlandAreaCommon.Server;
using OutlandAreaCommon.Server.DataProcessing;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaCommon.Universe.Objects.Spaceships;
using OutlandAreaLocalServer.Actions;
using OutlandAreaLocalServer.ArtificialIntelligence;

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
            _gameSession = Convertor.ToGameSession(Convertor.GetSavedMap("Map_OneShip"));
            //_gameSession = Convertor.ToGameSession(Convertor.GetSavedMap("Map_FirstBattle"));
            //_gameSession = Convertor.ToGameSession(Convertor.GetSavedMap("Map_005"));

            _gameSession.Commands = new List<Command>();

            turnCalculation = new Timer();
            turnCalculation.Elapsed += ExecuteTurnCalculation;
            turnCalculation.Interval = 1000;
            turnCalculation.Enabled = true;

            return _gameSession;
        }

        public GameSession Initialization(string sessionName)
        {
            Logger.Info($"[{GetType().Name}]\t [Initialization]");

            _gameSession = Convertor.ToGameSession(Convertor.GetSavedMap(sessionName));

            _gameSession.Commands = new List<Command>();

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

        public GameSession RefreshGameSession(int id = 0)
        {
            Logger.Debug($"[{GetType().Name}]\t RefreshGameSession id={id}");
            return _gameSession;
        }

        public void ResumeSession(int id = 0)
        {
            Logger.Debug($"[{GetType().Name}]\t ResumeSession id={id}");
            _gameSession.SpaceMap.IsEnabled = true;
        }

        public void PauseSession(int id)
        {
            Logger.Debug($"[{GetType().Name}]\t PauseSession id={id}");
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

        public void AddCelestialObject(int sessionId, int objectId, float positionX, float positionY, int direction, int speed,
            int classification, string name, int ammoId, int moduleId, int shipOwnerId)
        {

            var missile = MissilesFactory.GetMissile(ammoId).ToCelestialObject();

            missile.Id = objectId;
            missile.PositionX = positionX;
            missile.PositionY = positionY;
            missile.Direction = direction;
            missile.Speed = speed;
            missile.Name = name;
            missile.OwnerId = moduleId;

            _gameSession.AddCelestialObject(missile);

            Command(sessionId, shipOwnerId, moduleId, 0, 0, CommandTypes.ReloadWeapon.ToInt());
        }


        public void TurnCalculation()
        {
            var stopwatch1 = Stopwatch.StartNew();
            
            if (_gameSession.SpaceMap.IsEnabled == false)
                return;

            var turnGameSession = _gameSession.DeepClone();

            turnGameSession.AddHistoryMessage($"Calculation start", GetType().Name, true);

            turnGameSession = new AutomaticLaunchModules().Execute(turnGameSession);

            turnGameSession = new Commands().Execute(turnGameSession);

            turnGameSession.SpaceMap = new Coordinates().Recalculate(turnGameSession.SpaceMap);

            turnGameSession.SpaceMap = new Reloading().Recalculate(turnGameSession);

            turnGameSession.SpaceMap = new AI().Execute(turnGameSession);

            turnGameSession.AddHistoryMessage($"Calculation finished {stopwatch1.Elapsed.TotalMilliseconds} ms.", GetType().Name, true);

            turnGameSession.History.Add(turnGameSession.Turn, turnGameSession.TurnHistory);

            turnGameSession.Turn++;

            _gameSession = turnGameSession;
        }

        public void ForceUpdate(ICelestialObject celestialObject)
        {
            foreach (var mapObject in _gameSession.SpaceMap.CelestialObjects.Where(mapObject => mapObject.Id == celestialObject.Id))
            {
                mapObject.Direction = celestialObject.Direction;
                mapObject.PositionY = celestialObject.PositionY;
                mapObject.PositionX = celestialObject.PositionX;
                mapObject.Speed = celestialObject.Speed;
            }
        }
    }
}
