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
            List<Map> listOfMap = new List<Map>();
            Map listElem = new Map();
            int c = 0;
            foreach (Elements elem in map)
            {
                if (elem.X == c) {
                    listElem.Add(elem);
                }
                else {
                    listOfMap.Add(listElem);
                    listElem = new Map();
                    listElem.Add(elem);
                    c += 1;
                }
            }
            foreach (Map e in listOfMap)
            {
                foreach (Elements elem in e)
                {
                    Console.Write(elem);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
