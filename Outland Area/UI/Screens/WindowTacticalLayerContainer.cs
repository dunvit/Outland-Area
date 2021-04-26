using System;
using System.Windows.Forms;
using log4net;

namespace Engine.UI.Screens
{
    public partial class WindowTacticalLayerContainer : BaseFullScreenWindow
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WindowTacticalLayerContainer()
        {
            InitializeComponent();
        }

        private void Event_LoadTacticalLayer(object sender, EventArgs e)
        {
            crlTacticalMap.Dock = DockStyle.Fill;

            Logger.Info("[TacticalLayerContainer]\t Initialization finished successful.");
        }

        private void crlTacticalMap_Load(object sender, EventArgs e)
        {

        }
    }
}
