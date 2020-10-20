using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sokoban;
using Utilitaires;

namespace AffichageGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        Form2 form2;
        AffichageGraphique affichagegrph;
       

        private void click_Solo(object sender, EventArgs e)
        {
            MessageBox.Show(AffichageGraphique.lv.ToString());
        }


        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void click_Reset(object sender, EventArgs e)
        {
            MessageBox.Show("ddsds");
        }
    }
}
