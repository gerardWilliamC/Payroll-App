using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SetDefaultZeros(this); // This runs as soon as the payslip is created
        }

        private void SetDefaultZeros(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is TextBox && string.IsNullOrEmpty(ctrl.Text))
                {
                    ctrl.Text = "0.00";
                }
                if (ctrl.Controls.Count > 0)
                {
                    SetDefaultZeros(ctrl);
                }
            }
        }

    }
}
