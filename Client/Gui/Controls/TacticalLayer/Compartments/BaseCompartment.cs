using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Gui.Controls.TacticalLayer.Compartments
{
    public partial class BaseCompartment : UserControl
    {
        public string CompartmentModuleName 
        { 
            get => txtName.Text; 

            set
            {
                txtName.Text = value.ToUpper();
                Refresh();
            }
        }

        public BaseCompartment()
        {
            InitializeComponent();
        }
    }
}
