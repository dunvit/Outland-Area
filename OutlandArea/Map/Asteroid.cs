using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.Map
{
    public class Asteroid: ICelestialObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Direction { get; set; }
        public int Signature { get; set; }
        public int Speed { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Classification { get; set; }
        public string ImageSmall { get; set; }
        public bool IsScanned { get; set; }
    }
}
