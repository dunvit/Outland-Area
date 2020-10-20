using System.Collections.Generic;
using Engine.Layers.Tactical;
using Engine.Tools;

namespace Engine.Management.Server
{
    public class LocalGameServer : IGameServer
    {
        private GameSession _gameSession;

        public GameSession Initialization()
        {
            _gameSession = DataProcessing.Convertor.ToGameSession(DataProcessing.Convertor.GetSavedMap("Map_003"));

            _gameSession.Commands = new List<Command>();

            Scheduler.Instance.ScheduleTask(10, 1000, TurnCalculation);

            return _gameSession;
        }

        public GameSession RefreshGameSession(int id)
        {
            return _gameSession;
        }

        public void ResumeSession(int id)
        {
            _gameSession.Map.IsEnabled = true;
        }

        public void PauseSession(int id)
        {
            _gameSession.Map.IsEnabled = false;
        }

        public void Command(int sessionId, int objectId, int targetObjectId, int memberId, int targetCell, int typeId)
        {
            _gameSession.Commands.Add(new Command
            {
                CelestialObjectId = objectId,
                TargetCelestialObjectId = targetObjectId,
                MemberId = memberId,
                TargetCellId = targetCell,
                CommandTypeId = typeId
            });
        }


        private bool _isCalculationInProcess;

        private void TurnCalculation()
        {
            if (_gameSession.Map.IsEnabled == false)
                return;

            if (_isCalculationInProcess)
                return;

            _isCalculationInProcess = true;

            var turnGameSession = _gameSession.DeepClone();

            turnGameSession.Map = new DataProcessing.Coordinates().Recalculate(turnGameSession.Map);

            turnGameSession = new DataProcessing.Commands().Execute(turnGameSession);

            turnGameSession.Turn++;

            _gameSession = turnGameSession;

            _isCalculationInProcess = false;

        }
    }
}
