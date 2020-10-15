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
        public static Map OnMove(Map map)
        {
            Personnage d = new Personnage();
            foreach (Elements e in map)
            {
                if(e is Personnage)
                {
                    d = e as Personnage;
                }              
            }
            map = returnMove(map, d);
            return map;
        }

        public static Map returnMove(Map x, Personnage p)
        {
            int pos = x.IndexOf(p);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    
                    if (IsMoveOk(x[pos - 1]) == "Elements")
                    {
                        if (p.OnEmplacement)
                        {
                            p.OnEmplacement = false;
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos - 1] = p;
                            p.Y--;
                        }
                        else
                        {
                            x[pos] = x[pos - 1];
                            x[pos - 1] = p;
                            x[pos - 1].Y++;
                            p.Y--;
                        }
                    }
                    else if(x[pos - 1] is Emplacement)
                    {
                        if (p.OnEmplacement)
                        {
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos - 1] = p;
                            p.Y--;
                        }
                        else
                        {
                            p.OnEmplacement = true;
                            x[pos] = new Elements(p.X, p.Y);
                            x[pos - 1] = p;
                            p.Y--;
                        }
                    }
                    else if (x[pos - 1] is Caisse c)
                    {
                        
                        if (IsMoveOk(x[pos - 2]) == "Elements")
                        {
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                                c.OnEmplacement = false;
                            }
                            x[pos - 2].Y+=2;
                            x[pos] = x[pos - 2];
                            x[pos - 1].Y--;
                            x[pos - 2] = x[pos - 1];                           
                            x[pos - 1] = p;
                            x[pos - 1].Y++;
                            p.Y--;
                        }
                        else if (x[pos - 2] is Emplacement e)
                        {
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                            }
                            c.OnEmplacement = true;
                            x[x.FindIndex(ind => ind.Equals(c))] = p;
                            x[x.FindIndex(ind => ind.Equals(e))] = c;                                        
                            x[x.FindIndex(ind => ind.Equals(p))+1] = new Elements(e.X, e.Y + 2); ;
                            c.Y--;
                            p.Y--;
                        }                 
                    }
                    break;
                    
                case ConsoleKey.UpArrow:
                    if (IsMoveOk(x[pos - x.Taille]) == "Elements")
                    {
                        if (p.OnEmplacement)
                        {
                            p.OnEmplacement = false;
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos - x.Taille] = p;
                            p.X--;
                        }
                        else
                        {
                            x[pos - x.Taille].X++;
                            x[pos] = x[pos - x.Taille];
                            p.X--;
                            x[pos - x.Taille] = p;
                        }
                    }
                    else if (x[pos - x.Taille] is Emplacement)
                    {
                        if (p.OnEmplacement)
                        {
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos - x.Taille] = p;
                            p.X--;
                        }
                        else
                        {
                            p.OnEmplacement = true;
                            x[pos] = new Elements(p.X, p.Y);
                            x[pos - x.Taille] = p;
                            p.X--;
                        }
                    }
                    else if (x[pos - x.Taille] is Caisse c)
                    {
                        if (IsMoveOk(x[pos - (x.Taille * 2)]) == "Elements")
                        {         
                            x[pos - (x.Taille * 2)].X+=2;
                            x[pos] = x[pos - (x.Taille * 2)];
                            x[pos - x.Taille].X--;
                            x[pos - (x.Taille * 2)] = x[pos - x.Taille];
                            p.X--;
                            x[pos - x.Taille] = p;                                                   
                        }
                        else if (x[pos - (x.Taille * 2)] is Emplacement e)
                        {
                            c.OnEmplacement = true;
                            x[x.FindIndex(ind => ind.Equals(c))] = p;                         
                            x[x.FindIndex(ind => ind.Equals(e))] = c;
                            x[x.FindIndex(ind => ind.Equals(p)) + x.Taille] = new Elements(p.X, p.Y); ;
                            c.X--;
                            p.X--;
                        }                         
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (IsMoveOk(x[pos + 1]) == "Elements")
                    {
                        if (p.OnEmplacement)
                        {
                            p.OnEmplacement = false;
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos + 1] = p;
                            p.Y++;
                        }
                        else
                        {
                            x[pos] = x[pos + 1];
                            x[pos + 1] = p;
                            x[pos + 1].Y--;
                            p.Y++;
                        }
                    }
                    else if (x[pos + 1] is Emplacement)
                    {
                        if (p.OnEmplacement)
                        {
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos + 1] = p;
                            p.Y++;
                        }
                        else
                        {
                            p.OnEmplacement = true;
                            x[pos] = new Elements(p.X, p.Y);
                            x[pos + 1] = p;
                            p.Y++;
                        }
                    }
                    else if (x[pos +1] is Caisse c)
                    {
                        if (IsMoveOk(x[pos + 2]) == "Elements")
                        {
                            x[pos + 2].Y -= 2;
                            x[pos] = x[pos+ 2];
                            x[pos + 1].Y++;
                            x[pos + 2] = x[pos + 1];
                            x[pos + 1] = p;
                            x[pos + 1].Y--;
                            p.Y++;
                        }
                        else if (x[pos+2] is Emplacement e)
                        {
                            c.OnEmplacement = true;
                            x[x.FindIndex(ind => ind.Equals(c))] = p;
                            x[x.FindIndex(ind => ind.Equals(e))] = c;
                            x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y); ;
                            c.Y++;
                            p.Y++;
                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (IsMoveOk(x[pos + x.Taille]) == "Elements")
                    {
                        if (p.OnEmplacement)
                        {
                            p.OnEmplacement = false;
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos + x.Taille] = p;
                            p.X++;
                        }
                        else
                        {
                            x[pos + x.Taille].X--;
                            x[pos] = x[pos + x.Taille];
                            p.X++;
                            x[pos + x.Taille] = p;
                        }
                    }
                    else if (x[pos + x.Taille] is Emplacement)
                    {
                        if (p.OnEmplacement)
                        {
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos + x.Taille] = p;
                            p.X++;
                        }
                        else
                        {
                            p.OnEmplacement = true;
                            x[pos] = new Elements(p.X, p.Y);
                            x[pos + x.Taille] = p;
                            p.X++;
                        }
                    }
                    else if (x[pos + x.Taille] is Caisse c) 
                    {
                        if (IsMoveOk(x[pos + (x.Taille * 2)]) == "Elements")
                        {
                            x[pos + (x.Taille * 2)].X -= 2;
                            x[pos] = x[pos + (x.Taille * 2)];
                            x[pos + x.Taille].X++;
                            x[pos + (x.Taille * 2)] = x[pos + x.Taille];
                            p.X++;
                            x[pos + x.Taille] = p;
                        }
                        else if (x[pos + (x.Taille * 2)] is Emplacement e)
                        {
                            c.OnEmplacement = true;
                            x[x.FindIndex(ind => ind.Equals(c))] = p;
                            x[x.FindIndex(ind => ind.Equals(e))] = c;
                            x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y); ;
                            c.X++;
                            p.X++;
                        }
                    }
                    break;
            }
            return x;
        }
        public static string IsMoveOk(Elements elem)
        {
            return elem.GetType().Name;
        }
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
                obje = OnMove(obje);                
            }
        }

        //Serveur s = new Serveur();
    }
    
   
    
}
