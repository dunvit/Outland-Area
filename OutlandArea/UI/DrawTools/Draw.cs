using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutlandArea.Map;
using OutlandArea.Tools;

namespace OutlandArea.UI.DrawTools
{
    class Draw
    {
        public static void CelestialObjectDirectionArrow(Graphics graphics, Point celestialObjectPoint, int direction)
        {
            var angle = 150;
            var length = 8;

            var leftArrowDirection = ((direction + angle) > 360) ? direction + angle - 360 : direction + angle;
            var leftArrow = Common.MoveCelestialObjects(celestialObjectPoint, length, leftArrowDirection);

            graphics.DrawLine(new Pen(Color.DimGray, 1), celestialObjectPoint.X, celestialObjectPoint.Y, leftArrow.X, leftArrow.Y);

            angle = angle + 4;

            var rightArrowDirection = ((direction - angle) < 0) ? direction - angle + 360 : direction - angle;
            var rightArrow = Common.MoveCelestialObjects(celestialObjectPoint, length, rightArrowDirection);

            //graphics.DrawLine(new Pen(Color.DimGray, 1), celestialObjectPoint.X, celestialObjectPoint.Y, rightArrow.X, rightArrow.Y);
        }
    }
}
