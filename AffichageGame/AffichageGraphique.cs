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
           AffichageGraphique.mapActuel = map;
           this.Afficher(map);
        }
 

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Map x = new Map();
            x = mapActuel.Clone() as Map;
            mapActuel = Map.OnMove(mapActuel, char.Parse(e.KeyChar.ToString()));
            this.Afficher2(x);
        }
        public void Afficher(Map map)
        {
            //Controls.Remove(this.Controls.Find("p", false)[0]);
            int c = 0;
            for (int i = 0; i < map.Count; i++)
            {             
                if (i % map.Taille == 0 && i!=0) c++;
                int x = i - (mapActuel.Taille * c);
                //Controls.Remove(Controls["p"]);
                PictureBox bouton = new PictureBox();
                bouton.Size = new Size(50, 50);
                if (map[i] is Personnage)
                {
                    bouton.Name = "p";
                    bouton.BackColor = Color.Blue;
                }            
                    
                else if (map[i] is Caisse) { bouton.BackColor = Color.Green; }
                else if (map[i] is Mur) { bouton.BackColor = Color.Black; }
                else if (map[i] is Emplacement) { bouton.BackColor = Color.HotPink; }
                else { bouton.BackColor = Color.SaddleBrown; }
                bouton.Location = new Point( x* 50, c*50);
                Controls.Add(bouton);
            }
        }

        public void Afficher2(Map map)
        {
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
                        bouton.BackColor = Color.Blue;
                    }
                    else if (mapActuel[i] is Caisse) { bouton.BackColor = Color.Green; }
                    else if (mapActuel[i] is Emplacement) { bouton.BackColor = Color.HotPink; }
                    else { bouton.BackColor = Color.SaddleBrown; }
                    bouton.Location = new Point(x * 50, c * 50);
                    Controls.Add(bouton);
                }
            }
        }
        private void AffichageGraphique_Load(object sender, EventArgs e)
        {

        }
    }
}
