using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Program
{

    // To exceed requirements, I hide only words that are not hidden yet.
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Scripture Memorization Program. We hope you will enjoy it!\n");

        // Create a scripture with the reference and text
        //var endScripture = new Scripture("And it came to pass that again they heard the voice, and they understood it not.");
        var scripture = new Scripture("3 Nephi 11:3-4", "And it came to pass that while they were thus conversing one with another, they heard a voice as if it came out of heaven; and they cast their eyes round about, for they understood not the voice which they heard; and it was not a harsh voice, neither was it a loud voice; nevertheless, and notwithstanding it being a small voice it did pierce them that did hear to the center, insomuch that there was no part of their frame that it did not cause to quake; yea, it did pierce them to the very soul, and did cause their hearts to burn.", "And it came to pass that again they heard the voice, and they understood it not.");
        
        

        // Display the full scripture
        scripture.Display();
        Console.WriteLine();

        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");

        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                Console.WriteLine("\nBye Bye!");
                break;
            }
            else if (input == "")
            {
                // Hide a few random words and display the scriptures
                scripture.HideRandomWords();
                Console.WriteLine();
                Console.Clear();
                scripture.Display();
                Console.WriteLine();

                // Check if all words are hidden
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Well done!"); // Exceeding requirements.
                    break;
                }
                Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            }
        }
    }
}