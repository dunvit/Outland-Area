﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Engine.Gui;
using Engine.Management.Server;
using Engine.Tools;
using log4net;
using OutlandAreaCommon;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Equipment.Ammunition.Missiles;
using OutlandAreaCommon.Server;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;
using OutlandAreaCommon.Universe.Objects;
using OutlandAreaLocalServer;

namespace Engine.Management
{
    public class GameManager
    {
        private readonly IGameServer _gameServer;

        private readonly Settings _applicationSettings;
        private GameSession _gameSession;
        
        public event Action<GameSession> OnEndTurn;
        public event Action<GameSession> OnBattleInitialization;
        public event Action<IModule> OnActivateModule;
        public event Action<IModule, Func<GameSession, List<ICelestialObject>>> OnExecuteModuleForSelectObjectOnMap;
        public event Action<IModule, Func<GameSession, List<ICelestialObject>>> OnActivateModuleForSelectObjectInMap;
        public event Action<ICelestialObject> OnMouseMoveCelestialObject;
        public event Action<ICelestialObject> OnMouseLeaveCelestialObject;
        public event Action<ICelestialObject> OnSelectCelestialObject;
        public event Action<GameEvent, GameSession> OnAnomalyFound;
        public event Action<GameEvent, GameSession> OnOpenDialog;
        public event Action<GameEvent, GameSession> OnFoundSpaceship;




        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IUiManager _ui;

        public GameManager()
        {
            _applicationSettings = LoadConfiguration();

            switch (_applicationSettings.ServerType)
            {
                case 1:
                    _gameServer = new ScalaGameServer(_applicationSettings, null);
                    break;
                case 2:
                    _gameServer = new LocalStaticGameServer();
                    break;

                case 3:
                    _gameServer = new LocalGameServer();
                    break;
            }
        }

        public void Initialization(IUiManager uiManager)
        {
            _ui = uiManager;
        }

        public void StartNewGameSession()
        {
            _ui.StartNewGameSession();

            _gameSession = Initialization();

            OnBattleInitialization?.Invoke(_gameSession.DeepClone());
            OnEndTurn?.Invoke(_gameSession.DeepClone());
        }

        private static Settings LoadConfiguration()
        {
            return new Settings();
        }

        public void ResumeSession()
        {
            _gameServer.ResumeSession(_gameSession.Id);
        }

        public void PauseSession()
        {
            _gameServer.PauseSession(_gameSession.Id);
        }

        public void Command(int gameSessionId, int celestialObjectId, int targetCelestialObjectId, int memberId, int targetCell, int typeId)
        {
            _gameServer.Command(gameSessionId, celestialObjectId, targetCelestialObjectId, memberId, targetCell, typeId);
        }

        public void MouseMoveCelestialObject(ICelestialObject celestialObject)
        {
            OnMouseMoveCelestialObject?.Invoke(celestialObject);
        }

        public void MouseLeaveCelestialObject(ICelestialObject celestialObject)
        {
            OnMouseLeaveCelestialObject?.Invoke(celestialObject);
        }

        public void SelectCelestialObject(ICelestialObject celestialObject)
        {
            Logger.Info("A celestial object is selected.");

            _gameSession.SelectedObject = celestialObject.DeepClone();

            OnSelectCelestialObject?.Invoke(celestialObject);
        }

        public void SelectPointInSpace(PointF pointInSpace)
        {
            Logger.Debug("A point in space is selected.");

            ICelestialObject celestialObject = new PointInSpace
            {
                PositionX = pointInSpace.X, 
                PositionY = pointInSpace.Y, 
                Id = -1, 
                Name = "Point in Space",
                Classification = -1
            };

            _gameSession.SelectedObject = celestialObject.DeepClone();

            OnSelectCelestialObject?.Invoke(celestialObject);
        }

        public ICelestialObject GetSelectedObject()
        {
            return _gameSession.SelectedObject;
        }

        public GameSession Initialization()
        {
            _gameSession = _gameServer.Initialization();

            Logger.Info($"[{GetType().Name}]\t Initialization finished successful.");

            Scheduler.Instance.ScheduleTask(100, 100, GetDataFromServer, null);

            return _gameSession;
        }

        private int turn = -1;

        private void GetDataFromServer()
        {
            var timeMetricGetGameSession = Stopwatch.StartNew();
            
            var gameSession = _gameServer.RefreshGameSession(_gameSession.Id);

            if (gameSession != null)
            {
                _gameSession = gameSession;
            }
            else
            {
                Logger.Error($"Critical error on refresh game id={_gameSession.Id}.");
                return;
            }

            timeMetricGetGameSession.Stop();

            if (_gameSession.Turn > turn)
            {
                StartNewOneSecondTurn(_gameSession);
            }

            Logger.Debug($"GetInteger game session parsing finished for {timeMetricGetGameSession.Elapsed.TotalMilliseconds}. " +
                    $"Game session id = {_gameSession.Id}." +
                    $" Turn = {_gameSession.Turn}." +
                    $" SpaceMap objects count is {_gameSession.SpaceMap.CelestialObjects.Count}.");
        }

        private void StartNewOneSecondTurn(GameSession gameSession)
        {
            turn = gameSession.Turn;
            Logger.Debug($"[StartNewOneSecondTurn] {turn}");

            OnEndTurn?.Invoke(gameSession);

            foreach (var message in gameSession.GetCurrentTurnEvents())
            {
                if (message.IsPause) PauseSession();

                if (message.Type == GameEventTypes.AnomalyFound)
                {
                    OnAnomalyFound?.Invoke(message, gameSession);
                }

                if (message.Type == GameEventTypes.OpenDialog)
                {
                    OnOpenDialog?.Invoke(message, gameSession);
                }

                // TODO: LAST - ADD NpcSpaceShipFound logic to Container and open window with message
                if (message.Type == GameEventTypes.NpcSpaceShipFound)
                {
                    OnFoundSpaceship?.Invoke(message, gameSession);
                }
            }

            
        }

