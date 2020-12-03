using System.Collections.Generic;
using Engine.Common.Geometry;

namespace OutlandAreaCommon.Geometry.Trajectory
{
    public class Result
    {
        public List<ObjectLocation> Trajectory { get; set; } = new List<ObjectLocation>();

        public bool IsCorrect
        {
            get
            {
                if (Trajectory.Count == 0) return false;

                if (Trajectory[Trajectory.Count - 1].Status == MovementType.Turn)
                {
                    return false;
                }

                return true;
            }
        }
    }


}
