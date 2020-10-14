using System;

namespace Testdeplacement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).Key)
                    {

                        case ConsoleKey.LeftArrow:
                            Console.WriteLine("Left");
                            break;
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("Up");
                            break;
                        case ConsoleKey.RightArrow:
                            Console.WriteLine("Right");
                            break;
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("Down");
                            break;

                    }

                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
