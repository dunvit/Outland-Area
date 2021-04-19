using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engine.Tools;
using log4net;
using OutlandAreaCommon.Common;
using OutlandAreaCommon.Equipment;
using OutlandAreaCommon.Tactical;
using OutlandAreaCommon.Universe;

namespace Engine.Gui
{
    public partial class TacticalScreen : UserControl
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GameSession _gameSession;

        public TacticalScreen()
        {
            InitializeComponent();

            if (DebugTools.IsInDesignMode()) return;

            Global.Game.OnEndTurn += CalculateTurnInformation;
            Global.Game.OnActivateModule += ActivateModule;
            Global.Game.OnExecuteModuleForSelectObjectOnMap += ExecuteModuleForSelectSelectObject;
            Global.Game.OnActivateModuleForSelectObjectInMap += ExecuteModuleForSelectSelectObject;
        }

        private void ActivateModule(IModule module)
        {
            Logger.Info(TraceMessage.Execute(this, $"ActivateModule {module.Name}."));
        }

        private void ExecuteModuleForSelectSelectObject(IModule arg1, Func<GameSession, List<ICelestialObject>> getObjects)
        {
            if (_gameSession is null) return;
            
            var objects = getObjects(_gameSession);

            Logger.Info(TraceMessage.Execute(this, $"ExecuteModuleForSelectSelectObject {arg1.Name} execute. Objects cont is {objects.Count}."));
        }

        private void CalculateTurnInformation(GameSession gameSession)
        {
            _gameSession = gameSession;
            Logger.Info(TraceMessage.Execute(this, $"Turn {gameSession.Turn} execute."));
        }
    }
}
