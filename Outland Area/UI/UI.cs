using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Engine.Configuration;
using Engine.UI.Model;

namespace Engine.UI
{
    public class UITools
    {
        public static PointF ToScreenCoordinates(IScreenInfo screenParameters, PointF celestialObjectPosition)
        {
            var relativeX = (celestialObjectPosition.X - screenParameters.CenterScreenOnMap.X) + screenParameters.Width / 2;
            var relativeY = (celestialObjectPosition.Y - screenParameters.CenterScreenOnMap.Y) + screenParameters.Height / 2;

            return new PointF(relativeX, relativeY);
        }

        public static PointF ToMapCoordinates(ScreenParameters screenParameters, PointF celestialObjectPosition)
        {
            var relativeX = screenParameters.CenterScreenOnMap.X - screenParameters.Width / 2 + celestialObjectPosition.X;
            var relativeY = screenParameters.CenterScreenOnMap.Y - screenParameters.Height / 2 + celestialObjectPosition.Y;

            return new PointF(relativeX, relativeY);
        }

        public static Bitmap LoadGenericImage(string file)
        {
            var images = Path.Combine(Environment.CurrentDirectory, "Images");

            var fileFullName = Path.Combine(images, file.Replace("/","\\") + ".png");

            if (File.Exists(fileFullName))
            {
                var orig = new Bitmap(fileFullName);
                var clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                }

                return clone;
            }

            return null;
        }

        public static Bitmap LoadCharacterImage(string file, string image = "Front")
        {
            var images = Path.Combine(Environment.CurrentDirectory, @"Data\Characters\" + file);

            var fileFullName = Path.Combine(images, image.Replace("/", "\\") + ".png");

            if (File.Exists(fileFullName))
            {
                var orig = new Bitmap(fileFullName);
                var clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                }

                return clone;
            }

            return null;
        }



        public static Bitmap LoadImage(string file)
        {
            var patternsFolder = Path.Combine(Environment.CurrentDirectory, "Images", "Ships");

            var fileFullName = Path.Combine(patternsFolder, file + ".png");

            if (File.Exists(fileFullName))
            {
                var orig = new Bitmap(fileFullName);
                var clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(clone))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
                }

                return clone;
            }

            return null;
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }
    }
}
