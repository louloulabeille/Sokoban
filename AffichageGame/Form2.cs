﻿using Sokoban;
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
            this.panel1.Controls.Clear();
            Map map = new Map();
            panel1.BackColor = Color.White;
            string path = @"C:\Users\Bleik\Desktop\Sokoban\Sokoban-master(1)\Sokoban-master\sokoban-maps-60-plain.txt";
            map.GetMapInit(path, int.Parse(listBox1.SelectedItem.ToString()));
            int colonne = map.Colonne(path, int.Parse(listBox1.SelectedItem.ToString()));
            int ligne = map.Ligne(path, int.Parse(listBox1.SelectedItem.ToString()));
            if (colonne >= ligne) { ligne = colonne; }
            else { colonne = ligne; }
            foreach (var item in map)
            {
                PictureBox bouton = new PictureBox();
                bouton.Size = new System.Drawing.Size(panel1.Width / colonne, panel1.Height / ligne);
                char character = char.Parse(item.Content.ToString());
                switch (character)
                {
                    case 'X':
                        bouton.Location = new Point(item.Y * panel1.Width / colonne, item.X * panel1.Width / ligne);
                        bouton.BackColor = Color.Red;
                        break;
                    case '@':
                        bouton.Location = new Point(item.Y * panel1.Width / colonne, item.X * panel1.Width / ligne);
                        bouton.BackColor = Color.Green;
                        break;
                    case '.':
                        bouton.Location = new Point(item.Y * panel1.Width / colonne, item.X * panel1.Width / ligne);
                        bouton.BackColor = Color.Black;
                        break;
                    case '*':
                        bouton.Location = new Point(item.Y * panel1.Width / colonne, item.X * panel1.Width / ligne);
                        bouton.BackColor = Color.Yellow;

                        break;
                }
                panel1.Controls.Add(bouton);
            }
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
