using System;
using Sokoban;
namespace TestDeplace
{
    class Program
    {
        static private void Test_OnUpchanged(object sender, EventArgs e)
        {
            
        }

        static void Main(string[] args)
        {
            Personnage personnage = new Personnage(3,6);
            Elements elements = new Elements();
            elements.X = 12;
            elements.Y = 5;
            

            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    personnage.OnUPchanged += Test_OnUpchanged;
                    
                //    switch (Console.ReadKey(true).Key)
                //    {

                //        case ConsoleKey.LeftArrow:
                //            elements.X--;
                //            Console.Write(" " + elements.X);
                //            Console.WriteLine(" " + elements.Y);
                //            break;
                //        case ConsoleKey.UpArrow:
                //            elements.Y++;
                //            Console.Write(" " + elements.X);
                //            Console.WriteLine(" " + elements.Y);
                //            break;
                //        case ConsoleKey.RightArrow:
                //            elements.X++;
                //            Console.Write(" " + elements.X);
                //            Console.WriteLine(" " + elements.Y);
                //            break;
                //        case ConsoleKey.DownArrow:
                //            elements.Y--;
                //            Console.Write(" " + elements.X);
                //            Console.WriteLine(" " + elements.Y);
                //            break;
                //    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
