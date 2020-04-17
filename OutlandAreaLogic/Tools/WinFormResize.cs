using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OutlandAreaLogic.Tools
{
    public class WinFormResize
    {
        private readonly List<Rectangle> _controlStorage = new List<Rectangle>();
        private const bool ShowRowHeader = false;

        public WinFormResize(Form form)
        {
            Form = form; //the calling form
            FormSize = form.ClientSize; //Save initial form size
            FontSize = form.Font.Size; //Font size

            _get_initial_size();
        }

        private float FontSize { get; set; }

        private SizeF FormSize { get; set; }

        private Form Form { get; set; }

        public void _get_initial_size() //get initial size//
        {
            var controls = _get_all_controls(Form);//call the enumerator
            foreach (var control in controls) //Loop through the controls
            {
                _controlStorage.Add(control.Bounds); //saves control bounds/dimension            
                                                          //If you have data grid view
                if (control.GetType() == typeof(DataGridView))
                    DataGridView_Column_Adjust(((DataGridView)control), ShowRowHeader);
            }
        }

        private static bool IsUserControl(Control control)
        {
            if (control.Parent == null)
            {
                return false;
            }

            if (control.Parent.ProductName == "Prototypes" || control.Parent.ProductName == "OutlandAreaServer")
            {
                return true;
            }

            return false;
        }

        public void _resize() //Set the resize
        {
            var formRatioWidth = (double)Form.ClientSize.Width / (double)FormSize.Width; //ratio could be greater or less than 1
            var formRatioHeight = (double)Form.ClientSize.Height / (double)FormSize.Height; // this one too
            var controls = _get_all_controls(Form); //reenumerate the control collection
            var pos = -1;//do not change this value unless you know what you are doing
            
            foreach (var control in controls)
            {
                try
                {
                    var font = control.Font;

                    // do some math calc
                    pos += 1;//increment by 1;
                    var controlSize = new Size((int)(_controlStorage[pos].Width * formRatioWidth),
                        (int)(_controlStorage[pos].Height * formRatioHeight)); //use for sizing

                    if (IsUserControl(control) == false)
                    {
                        var controlPosition = new Point((int) (_controlStorage[pos].X * formRatioWidth),
                            (int) (_controlStorage[pos].Y * formRatioHeight)); //use for location

                        //set bounds
                        control.Bounds = new Rectangle(controlPosition, controlSize); //Put together
                    }
  

                    if (control.GetType() == typeof(DataGridView))
                        DataGridView_Column_Adjust(((DataGridView)control), ShowRowHeader);

                    //Font AutoSize
                    control.Font = new Font(font.FontFamily,
                        (float)(((Convert.ToDouble(FontSize) * formRatioWidth) / 2) +
                                ((Convert.ToDouble(FontSize) * formRatioHeight) / 2)), font.Style);
                }
                catch (Exception e)
                {
                    

                }

                

            }
        }

        private static void DataGridView_Column_Adjust(DataGridView dgv, bool _showRowHeader) //if you have Datagridview 
        {
            var intRowHeader = 0;
            const int hScrollBarWidth = 5;
            if (_showRowHeader)
                intRowHeader = dgv.RowHeadersWidth;
            else
                dgv.RowHeadersVisible = false;

            for (var i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Dock == DockStyle.Fill) //in case the datagridview is docked
                    dgv.Columns[i].Width = ((dgv.Width - intRowHeader) / dgv.ColumnCount);
                else
                    dgv.Columns[i].Width = ((dgv.Width - intRowHeader - hScrollBarWidth) / dgv.ColumnCount);
            }
        }




        private static IEnumerable<Control> _get_all_controls(Control c)
        {
            return c.Controls.Cast<Control>().SelectMany(_get_all_controls).Concat(c.Controls.Cast<Control>()).Where(control =>
                control.Name != string.Empty);
        }
    }
}
