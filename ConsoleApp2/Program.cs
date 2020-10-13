using System;
using System.Data;
using Sokoban;
using Utilitaires;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Ressource.Files;
            Map test = new Map();
            IAfficher afficher = new AffichageConsole();
            ILoad obj = new LoadFromTxt();
            Map obje = new Map();
            afficher.Afficher(obje.GetMap(path, 5));
        }
    }
}
