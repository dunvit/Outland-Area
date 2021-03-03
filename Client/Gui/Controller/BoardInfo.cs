using System.Collections.Generic;
using System.Drawing;
using Engine.Gui.Controls.TacticalLayer;
using Engine.Gui.Model;
using OutlandAreaCommon.Common;

namespace Engine.Gui.Controller
{
    public class BoardInfo : IBoardInfo
    {
        public IScreenInfo ScreenInfo { get; set; }
        public FixedSizedQueue<SortedDictionary<int, GranularObjectInformation>> History { get; set; }
        public SortedDictionary<int, GranularObjectInformation> TurnInfo { get; set; }
        public Graphics GraphicSurface { get; set; }
        public int TurnStep { get; set; }
    }
}
