using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandAreaCommon.Universe;

namespace OutlandAreaCommon.Tactical
{
    public interface ICelestialMap
    {
        string Id { get; set; }
        int Turn { get; set; }
        bool IsEnabled { get; set; }
        List<ICelestialObject> CelestialObjects { get; set; }
    }
}
