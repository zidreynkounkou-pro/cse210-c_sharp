using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }


        static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName()
    {
        Console.WriteLine("What is your name? ");
        string userName = Console.ReadLine();

        return userName;
    }


    static int PromptUserNumber()
    {
        Console.WriteLine("What is your favorite number? ");
        int favoriteNumber = int.Parse(Console.ReadLine());

        return favoriteNumber;
    }


    static int SquareNumber(int number)
    {
        int numberSquared = (int)Math.Pow(number, 2);
        return numberSquared;
    }


    static void DisplayResult( string userName, int numberSquared)
    {
        Console.WriteLine($"{userName}, the square of your number is {numberSquared}");
    }

}