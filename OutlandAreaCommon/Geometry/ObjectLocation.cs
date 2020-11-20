using System.Drawing;

namespace Engine.Common.Geometry
{
    public class ObjectLocation
    {
        public double Direction { get; set; }

        public double Distance { get; set; }

        public MovementType Status { get; set; }

        public int Iteration { get; set; }

        public PointF Coordinates { get; set; }
    }
}