        public void AddCommandAlignTo(ICelestialObject celestialObject)
        {
            var playerShip = _gameSession.GetPlayerSpaceShip();

            if ((CelestialObjectTypes) celestialObject.Classification == CelestialObjectTypes.PointInMap)
            {
                celestialObject.Id = RandomGenerator.GetId();
                celestialObject.Name = "Point in space";
                celestialObject.Classification = (int) CelestialObjectTypes.PointInMap;

                AddCelestialObject(celestialObject);
            }

            Command(_gameSession.Id, playerShip.Id, celestialObject.Id, 0, 0, (int) CommandTypes.AlignTo);
        }

        public void AddCommandOrbit(ICelestialObject celestialObject)
        {
            var playerShip = _gameSession.GetPlayerSpaceShip();

            Command(_gameSession.Id, playerShip.Id, celestialObject.Id, 0, 0, (int)CommandTypes.Orbit);
        }

        public void AddCommandOpenFire(ICelestialObject missile)
        {
            var playerShip = _gameSession.GetPlayerSpaceShip();

            var targetPointInSpace = new PointInSpace
            {
                Id = RandomGenerator.GetId(),
                PositionY = missile.PositionY,
                PositionX = missile.PositionX,
                Speed = 0,
                Direction = 0,
                Name = "Missile Target",
                Signature = 1,
                Classification = (int)CelestialObjectTypes.PointInMap,
                IsScanned = true
            };

            missile.PositionX = playerShip.PositionX;
            missile.PositionY = playerShip.PositionY;
            //missile.OwnerId = playerShip.Id;

            AddCelestialObject(targetPointInSpace);
            AddMissile(playerShip, missile);

            Command(_gameSession.Id, missile.Id, targetPointInSpace.Id, 0, 0, (int)CommandTypes.Fire);
        }

        public void AddCelestialObject(ICelestialObject celestialObject)
        {
            _gameServer.AddCelestialObject(_gameSession.Id, celestialObject.Id, celestialObject.PositionX, celestialObject.PositionY, (int)celestialObject.Direction, celestialObject.Speed, celestialObject.Classification, celestialObject.Name);
        }

        public void AddMissile(ICelestialObject playerShip, ICelestialObject celestialObject)
        {
            var missile = (IMissile) celestialObject;

            _gameServer.AddCelestialObject(
                _gameSession.Id, 
                celestialObject.Id, 
                celestialObject.PositionX, 
                celestialObject.PositionY, 
                (int)celestialObject.Direction, 
                celestialObject.Speed, 
                celestialObject.Classification, 
                celestialObject.Name,
                missile.AmmoId,
                celestialObject.OwnerId,
                playerShip.Id);
        }

        public void ExecuteModule(IModule module)
        {
            switch (module.Category)
            {
                case Category.Weapon:
                    var missile = MissilesFactory.GetMissile(module.ToWeapon().AmmoId).ToCelestialObject();

                    missile.OwnerId = (int)module.Id;
                    OnExecuteModuleForSelectObjectOnMap?.Invoke(module, SpaceMapActions.GetSpaceshipsByDistance);
                    //OnExecuteModuleForPointInMap?.Invoke(module, missile);
                    break;
                case Category.Shield:
                    break;
                case Category.Propulsion:
                    break;
                case Category.Reactor:
                    break;
                case Category.SpaceScanner:
                    break;
                case Category.DeepScanner:
                    OnActivateModuleForSelectObjectInMap?.Invoke(module, SpaceMapActions.GetUnknownCelestialObjectsByDistance);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ActivateModule(IModule module)
        {
            switch (module.Category)
            {
                case Category.Weapon:
                    OnActivateModule?.Invoke(module);
                    //_ui.ConnectClosestObjects(_gameSession, module, SpaceMapActions.GetSpaceshipsByDistance(_gameSession), true);
                    break;
                case Category.Shield:
                    OnActivateModule?.Invoke(module);
                    break;
                case Category.Propulsion:
                    OnActivateModule?.Invoke(module);
                    break;
                case Category.Reactor:
                    OnActivateModule?.Invoke(module);
                    break;
                case Category.SpaceScanner:
                    OnActivateModule?.Invoke(module);
                    break;
                case Category.DeepScanner:
                    _ui.ConnectClosestObjects(_gameSession, module, SpaceMapActions.GetUnknownCelestialObjectsByDistance(_gameSession), true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        public void DeactivateModule(IModule module)
        {
            switch (module.Category)
            {
                case Category.Weapon:
                    _ui.ConnectClosestObjects(_gameSession, module, new List<ICelestialObject>(), false);
                    break;
                case Category.Shield:
                    break;
                case Category.Propulsion:
                    break;
                case Category.Reactor:
                    break;
                case Category.SpaceScanner:
                    break;
                case Category.DeepScanner:
                    _ui.ConnectClosestObjects(_gameSession, module, new List<ICelestialObject>(), false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void NavigationChangeDirection(IModule module, CommandTypes directionType)
        {
            var playerShip = _gameSession.GetPlayerSpaceShip();

            Command(_gameSession.Id, playerShip.Id, (int) module.Id, 0, 0, (int)directionType);
        }
    }
}
