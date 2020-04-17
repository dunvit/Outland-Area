using System.Drawing;
using System.Windows.Forms;

namespace Engine
{
    public class GameManagerPrototype
    {
        public Form screenB { get; set; } 

        public Form screenA { get; set; } 


        public void Activate()
        {
            screenB = new ScreenB { Visible = false, Size = new Size(1280, 720) };

            screenA = new ScreenA { Visible = false, Size = new Size(1280, 720) };
        }

        public void Resize(Size size)
        {
            screenA.Size = size;
            screenB.Size = size;
        }
    }
}
