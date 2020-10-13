using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utilitaires;

namespace Sokoban
{
    public class Map : ILoad
    {
        public IEnumerable Load(string path, int level)
        {
            ILoad obj = new LoadFromTxt();
            return obj.Load(@"C:\Users\Utilisateur\Desktop\sokoban-maps-master\maps\sokoban-maps-60-plain.txt", level);
        }
    }
}
