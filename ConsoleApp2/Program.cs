using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ClientServeur;
using Sokoban;
using Utilitaires;
using static System.Net.Mime.MediaTypeNames;

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
            Map test = new Map();
            IAfficher afficher = new AffichageConsole();
            ILoad obj = new LoadFromTxt();
            Map obje = new Map();
            obje.GetMapInit(di+"\\"+path, 1);
            while (true)
            {         
                afficher.Afficher(obje);
                obje = Map.OnMove(obje);                
            }
        }

        //Serveur s = new Serveur();
    }
    
   
    
}
