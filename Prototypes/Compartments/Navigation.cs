using System.Windows.Forms;

namespace Engine.Compartments
{
    public partial class Navigation : UserControl, ICompartment
    {
        public Navigation()
        {
            InitializeComponent();

            Name = "Navigation";
        }
    }
}
