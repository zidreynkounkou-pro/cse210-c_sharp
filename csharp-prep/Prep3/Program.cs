using System;

class Program
{
    static void Main(string[] args)
    {
        /* Console.Write("What is the magic number? ");
        string magicNumber = Console.ReadLine();

        int intMagicNumber = int.Parse(magicNumber);
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, intMagicNumber); */


        string wantToContinue = "yes";

        while (wantToContinue.ToLower() == "yes")
        {   
            // Initialize a random object
            Random randomGenerator = new Random();
            // Random variable.
            int randomNumber = randomGenerator.Next(1, 101);
            // Initialize the guess and count.
            int intGuess = 0;
            int count = 0;
            // While loops start here.
            while (intGuess != randomNumber)
            {   // Prompt the user.
                Console.WriteLine("What is your guess? ");
                string guess = Console.ReadLine();
                intGuess = int.Parse(guess);

                if (intGuess < randomNumber)
                {
                    Console.WriteLine("Higher");
                    // Incremeting the counting by 1.
                    count++ ;
                }
                else if (intGuess > randomNumber)
                {
                    Console.WriteLine("Lower");
                    count++ ;
                }

                else
                {
                    count++ ;
                    Console.WriteLine("You guessed it!");


                    if (count == 1)
                {   // Displaying the counting.
                    Console.WriteLine($"You made {count} guesse.");
                }

                else
                {
                    Console.WriteLine($"You made {count} guesses.");
                }

                }

            }
            // Check if the user wants to continue.
            Console.WriteLine("Do you want to continue playing? (yes/no) ");
            wantToContinue = Console.ReadLine();
            // Check if the user does not want to continue and end the game.
            if (wantToContinue.ToLower() != "yes")
            {
                Console.WriteLine("Thanks for Playing!");
            }

        }
        
    }
}