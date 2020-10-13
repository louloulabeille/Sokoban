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
            for (int i = 0; i<map.Count;i++)
            {
                Console.WriteLine(map[i]);
            }
        }
    }
}
