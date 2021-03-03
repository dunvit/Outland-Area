using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Gui.Controls.TacticalLayer;
using OutlandAreaCommon.Common;

namespace Engine.Gui.Model
{
    public interface IBoardInfo
    {
        IScreenInfo ScreenInfo { get; set; }

        FixedSizedQueue<SortedDictionary<int, GranularObjectInformation>> History { get; set; }

        SortedDictionary<int, GranularObjectInformation> TurnInfo { get; set; }

        Graphics GraphicSurface { get; set; }

        int TurnStep { get; set; }
    }
}
