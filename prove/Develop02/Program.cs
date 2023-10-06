using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("");
        Console.WriteLine("Welcome to the journal program!");

        // Initializing the list menu.
        List<string> menu = new List<string>() { "Write", "Display", "Load", "Save", "Quit" };

        // Setting the Journal class instance.
        Journal journal = new Journal();
        
        int toDo = -1;
        while (toDo != 5)
       {
            Console.WriteLine("Please select one of the following: ");
            Console.WriteLine("");
        
            // Let's iterate through the list, then display the menu.
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }

            Console.WriteLine();
            Console.Write("What would you like to do? ");
            // Getting the user's input.
            toDo = int.Parse(Console.ReadLine());
            Console.WriteLine();

            // Let's initialize the time, then get the current date.
            DateTime dateTime = DateTime.Now;
            string currentDate = dateTime.ToShortDateString();

            // Checking if the user enters 1. (write)
            if (toDo == 1)
            {  
                string prompt = PromptGenerator.RandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();
                Console.WriteLine();

                // The instance of the Entry class.
                Entry entry = new Entry(currentDate, prompt, response);

                // Let's call the AddEntry method and pass it its parameters.
                journal.AddEntry(entry); 
            }

            else if (toDo == 2)
            {   // Calling the display method from the Journal class.
                journal.DisplayAllEntries();
            }
            else if (toDo == 3)
            {
                Console.WriteLine("What is the name of the file you would like to load? ");
                string _fileToLoad = Console.ReadLine();
                journal._load = _fileToLoad;
                Console.WriteLine();

                journal.LoadingFile();
            }

            else if (toDo == 4)
            {   Console.WriteLine("What is the name of the file you would like to save? ");
                String _fileName = Console.ReadLine();
                journal._save = _fileName;
                Console.WriteLine();

                journal.WritingFile();
            }
       }  
       
    }
}