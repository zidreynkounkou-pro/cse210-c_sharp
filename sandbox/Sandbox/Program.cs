using System;
using System.Threading;

class Program
{
    static void Main(string [] args)
    {

        Market market = new Market();
        market.A();

        

      /*  Console.Title = "Breathing Animation";
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2);
            Console.WriteLine("Breathe In");

            // Simulate a fast text growing animation for inhaling
            for (int fontSize = 10; fontSize <= 20; fontSize++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.WriteLine(new string('#', fontSize));
                Console.ResetColor();
                Thread.Sleep(100);
            }

            Thread.Sleep(1000); // Pause for a moment at max size

            // Simulate a slower text shrinking animation for exhaling
            for (int fontSize = 20; fontSize >= 10; fontSize--)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 7, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                Console.WriteLine(new string('#', fontSize));
                Console.ResetColor();
                Thread.Sleep(200);
            }

            Thread.Sleep(1000); // Pause for a moment at min size
        } */




    }
}
