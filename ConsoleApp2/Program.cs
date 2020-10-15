using System;
using System.Collections.Generic;
using System.Data;
using ClientServeur;
using Sokoban;
using Utilitaires;

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
                        x[pos] = x[pos - 1];
                        x[pos - 1] = p;
                        x[pos - 1].Y++;
                        p.Y--;
                    }
                    else if (x[pos - 1] is Caisse c)
                    {
                        if(IsMoveOk(x[pos - 2]) == "Elements")
                        {
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
                        x[pos - x.Taille].X++;
                        x[pos] = x[pos - x.Taille];
                        p.X--;
                        x[pos - x.Taille] = p;
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
                            Elements news = new Elements(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(e))] = c;
                            x[x.FindIndex(ind => ind.Equals(p)) + 1] = news ;
                            c.X--;
                            p.X--;
                        }                         
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (IsMoveOk(x[pos + 1]) == "Elements")
                    {
                        x[pos] = x[pos + 1];
                        x[pos + 1] = p;
                        x[pos + 1].Y--;
                        p.Y = p.Y++;
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
                        else if (IsMoveOk(x[pos+2]) == "Emplacement")
                        {
                            c.OnEmplacement = true;

                            x[pos] = new Elements(x[pos + 2].X, x[pos + 2].Y);
                            x.Remove(x[pos + 2]);
                            x[pos + 1].Y++;
                            x[pos + 1] = p;
                            x[pos + 1].Y--;
                            p.Y++;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (IsMoveOk(x[pos + x.Taille]) == "Elements")
                    {
                        x[pos + x.Taille].X--;
                        x[pos] = x[pos + x.Taille];
                        p.X++;
                        x[pos + x.Taille] = p;
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
                        else if (IsMoveOk(x[pos + (x.Taille * 2)]) == "Emplacement")
                        {
                            c.OnEmplacement = true;
                            x[pos] = new Elements(x[pos + (x.Taille * 2)].X, x[pos + (x.Taille * 2)].Y);
                            x[pos + (x.Taille * 2)] = null;
                            x[pos] = x[pos + (x.Taille * 2)];
                            x[pos + x.Taille].X++;
                            x[pos + (x.Taille * 2)] = x[pos + x.Taille];
                            p.X++;
                            x[pos + x.Taille] = p;
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
            Map test = new Map();
            IAfficher afficher = new AffichageConsole();
            ILoad obj = new LoadFromTxt();
            Map obje = new Map();
            obje.GetMapInit(@"C:\Users\Utilisateur\Desktop\sokoban-maps-master\maps\sokoban-maps-60-plain.txt", 1);
            while (true)
            {
                Console.Clear();
                afficher.Afficher(obje);
                obje = OnMove(obje);                
            }
        }

        //Serveur s = new Serveur();
    }
    
   
    
}
