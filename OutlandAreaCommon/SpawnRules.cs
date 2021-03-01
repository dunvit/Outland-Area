using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlandAreaCommon
{
    [Serializable]
    public class SpawnRules
    {
        public bool IsRandomObjectsGeneration { get; set; } = true;

        public double AsteroidSmallSize { get; set; } = 20;
    }
}
