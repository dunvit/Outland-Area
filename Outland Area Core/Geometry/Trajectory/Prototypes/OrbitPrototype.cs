using System;
using System.Numerics;

namespace EngineCore.Geometry.Trajectory.Prototypes
{
    public class OrbitPrototype
    {
        public static Vector2 Execute(Vector2 center, Vector2 startPos, float speed, float time)
        {
            // positive speed means CCW around the center, negative means CW.
            var radiusVec = (startPos - center);
            var radius = radiusVec.Length();
            var angularVelocity = speed / radius; // Add check for divide by zero
            var perpendicularVec = new Vector2(-radiusVec.Y, radiusVec.X);
            return center + (float)Math.Cos(time * angularVelocity) * radiusVec + (float)Math.Sin(time * angularVelocity) * perpendicularVec;
        }
    }
}
