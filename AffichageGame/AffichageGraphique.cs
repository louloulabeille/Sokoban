using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Sokoban;
using System.Windows.Forms;
using Utilitaires;
using System.IO;

namespace AffichageGame
{
    
    public partial class AffichageGraphique : Form, IAfficher
    {
        public static Map mapActuel;
        public AffichageGraphique(Map map)
        {
           InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            AffichageGraphique.mapActuel = map;
           this.Afficher(map);
        }
 

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Map x = new Map();
            x = mapActuel.Clone() as Map;
            mapActuel = Map.OnMove(mapActuel, char.Parse(e.KeyChar.ToString()));
            this.Afficher2(x);
            if(Map.Win(x)) MessageBox.Show("Win");
        }
        public void Afficher(Map map)
        {
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;

            int c = 0;
            for (int i = 0; i < map.Count; i++)
            {             
                if (i % map.Taille == 0 && i!=0) c++;
                int x = i - (mapActuel.Taille * c);
                PictureBox bouton = new PictureBox();
                bouton.Size = new Size(50, 50);
                if (map[i] is Personnage)
                {
                    bouton.Name = "p";
                    Image image = Image.FromFile(di + "/personnage.png");
                    image = new Bitmap(image, 50, 50);
                    bouton.Image = image;
                }            

                else if (map[i] is Caisse) {
                    Image image = Image.FromFile(di + "/trophy.png");
                    image = new Bitmap(image, 50, 50);
                    bouton.Image = image;
                }
                else if (map[i] is Mur) {
                    Image image = Image.FromFile(di + "/cactus.png");
                    image = new Bitmap(image, 50, 50);
                    bouton.Image = image;
                }
                else if (map[i] is Emplacement) {
                    Image image = Image.FromFile(di + "/terre.png");
                    image = new Bitmap(image, 50, 50);
                    bouton.Image = image;
                }
                //else { bouton.BackColor = Color.SaddleBrown; }
                bouton.Location = new Point( x* 50, c*50);
                Controls.Add(bouton);
            }
        }

        public void Afficher2(Map map)
        {
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;

            int c = 0;
            for (int i = 0; i < map.Count; i++)
            {
                if (i % map.Taille == 0 && i != 0) c++;
                int x = i - (map.Taille * c);

                if (map[i] != mapActuel[i])
                {
                    Controls.Remove(GetChildAtPoint(new Point(x * 50, c * 50)));
                    PictureBox bouton = new PictureBox();
                    bouton.Size = new Size(50, 50);
                    if (mapActuel[i] is Personnage)
                    {
                        bouton.Name = "p";
                        Image image = Image.FromFile(di + "/personnage.png");
                        image = new Bitmap(image, 50, 50);
                        bouton.Image = image;
                    }
                    else if (mapActuel[i] is Caisse)
                    {
                        Image image = Image.FromFile(di + "/trophy.png");
                        image = new Bitmap(image, 50, 50);
                        bouton.Image = image;
                    }
                    else if (mapActuel[i] is Emplacement) {
                        Image image = Image.FromFile(di + "/terre.png");
                        image = new Bitmap(image, 50, 50);
                        bouton.Image = image;
                    }
                    //else { bouton.BackColor = Color.SaddleBrown; }
                    bouton.Location = new Point(x * 50, c * 50);
                    Controls.Add(bouton);
                }
            }
        }

        public int Taille(Map map)
        {
            string path = Resource.File;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;

            //int colonne = map.Colonne(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));
            //int ligne = map.Ligne(di + "\\" + path, int.Parse(listBox1.SelectedItem.ToString()));

            int colonne = map.Colonne(di + "\\" + path, 2);
            int ligne = map.Ligne(di + "\\" + path, 2);


            int taille;
            if (colonne >= ligne) { taille = colonne; }
            else { taille = ligne; }
            return taille;
        }

        private void AffichageGraphique_Load(object sender, EventArgs e)
        {

        }
    }
}
