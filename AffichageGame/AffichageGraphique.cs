﻿using System;
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
        public static Map map;
        public AffichageGraphique(Map map)
        {
           InitializeComponent();
            AffichageGraphique.map = map;
           this.Afficher(map);
            
        }
 

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            AffichageGraphique.map = Map.OnMove(AffichageGraphique.map, char.Parse(e.KeyChar.ToString()));
            this.Afficher(AffichageGraphique.map);
        }
        public void Afficher(Map map)
        {
            this.Controls.Clear();
            int c = 0;
            for (int i = 0; i < AffichageGraphique.map.Count; i++)
            {
                int x = i - (AffichageGraphique.map.Taille * c);

                if ((i+1) % AffichageGraphique.map.Taille == 0)
                {
                    c++;
                }
                
                PictureBox bouton = new PictureBox();
                bouton.Size = new Size(50, 50);
                if (AffichageGraphique.map[i] is Personnage)
                {
                    bouton.Name = "Name_Personnage";
                    bouton.BackColor = Color.Blue;
                }
                
                    
                else if (AffichageGraphique.map[i] is Caisse) { bouton.BackColor = Color.Green; }
                else if (AffichageGraphique.map[i] is Mur) { bouton.BackColor = Color.Black; }
                else if (AffichageGraphique.map[i] is Emplacement) { bouton.BackColor = Color.HotPink; }
                else { bouton.BackColor = Color.SaddleBrown; }
                bouton.Location = new Point( x* 50,  c*50);
                bouton.BringToFront();
                bouton.BringToFront();
                bouton.BringToFront();
                Controls.Add(bouton);
            }
        }

        private void AffichageGraphique_Load(object sender, EventArgs e)
        {

        }
    }
}
