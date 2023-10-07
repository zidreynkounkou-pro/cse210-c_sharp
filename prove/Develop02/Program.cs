using System;


/* 
To exceed requirements for this projet, I have covered the following:
- I have allowed the user to give only the name of the file first, then being prompted to give the format that they desir to save their file with. csv and text formats being recommanded.
- I have handeled exceptions that may occur when interacting with the user. Such as FormatException for manipulating the menu
(Here I set an attribute and created a method that allow me to pick up the string, then print it on the screen for the user view.), FileNotFoundException, DirectoryNotFoundException, NotSupportedException ....

All these adds have led me to create other attributes and methods that you can find below and in the Journal class.

I have done this project, so it is more dynimic.
*/

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
        
        
        int _toDo = -1;
        while (_toDo != 5)
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
            try // Handling format exception.
            {     string _exception = Console.ReadLine();
            journal._ex = _exception;
                _toDo = int.Parse(_exception);

                Console.WriteLine();
            
            
                // Let's initialize the time, then get the current date.
                DateTime dateTime = DateTime.Now;
                string currentDate = dateTime.ToShortDateString();

                // Checking if the user enters 1. (write)
                if (_toDo == 1)
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

                else if (_toDo == 2)
                {   // Calling the display method from the Journal class.
                    journal.DisplayAllEntries();
                }
                else if (_toDo == 3)
                {
                    Console.WriteLine("What is the name of the file you would like to load? e.g: filename, myFile....");
                    string _fileToLoad = Console.ReadLine();
                    journal._load = _fileToLoad;
                    Console.WriteLine("What is the format of your file? e.g: csv, text....");
                    string _loadFormat = Console.ReadLine();
                    journal._loadFormat = _loadFormat;
                    Console.WriteLine();
                    journal.LoadingFile();
                }

                else if (_toDo == 4)
                {   Console.WriteLine("What is the name of the file you would like to save? e.g: myFile, filename....");
                    string _fileName = Console.ReadLine();
                    journal._save = _fileName;
                    Console.WriteLine("What is the format of the file, please? e.g: csv, text.... (csv and text formats are recommanded.)");
                    string _format = Console.ReadLine();
                    journal._format = _format;
                    Console.WriteLine();
                    
                    journal.WritingFile();
                    Console.WriteLine($"Your file '{_fileName + "." + _format}' has been saved successfully.");
                    Console.WriteLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine($"Attempted to enter a wrong format '{journal.HandlingFormatException()}'. Please, enter an integer and try again!");
                Console.WriteLine();
            }
       }  
       Console.WriteLine("Thank you, bye-bye!");
       
    }
}
