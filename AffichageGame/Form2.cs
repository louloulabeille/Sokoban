using Sokoban;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AffichageGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void test()
        {
        //    int ligne = 29;
        //    int colonne = 29;
            Map map = new Map();
            string path = @"D:/ProjetSokoban/sokoban-maps-60-plain.txt";
            map.GetMapInit(path, 2);

            //for (int j = 0; j < ligne; j++)
            //{
            //    for (int i = 0; i < colonne; i++)
            //    {
            //        Panel bouton = new Panel();
            //        bouton.Size = new System.Drawing.Size(panel1.Width / colonne, panel1.Height / ligne);
            //        bouton.BackColor = Color.White;
            //        if (j % 2 == 0)
            //        {
            //            bouton.Location = new Point(i * panel1.Width / colonne * 2, j * panel1.Width / ligne);
            //            bouton.BackColor = Color.Black;
            //            panel1.Controls.Add(bouton);
            //        }
            //        else
            //        {
            //            bouton.Location = new Point(panel1.Width / colonne + i * panel1.Width / colonne * 2, j * panel1.Width / ligne);
            //            bouton.BackColor = Color.Black;
            //            panel1.Controls.Add(bouton);
            //        }

            //    }
            //}

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
            
        }
    }
}
