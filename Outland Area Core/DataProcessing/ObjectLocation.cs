using System.Drawing;

namespace EngineCore.DataProcessing
{
    public class ObjectLocation
    {
        public PointF Coordinates { get; set; }

        public double VectorToTarget { get; set; }

        public double Direction { get; set; }

        public double Distance { get; set; }

        public bool IsLinearMotion { get; set; }

        public int Iteration { get; set; }

        public PointF Point { get; set; }
    }
}
