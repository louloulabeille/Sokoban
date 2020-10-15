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
            Console.Clear();
            for (int i = 0; i<map.Count; i++)
            {
                if (i % map.Taille == 0) Console.WriteLine();
                Console.Write(map[i]);
            }
        }
    }
}
