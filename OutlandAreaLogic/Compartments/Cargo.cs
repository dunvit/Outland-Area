using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OutlandAreaLogic.Compartments;

namespace Engine.Compartments
{
    public partial class Cargo : UserControl, ICompartment
    {
        public Cargo()
        {
            InitializeComponent();

            Name = "Cargo";

        }



        private void oaButton1_Click_1(object sender, EventArgs e)
        {
            var a = 0;
        }

        public void Activate()
        {
            
        }
    }
}
