using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
//using ClientServeur;
using Sokoban;
using Utilitaires;

using AffichageGame;
using System.Windows.Forms;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Ressource.Files;
            string cd = Directory.GetCurrentDirectory();
            DirectoryInfo di = new DirectoryInfo(cd);
            di = di.Parent.Parent.Parent.Parent;
            
            ILoad obj = new LoadFromTxt();
            Map obje = new Map();
            obje = obje.GetMapInit(di + "\\" + path, 60);
            
            Application.Run(new AffichageGraphique(obje));
            /*IAfficher afficher = new AffichageConsole();
            while (true)
            {
                afficher.Afficher(obje);
                obje = Map.OnMove(obje);
            }*/


        }

        //Serveur s = new Serveur();
    }
    
   
    
}
