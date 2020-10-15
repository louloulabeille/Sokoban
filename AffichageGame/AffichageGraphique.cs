using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Sokoban;
using System.Windows.Forms;
using Utilitaires;

namespace AffichageGame
{
    public partial class AffichageGraphique : Form, IAfficher
    {
        public AffichageGraphique(Map map)
        {
           InitializeComponent();
            this.Afficher(map);
            wait(map);
        }

        public void wait(Map map)
        {
            while (true)
            {
                
                //map = Map.OnMove(map);
            }
        }

        public void Afficher(Map map)
        {
            this.Controls.Clear();
            foreach (var item in map)
            {
                PictureBox bouton = new PictureBox();
                bouton.Size = new Size(50 , 50);
                if (item is Personnage)
                {
                    bouton.Name = "Name_Personnage";
                    bouton.BackColor = Color.Blue;
                }
                else if (item is Caisse) { bouton.BackColor = Color.Green; }
                else if (item is Mur) { bouton.BackColor = Color.Black; }
                else if (item is Emplacement) { bouton.BackColor = Color.HotPink; }
                //else if (item is Elements) { bouton.BackColor = Color.Chartreuse; }
                bouton.Location = new Point(item.Y * 50, item.X *50);
                Controls.Add(bouton);
            }
        }

        private void AffichageGraphique_Load(object sender, EventArgs e)
        {

        }
    }
}
