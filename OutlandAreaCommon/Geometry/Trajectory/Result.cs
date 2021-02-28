using System.Collections.Generic;
using Engine.Common.Geometry;

namespace OutlandAreaCommon.Geometry.Trajectory
{
    public class Result
    {
        public List<SpaceMapObjectLocation> Trajectory { get; set; } = new List<SpaceMapObjectLocation>();

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
