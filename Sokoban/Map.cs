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
                                this.Add(new Personnage(i, j));
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

       /* public override string ToString()
        {
            return string.Join(separator: ",", values: this.ForEach(Elements e in this);
        }*/
    }
}
