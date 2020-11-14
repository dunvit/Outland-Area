using System.Drawing;

namespace OutlandAreaCommon.Server.DataProcessing
{
    public class ObjectLocation
    {
        public Point Coordinates { get; set; }

        public double VectorToTarget { get; set; }

        public double Direction { get; set; }

        public double Distance { get; set; }

        public bool IsLinearMotion { get; set; }

        public int Iteration { get; set; }

        public PointF Point { get; set; }
    }
}
