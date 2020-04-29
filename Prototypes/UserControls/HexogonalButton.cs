using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.UserControls
{
    public partial class HexogonalButton : UserControl
    {
        private EventHandler onClick;

        public event EventHandler Click
        {
            add { onClick += value; }
            remove { onClick -= value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                label1.Text = value;
                //base.BackgroundImage
            }
        }

        [Description("Image"), Category("Data")]
        public override Image BackgroundImage
        {
            
            set => pictureBox2.Image = value;
        }

        [Description("Test text displayed in the textbox"), Category("Data")]
        public Image TextAddition
        {
            get { return pictureBox2.Image; }
            set { pictureBox2.Image = value; }
        }


        public HexogonalButton()
        {
            InitializeComponent();

            
        }



        private void label1_MouseEnter(object sender, EventArgs e)
        {
            imageAvatar.Image = Properties.Resources.Hex2ButtonPng_Selected;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            imageAvatar.Image = Properties.Resources.Hex2ButtonPng;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            onClick?.Invoke(this, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
