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
            Taille = Int32.Parse(text.Substring(pos1, pos2 - pos1));
        }
        public int Colonne(string path, int level)
        {
            string text = File.ReadAllText(path);
            string toSearch = "Maze: " + level.ToString();
            int postmp = text.IndexOf(toSearch, 0);
            int pos2 = text.IndexOf("Size Y: ", postmp);
            int pos1 = text.IndexOf("Size X: ", postmp) + 8;
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

        public static Map OnMove(Map map, char key = '!')
        {
            Personnage personnage = new Personnage();
            foreach (Elements elem in map)
            {
                if(elem is Personnage) personnage = elem as Personnage;            
            }
            return returnMove(map, personnage, key);
        }

        public static Map returnMove(Map x, Personnage p, char key)
        {
            int pos = x.IndexOf(p);
            if (key != '!')
            {
                switch (key)
                {
                    case 'q':
                        x = LeftMove(x, p);
                        break;
                    case 'z':
                        x = UpMove(x, p);
                        break;

                    case 'd':
                        x = RightMove(x, p);
                        break;

                    case 's':
                        DownMove(x, p);
                        break;
                }
            }
            else
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                        x = LeftMove(x, p);
                        break;
                    case ConsoleKey.UpArrow:
                        x = UpMove(x, p);
                        break;

                    case ConsoleKey.RightArrow:
                        x = RightMove(x, p);
                        break;

                    case ConsoleKey.DownArrow:
                        DownMove(x, p);
                        break;
                }
            }
            return x;
        }

        public static Map LeftMove(Map x, Personnage p)
        {
            int pos = x.IndexOf(p);
            if (x[pos - 1].GetType().Name == "Elements")
            {
                if (p.OnEmplacement)
                {
                    p.OnEmplacement = false;
                    Emplacement news = new Emplacement(p.X, p.Y);
                    x[x.FindIndex(ind => ind.Equals(p))] = news;
                }
                else x[x.FindIndex(ind => ind.Equals(p))] = x[pos - 1];

                x[pos - 1] = p;
                if (p.Y > 0) p.Y--;
            }
            else if (x[pos - 1] is Emplacement emp)
            {
                if (p.OnEmplacement) x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);
                else
                {
                    p.OnEmplacement = true;
                    x[pos] = new Elements(p.X, p.Y);
                }
                x[x.FindIndex(ind => ind.Equals(emp))] = p;
                if (p.Y > 0) p.Y--;
            }
            else if (x[pos - 1] is Caisse c)
            {
                if (x[pos - 2].GetType().Name == "Elements")
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        Emplacement news = new Emplacement(p.X, p.Y);
                        x[x.FindIndex(ind => ind.Equals(p))] = news;
                    }
                    else
                    {
                        x[pos - 2].Y += 2;
                        x[x.FindIndex(ind => ind.Equals(p))] = x[pos - 2];  
                    }
                    if (c.OnEmplacement)
                    {
                        p.OnEmplacement = true;
                        c.OnEmplacement = false;
                    }
                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[pos - 2] = c;
                    
                    if (p.Y > 0) p.Y--;
                    if (c.Y > 0) c.Y--;
                }
                else if (x[pos - 2] is Emplacement e)
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        Emplacement news = new Emplacement(p.X, p.Y);
                        x[x.FindIndex(ind => ind.Equals(p))] = news;
                    }
                    else x[x.FindIndex(ind => ind.Equals(p))] = new Elements(e.X, e.Y + 2); ;

                    p.OnEmplacement = c.OnEmplacement;
                    c.OnEmplacement = true;

                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[x.FindIndex(ind => ind.Equals(e))] = c;
                    
                    if (p.Y > 0) p.Y--;
                    if (c.Y > 0) c.Y--;
                }
            }
            return x;
        }
        public static Map UpMove(Map x, Personnage p)
        {
            int pos = x.IndexOf(p);
            if (x[pos - x.Taille].GetType().Name == "Elements")
            {
                if (p.OnEmplacement)
                {
                    p.OnEmplacement = false;
                    Emplacement news = new Emplacement(p.X, p.Y);
                    x[x.FindIndex(ind => ind.Equals(p))] = news;
                }
                else
                {
                    x[pos - x.Taille].X++;
                    x[x.FindIndex(ind => ind.Equals(p))] = x[pos - x.Taille];                
                }
                x[pos - x.Taille] = p;
                if (p.X > 0) p.X--;
            }
            else if (x[pos - x.Taille] is Emplacement)
            {
                if (p.OnEmplacement) x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);        
                else
                {
                    p.OnEmplacement = true;
                    x[pos] = new Elements(p.X, p.Y);
                }

                x[pos - x.Taille] = p;
                if (p.X > 0) p.X--;
            }
            else if (x[pos - x.Taille] is Caisse c)
            {
                if (x[pos - (x.Taille * 2)].GetType().Name == "Elements" )
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        Emplacement news = new Emplacement(p.X, p.Y);
                        x[x.FindIndex(ind => ind.Equals(p))] = news;
                    }
                    else
                    {
                        x[pos - (x.Taille * 2)].X += 2;
                        x[x.FindIndex(ind => ind.Equals(p))] = x[pos - (x.Taille * 2)];
                    }                  
                    if (c.OnEmplacement)
                    {
                        p.OnEmplacement = true;
                        c.OnEmplacement = false;
                    }
                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[x.FindIndex(ind => ind.Equals(x[pos - (x.Taille * 2)]))] = c;
                    
                    if (p.X > 0) p.X--;
                    if (c.X > 0) c.X--;
                }
                else if (x[pos - (x.Taille * 2)] is Emplacement e)
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);
                    }
                    else x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y);   

                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[x.FindIndex(ind => ind.Equals(e))] = c;

                    p.OnEmplacement = c.OnEmplacement;
                    c.OnEmplacement = true;

                    if (p.X > 0) p.X--;
                    if (c.X > 0) c.X--;
                }
            }
            return x;
        }
        public static Map RightMove(Map x, Personnage p)
        {
            int pos = x.IndexOf(p);
            if (x[pos + 1].GetType().Name == "Elements")
            {
                if (p.OnEmplacement)
                {
                    p.OnEmplacement = false;
                    x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);
                }
                else x[x.FindIndex(ind => ind.Equals(p))] = x[pos + 1]; 
                x[pos + 1] = p;
                if (p.Y < x.Taille) p.Y++;
            }
            else if (x[pos + 1] is Emplacement e)
            {
                if (p.OnEmplacement) x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);
                else
                {
                    p.OnEmplacement = true;
                    x[pos] = new Elements(p.X, p.Y);
                }

                x[x.FindIndex(ind => ind.Equals(e))] = p;
                if (p.Y < x.Taille) p.Y++;
            }
            else if (x[pos + 1] is Caisse c)
            {
                if (x[pos + 2].GetType().Name == "Elements")
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        Emplacement news = new Emplacement(p.X, p.Y);
                        x[x.FindIndex(ind => ind.Equals(p))] = news;
                    }
                    else
                    {
                        x[pos + 2].Y -= 2;
                        x[x.FindIndex(ind => ind.Equals(p))] = x[pos + 2];      
                    }                  
                    if (c.OnEmplacement)
                    {
                        p.OnEmplacement = true;
                        c.OnEmplacement = false;
                    }
                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[pos + 2] = c;

                    if (p.Y < x.Taille) p.Y++;
                    if (c.Y < x.Taille) c.Y++;
                }
                else if (x[pos + 2] is Emplacement emp)
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);                       
                    }
                    else x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y);
                    
                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[x.FindIndex(ind => ind.Equals(emp))] = c;

                    p.OnEmplacement = c.OnEmplacement;
                    c.OnEmplacement = true;

                    if (p.Y < x.Taille) p.Y++;
                    if (c.Y < x.Taille) c.Y++;
                }
            }
            return x;
        }
        public static Map DownMove(Map x, Personnage p)
        {
            int pos = x.IndexOf(p);
            if (x[pos + x.Taille].GetType().Name == "Elements")
            {
                if (p.OnEmplacement)
                {
                    p.OnEmplacement = false;
                    Emplacement news = new Emplacement(p.X, p.Y);
                    x[x.FindIndex(ind => ind.Equals(p))] = news;
                }
                else x[pos] = x[pos + x.Taille];                                                          

                x[pos + x.Taille] = p;
                if (p.X < x.Taille) p.X++;
            }
            else if (x[pos + x.Taille] is Emplacement emp)
            {
                if (p.OnEmplacement)
                {
                    Emplacement news = new Emplacement(p.X, p.Y);
                    x[x.FindIndex(ind => ind.Equals(p))] = news;
                }
                else
                {
                    p.OnEmplacement = true;
                    x[pos] = new Elements(p.X, p.Y);
                }
                x[x.FindIndex(ind => ind.Equals(emp))] = p;
                if (p.X < x.Taille) p.X++;
            }
            else if (x[pos + x.Taille] is Caisse c) 
            {
                if (x[pos + (x.Taille * 2)].GetType().Name == "Elements")
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        Emplacement news = new Emplacement(p.X, p.Y);
                        x[x.FindIndex(ind => ind.Equals(p))] = news;
                    }
                    else
                    {
                        x[pos + (x.Taille * 2)].X -= 2;
                        x[pos] = x[pos + (x.Taille * 2)];
                    }
                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[pos + (x.Taille * 2)] = c;

                    if (c.OnEmplacement)
                    {
                        p.OnEmplacement = true;
                        c.OnEmplacement = false;
                    }
                    if (p.X < x.Taille) p.X++;
                    if (c.X < x.Taille) c.X++;
                }
                else if (x[pos + (x.Taille * 2)] is Emplacement e)
                {
                    if (p.OnEmplacement)
                    {
                        p.OnEmplacement = false;
                        x[x.FindIndex(ind => ind.Equals(p))] = new Emplacement(p.X, p.Y);
                    }
                    else { x[x.FindIndex(ind => ind.Equals(p))] = new Elements(p.X, p.Y); }

                    x[x.FindIndex(ind => ind.Equals(c))] = p;
                    x[x.FindIndex(ind => ind.Equals(e))] = c;

                    c.OnEmplacement = true;
                    p.OnEmplacement = c.OnEmplacement;
                    
                    if (p.X < x.Taille) p.X++;
                    if (c.X < x.Taille) c.X++;
                }                        
            }                          
            return x;
        }
    }
}
