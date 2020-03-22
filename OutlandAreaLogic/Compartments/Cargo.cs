using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.Compartments
{
    public partial class Cargo : UserControl, ICompartment
    {
        public Cargo()
        {
            InitializeComponent();

            Name = "Cargo";

        }
    }
}
