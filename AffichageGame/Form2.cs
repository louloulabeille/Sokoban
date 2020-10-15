using Sokoban;
using Utilitaires;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using System.IO;

namespace AffichageGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            btnSelect.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void AffichageMap()
        {
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;

            this.panel1.Controls.Clear();
            Map map = new Map();
            map.GetMapInit(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            int colonne = map.Colonne(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            int ligne = map.Ligne(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            if (colonne >= ligne) { ligne = colonne; }
            else { colonne = ligne; }
            foreach (var item in map)
            {
                PictureBox bouton = new PictureBox();
                bouton.Size = new System.Drawing.Size(panel1.Width / colonne, panel1.Height / ligne);
                char character = char.Parse(item.Content.ToString());

                if (item is Personnage) 
                {
                    bouton.BackColor = Color.Blue;
                }

                else if (item is Caisse) { bouton.BackColor = Color.Green; }
                else if (item is Mur) { bouton.BackColor = Color.Black; }
                else if (item is Emplacement) { bouton.BackColor = Color.HotPink; }
                else if (item is Elements) { bouton.BackColor = Color.Chartreuse; }
                bouton.Location = new Point(item.Y * panel1.Width / colonne, item.X * panel1.Width / ligne);
                panel1.Controls.Add(bouton);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            AffichageMap();
        }

        
    }
}
