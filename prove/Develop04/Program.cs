using System;

class Program
{
    // I have handled a format exception to exceed requirements for this project
    // from here (Program.cs), lines, 16 and 86.
    static void Main(string[] args)
    {
        // The main list menu.
        List<string> menu = new List<string>{"Start Breathing Activity", "Start Reflecting Activity", "Start Listing Activity", "Quit"};

        int menuInt = -1;

        while (menuInt != 4)
        {
            try{        // Handle a format exception. Exceeding requirements.
            
                Console.WriteLine("\nMenu Options:");
                for(int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i]}");
                }

                Console.WriteLine("Select a choice from the menu: ");
                menuInt = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch(menuInt)
                {
                    case 1:
                    BreathingActivity breathing1 = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");


                    breathing1.DisplayStartingMessage();
                    int _breathDuration = int.Parse(Console.ReadLine());

                    BreathingActivity breathing2 = new BreathingActivity(_breathDuration, "Breathe in...", "Now breathe out...", "Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");



                    Console.WriteLine();
                    breathing1.GetReady();
                    breathing2.BreathInAndBreathOut();

                    breathing1.Duration(_breathDuration);
                    breathing1.DisplayEndingMessage();
                    break;

                    case 2:
                    ReflectingActivity reflecting = new ReflectingActivity( "Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

                    reflecting.DisplayStartingMessage();
                    int _reflectDuration = int.Parse(Console.ReadLine());
                     Console.WriteLine();
                    reflecting.GetReady();
                    reflecting.PausingShowingSpinner();

                    ReflectingActivity reflecting1 = new ReflectingActivity(_reflectDuration);

                    reflecting1.DisplayPrompts();

                    Console.WriteLine();
                    reflecting.Duration(_reflectDuration);
                    reflecting.DisplayEndingMessage();
                    break;

                    case 3:
                    ListingActivity listing = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

                    listing.DisplayStartingMessage();
                    int _listDuration = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    listing.GetReady();
                    
                    listing.PausingShowingSpinner();

                    ListingActivity listing1 = new ListingActivity(_listDuration);
                    listing1.DisplayRandomPrompt();
                    listing1.DisplayNumberOfItems();
                    listing.Duration(_listDuration);
                    listing.DisplayEndingMessage();
                    break;
                }
        
            }
            // Handle a format exception. 
            // Exceeding requirements.
            catch(FormatException e)
            {
                Console.WriteLine($"Tried to enter a wrong format.\n\n{e}.\n\nEnter an integer and try again, please!");
            }  

        }

    }
        
}