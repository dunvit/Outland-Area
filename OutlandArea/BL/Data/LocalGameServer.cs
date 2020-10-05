using System;
using System.Collections.Generic;
using log4net.Util;
using OutlandArea.Map;
using OutlandArea.Tools;

namespace OutlandArea.BL.Data
{
    public class LocalGameServer : IGameServer
    {
        private GameSession _gameSession;

        public GameSession Initialization()
        {
            _gameSession = Convertor.ToGameSession(Convertor.GetSavedMap("Map_003"));

            _gameSession.Commands = new List<GameCommand>();

            TaskScheduler.Instance.ScheduleTask(10, 1000, TurnCalculation);

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
            _gameSession.Commands.Add(new GameCommand
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

            turnGameSession.Map = new Calculation.Coordinates().Recalculate(turnGameSession.Map);

            turnGameSession = new Calculation.Commands().Execute(turnGameSession);

            turnGameSession.Turn++;

            _gameSession = turnGameSession;

            _isCalculationInProcess = false;

        }
    }
}
