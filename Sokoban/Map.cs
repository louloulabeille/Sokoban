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



        
    }
}
