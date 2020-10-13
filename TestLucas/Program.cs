using System;
using Sokoban;

namespace TestLucas
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Personnage personnage = new Personnage();
                personnage.OnZPressed += Personnage_OnZPressed;
            
        }

        private static void Personnage_OnZPressed(object sender, EventArgs e)
        {
            Console.WriteLine("Z pressed");
        }
    }
}
