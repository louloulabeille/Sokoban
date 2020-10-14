using Sokoban;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Utilitaires
{
    public class AffichageConsole : IAfficher
    {
        void IAfficher.Afficher(Map map)
        {
            List<Map> x = new List<Map>();
            Map m = new Map();
            int c = 0;
            foreach (Elements e in map)
            {
                if (e.X == c) {
                    m.Add(e);
                }
                else {
                    x.Add(m);
                    m = new Map();
                    c += 1;
                }
            }
            foreach (Map e in x)
            {
                Console.WriteLine(e);
            }
        }
    }
}
