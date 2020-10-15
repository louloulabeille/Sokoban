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
    public partial class Form2 : Form, IAfficher
    {
        public Form2()
        {
            InitializeComponent();
            btnSelect.Enabled = false;
            Map test = new Map();
            IAfficher afficher = new Form2();
            ILoad obj = new LoadFromTxt();
            Map obje = new Map();
           // obje.GetMapInit(di + "\\" + "sokoban-maps-60-plain.txt", 2);
            while (true)
            {
                afficher.Afficher(obje);
                obje = Map.OnMove(obje);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public Map LoadMap()
        {
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;

            Map map = new Map();
            map.GetMapInit(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            return map;
        }

        public int Taille(Map map)
        {
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;

            int colonne = map.Colonne(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            int ligne = map.Ligne(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            int taille;
            if (colonne >= ligne) { taille = colonne; }
            else { taille = ligne; }
            return taille;
        }

        public void Afficher(Map map)
        {
            this.panel1.Controls.Clear();
            int taille = Taille(map);

            foreach (var item in map)
            {
                PictureBox bouton = new PictureBox();
                bouton.Size = new System.Drawing.Size(panel1.Width / taille, panel1.Height / taille);
                if (item is Personnage) 
                {
                    bouton.Name = "Name_Personnage";
                    bouton.BackColor = Color.Blue;
                }
                else if (item is Caisse) { bouton.BackColor = Color.Green; }
                else if (item is Mur) { bouton.BackColor = Color.Black; }
                else if (item is Emplacement) { bouton.BackColor = Color.HotPink; }
                //else if (item is Elements) { bouton.BackColor = Color.Chartreuse; }
                bouton.Location = new Point(item.Y * panel1.Width / taille, item.X * panel1.Width / taille);
                panel1.Controls.Add(bouton);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Map x = LoadMap();
            Afficher(x);
        }

        private PictureBox getPictureBoxByName(string name)
        {
            foreach (object p in this.Controls)
            {
                if (p.GetType() == typeof(PictureBox))
                    if (((PictureBox)p).Name == name)
                        return (PictureBox)p;
            }
            return new PictureBox();
        }

        private void btnHaut_Click(object sender, EventArgs e)
        {
            
        }

    }
}
