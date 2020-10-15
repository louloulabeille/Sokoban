using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ClientServeur;
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
            //IAfficher afficher = ;
            Application.Run(new AffichageGraphique(obje.GetMapInit(di + "\\" + path, 2)));


        }

        //Serveur s = new Serveur();
    }
    
   
    
}
