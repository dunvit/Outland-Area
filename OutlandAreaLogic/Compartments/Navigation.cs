using System.Windows.Forms;
using OutlandAreaLogic.Compartments;

namespace Engine.Compartments
{
    public partial class Navigation : UserControl, ICompartment
    {
        public Navigation()
        {
            InitializeComponent();

            Name = "Navigation";
        }

        public void Activate()
        {
            
        }
    }
}
