using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.Map
{
    public interface ICelestialObject
    {
        long Id { get; set; }
        string Name { get; set; }
        int Direction { get; set; }
        int Signature { get; set; }
        int Speed { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        int Classification { get; set; }
        string ImageSmall { get; set; }
        bool IsScanned { get; set; }
    }
}
