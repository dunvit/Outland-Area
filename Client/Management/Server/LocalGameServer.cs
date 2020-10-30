using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using Engine.Layers.Tactical;
using Engine.Layers.Tactical.Objects;
using Engine.Tools;
using log4net;

namespace Engine.Management.Server
{
    public class LocalGameServer : IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GameSession _gameSession;
        private Timer aTimer;

        public GameSession Initialization()
        {
            Logger.Info("[IGameServer Initialization]");
            _gameSession = DataProcessing.Convertor.ToGameSession(DataProcessing.Convertor.GetSavedMap("Map_004"));

            _gameSession.Commands = new List<Command>();

            aTimer = new Timer();
            aTimer.Elapsed += ExecuteTurnCalculation;
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            //Scheduler.Instance.ScheduleTask(10, 1000, TurnCalculation);

            return _gameSession;
        }

        private void ExecuteTurnCalculation(object sender, ElapsedEventArgs e)
        {
            TurnCalculation();
        }

        public GameSession RefreshGameSession(int id)
        {
            Logger.Debug($"RefreshGameSession id={id}");
            return _gameSession;
        }

        public void ResumeSession(int id)
        {
            Logger.Debug($"ResumeSession id={id}");
            _gameSession.Map.IsEnabled = true;
        }

        public void PauseSession(int id)
        {
            Logger.Debug($"PauseSession id={id}");
            _gameSession.Map.IsEnabled = false;
        }

        public void Command(int sessionId, int objectId, int targetObjectId, int memberId, int targetCell, int typeId)
        {
            Logger.Debug($"Add command sessionId={sessionId} objectId={objectId} targetObjectId={targetObjectId} typeId={typeId}");
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

        public void AddCelestialObject(int sessionId, int objectId, int positionX, int positionY, int direction, int speed,
            int classification)
        {
            Logger.Debug($"Add celestial object sessionId={sessionId} objectId={objectId} positionX={positionX} positionY={positionY} classification={classification}");

            ICelestialObject celestialObject = new PointInSpace
            {
                Id = objectId,
                PositionX = positionX,
                PositionY = positionY,
                Classification = classification,
                Direction = direction,
                Speed = speed,
                Name = "Point In Space"
            };

            _gameSession.AddCelestialObject(celestialObject);
        }


        private bool _isCalculationInProcess;

        private void TurnCalculation()
        {
            Logger.Debug($"[TurnCalculation] Start");

            var stopwatch1 = Stopwatch.StartNew();

            
            if (_gameSession.Map.IsEnabled == false)
                return;

            //if (_isCalculationInProcess)
            //    return;

            //_isCalculationInProcess = true;

            var turnGameSession = _gameSession.DeepClone();

            turnGameSession.Map = new DataProcessing.Coordinates().Recalculate(turnGameSession.Map);

            turnGameSession = new DataProcessing.Commands().Execute(turnGameSession);

            turnGameSession.Turn++;

            _gameSession = turnGameSession;

            //_isCalculationInProcess = false;

            Logger.Debug($"[TurnCalculation] Finish {stopwatch1.Elapsed.TotalMilliseconds} ms");

        }
    }
}
