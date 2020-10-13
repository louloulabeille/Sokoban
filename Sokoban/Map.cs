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
            return this.Load(path, level);
        }
    }
}
