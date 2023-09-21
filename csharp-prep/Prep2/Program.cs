using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string user = Console.ReadLine();
        int intUser = int.Parse(user);

        string letter;

        if (intUser >= 90)
        {
            letter = "A";
        }

        else if (intUser >= 80)
        {
            letter = "B";
        }

        else if (intUser >= 70)
        {
            letter = "C";
        }


        else if (intUser >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine("");
        Console.WriteLine($"Your grade is: {letter}");
        
        if (intUser >= 70)
        {
            Console.WriteLine("Congratulatons, you passed!");
        }

        else
        {
            Console.WriteLine("We are sorry that you failed, keep up the good work and come again!");
        }
    }
}