﻿using System;
using System.Data;
using Sokoban;
using Utilitaires;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Map test = new Map();
            IAfficher afficher = new AffichageConsole();
            ILoad obj = new LoadFromTxt();
            afficher.Afficher(obj.Load(@"C:\Users\Utilisateur\Desktop\sokoban-maps-master\maps\sokoban-maps-60-plain.txt", 5));
        }
    }
}
