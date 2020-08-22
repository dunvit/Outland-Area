using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandArea.Map
{
    public class CelestialMap
    {
        public string Id { get; set; }
        public List<ICelestialObject> CelestialObjects { get; set; } = new List<ICelestialObject>();
    }
}
