using System;
using System.Drawing;

namespace Engine.Common.Geometry
{
    [Serializable]
    public class SpaceMapObjectLocation
    {
        public double Direction { get; set; }

        public double Distance { get; set; }

        public MovementType Status { get; set; }

        public int Iteration { get; set; }

        public PointF Coordinates { get; set; }
    }
}
