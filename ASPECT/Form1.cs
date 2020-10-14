using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 form2;
        private void jeuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form2 == null)
            {
                form2 = new Form2();
                form2.MdiParent= this;
                form2.WindowState = FormWindowState.Maximized;
                form2.Show();
            }
            else
            {
                form2.Activate();
            }
        }
    }
}
