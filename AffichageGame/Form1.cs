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
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;



            Map map = new Map();
            map.GetMapInit(di + "/sokoban-maps-60-plain.txt", 3);

            if (affichagegrph == null)
            {
                affichagegrph = new AffichageGraphique(map);
                affichagegrph.MdiParent = this;
                affichagegrph.Show();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
