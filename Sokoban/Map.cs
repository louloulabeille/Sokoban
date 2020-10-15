using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utilitaires;

namespace Sokoban
{
    public class Map : List<Elements>, ILoad
    {
        //public delegate void deleg();
        //public event deleg evnt;
        private int _taille;

        public int Taille { get => _taille; set => _taille = value; }

        public List<List<char>> Load(string path, int level)
        {
            GetTailleY(path, level);
            ILoad obj = new LoadFromTxt();
            return obj.Load(path, level);
        }
        private void GetTailleY(string path, int level)
        {
            string text = File.ReadAllText(path);
            string toSearch = "Maze: " + level.ToString();
            int postmp = text.IndexOf(toSearch, 0);
            int pos2 = text.IndexOf("Size Y: ", postmp);
            int pos1 = text.IndexOf("Size X: ", postmp) + 8;
            Console.WriteLine(text.Substring(pos1, pos2 - pos1));
            Taille = Int32.Parse(text.Substring(pos1, pos2 - pos1));
        }
        public int Colonne(string path, int level)
        {
            string text = File.ReadAllText(path);
            string toSearch = "Maze: " + level.ToString();
            int postmp = text.IndexOf(toSearch, 0);
            int pos2 = text.IndexOf("Size Y: ", postmp);
            int pos1 = text.IndexOf("Size X: ", postmp) + 8;
            Console.WriteLine(text.Substring(pos1, pos2 - pos1));
            Taille = Int32.Parse(text.Substring(pos1, pos2 - pos1));
            return Taille;
        }

        public int Ligne(string path, int level)
        {
            string text = File.ReadAllText(path);
            string toSearch = "Maze: " + level.ToString();
            int postmp = text.IndexOf(toSearch, 0);
            int pos2 = text.IndexOf("End: ", postmp);
            int pos1 = text.IndexOf("Size Y: ", postmp) + 8;
            Console.WriteLine(text.Substring(pos1, pos2 - pos1));
            Taille = Int32.Parse(text.Substring(pos1, pos2 - pos1));
            return Taille;
        }

