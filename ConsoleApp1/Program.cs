using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaires;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoad load = new LoadFromTxt();
            List<List<char>> test = new List<List<char>>();
            Map t = new Map();
            t.Load(@"C:\Users\Utilisateur\Desktop\sokoban - maps - master\maps\sokoban-maps-60-plain.txt", 5);
            Console.WriteLine(t.ToString());

        }
    }
}
