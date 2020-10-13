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
        public List<List<char>> Load(string path, int level)
        {
            ILoad obj = new LoadFromTxt();
            return obj.Load(path, level);
        }

        public Map GetMap(string path, int level)
        {
            List<List<char>> x = new List<List<char>>(Load(path, level));
            try
            {
                for (int i = 0; i < x.Count; i++)
                {
                    for (int j = 0; j < x[i].Count; j++)
                    {
                        if (x[i][j] == ' ') this.Add(new Elements(i, j));
                        else if (x[i][j] == 'X') this.Add(new Mur(i, j));
                        else if (x[i][j] == '.') this.Add(new Emplacement(i, j));
                        else if (x[i][j] == '*') this.Add(new Caisse(i, j));
                        else if (x[i][j] == '@') this.Add(new Personnage(i, j));
                        else throw new ApplicationException("Erreur dans le fichier map. Charactère" + x[i][j] + "non reconnu");
                    }
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e);
            }
            return this;
        }


    }
}