        public Map GetMapInit(string path, int level)
        {
            List<List<char>> listFull = new List<List<char>>(Load(path, level));
            try
            {
                for (int i = 0; i < listFull.Count; i++)
                {
                    for (int j = 0; j < listFull[i].Count; j++)
                    {
                        switch (listFull[i][j])
                        {
                            case ' ':
                                this.Add(new Elements(i, j));
                                break;
                            case 'X':
                                this.Add(new Mur(i, j));
                                break;
                            case '.':
                                this.Add(new Emplacement(i, j));
                                break;
                            case '*':
                                this.Add(new Caisse(i, j));
                                break;
                            case '@':
                                Personnage p = new Personnage(i, j);                              
                                this.Add(p);
                                break;
                            case '\r':
                                break;
                            default:
                                throw new ApplicationException("Erreur dans le fichier map. Charactère '" + listFull[i][j] + "' non reconnu");
                        }
                    }
                }
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException(e.Message);
            }
            return this;
        }

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
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos] = news;
                                x[pos - 1] = p;
                                x[pos - 2] = c;                               
                            }
                            else
                            {
                                x[pos - 2].Y += 2;
                                x[pos] = x[pos - 2];
                                x[pos - 1].Y--;
                                x[pos - 2] = x[pos - 1];
                                x[pos - 1] = p;
                                x[pos - 1].Y++;
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                                c.OnEmplacement = false;
                            }
                            p.Y--;
                            c.Y--;


                        }
                        else if (x[pos - 2] is Emplacement e)
                        {                            
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;                             
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos] = news;
                                x[pos - 1] = p;
                                x[pos - 2] = c;
                            }
                            else
                            {
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[x.FindIndex(ind => ind.Equals(e))] = c;
                                x[x.FindIndex(ind => ind.Equals(p)) + 1] = new Elements(e.X, e.Y + 2); ;                             
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                            }
                            c.OnEmplacement = true;
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
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos] = news;
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[pos - (2*x.Taille)] = c;
                                p.X--;
                            }
                            else
                            {
                                x[pos - (x.Taille * 2)].X += 2;
                                x[pos] = x[pos - (x.Taille * 2)];
                                x[pos - x.Taille].X--;
                                x[pos - (x.Taille * 2)] = x[pos - x.Taille];
                                p.X--;
                                x[pos - x.Taille] = p;
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                                c.OnEmplacement = false;
                            }

                        }
                        else if (x[pos - (x.Taille * 2)] is Emplacement e)
                        {
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos] = news;
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[x.FindIndex(ind => ind.Equals(e))] = c;
                                p.X--;
                                c.X--;
                            }
                            else
                            {                                                
                                x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[x.FindIndex(ind => ind.Equals(e))] = c;
                                c.X--;
                                p.X--;
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                            }
                            c.OnEmplacement = true;
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
                        }
                        else
                        {
                            x[pos] = x[pos + 1];
                            x[pos + 1] = p;
                            x[pos + 1].Y--;
                            
                        }
                        p.Y++;                    
                    }
                    else if (x[pos + 1] is Emplacement)
                    {
                        if (p.OnEmplacement)
                        {
                            Emplacement news = new Emplacement(p.X, p.Y);
                            x[x.FindIndex(ind => ind.Equals(p))] = news;
                            x[pos] = news;
                            x[pos + 1] = p;
                        }
                        else
                        {
                            p.OnEmplacement = true;
                            x[pos] = new Elements(p.X, p.Y);
                            x[pos + 1] = p;                                              
                        }
                        p.Y++;
                    }
                    else if (x[pos +1] is Caisse c)
                    {
                        if (IsMoveOk(x[pos + 2]) == "Elements")
                        {
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos + 1] = p;
                                x[pos + 2] = c;                               
                            }
                            else
                            {
                                x[pos + 2].Y -= 2;
                                x[pos] = x[pos + 2];
                                x[pos + 2] = x[pos + 1];
                                x[pos + 1] = p;
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                                c.OnEmplacement = false;
                            }
                            p.Y++;
                            c.Y++;
                        }
                        else if (x[pos+2] is Emplacement e)
                        {
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos] = news;
                                x[pos + 1] = p;
                                x[pos + 2] = c;                              
                            }
                            else
                            {
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[x.FindIndex(ind => ind.Equals(e))] = c;
                                x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y); ;
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                            }
                            c.OnEmplacement = true;
                            p.Y++;
                            c.Y++;
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
                        }
                        else
                        {
                            p.OnEmplacement = true;
                            x[pos] = new Elements(p.X, p.Y);
                            x[pos + x.Taille] = p;
                        }
                        p.X++;
                    }
                    else if (x[pos + x.Taille] is Caisse c) 
                    {
                        if (IsMoveOk(x[pos + (x.Taille * 2)]) == "Elements")
                        {
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                Emplacement news = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(p))] = news;
                                x[pos] = news;
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[pos + (2 * x.Taille)] = c;
                            }
                            else
                            {
                                x[pos + (x.Taille * 2)].X -= 2;
                                x[pos] = x[pos + (x.Taille * 2)];
                                x[pos + (x.Taille * 2)] = x[pos + x.Taille];
                                x[pos + x.Taille] = p;
                            }
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                                c.OnEmplacement = false;
                            }
                            p.X++;
                            c.X++;
                        }
                        else if (x[pos + (x.Taille * 2)] is Emplacement e)
                        {
                            if (p.OnEmplacement)
                            {
                                p.OnEmplacement = false;
                                x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[x.FindIndex(ind => ind.Equals(e))] = c;
                            }
                            else {
                                x[x.FindIndex(ind => ind.Equals(c))] = p;
                                x[x.FindIndex(ind => ind.Equals(e))] = c;
                                x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y);
                            }                          
                            if (c.OnEmplacement)
                            {
                                p.OnEmplacement = true;
                            }
                            c.OnEmplacement = true;
                            p.X++;
                            c.X++;
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

        
    }
}
