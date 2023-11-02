using System;

class Program
{
    static void Main(string[] args)
    {
        // Activity lists
        List<string> menu = new List<string>{"Start Breathing Activity", "Start Reflecting Activity", "Start Listing Activity", "Quit"};

        int menuInt = -1;

        // Constructors
        
        

        /* ReflectingActivity reflectingActivity = new ReflectingActivity(_answer, "Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", _reflectDuration)

        ListingActivity listingActivity = new ListingActivity(_listingMessage, "Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", _listDuration); */



        while (menuInt != 4)
        {
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

                Activity activity = new Activity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing");

                activity.DisplayStartingMessage();
                int _breathDuration = int.Parse(Console.ReadLine());

                

                BreathingActivity breathing1 = new BreathingActivity(_breathDuration,"Breath in...", "Now breathe out...", "Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathing1.Duration(_breathDuration);

            

                //BreathingActivity breathing2 = new BreathingActivity(_breathDuration);


                Console.WriteLine();
                activity.GetReady();
                breathing1.BreathInAndBreathOut();
                Console.WriteLine();

                breathing1.DisplayEndingMessage();
                break;

                case 2:
                Activity activity2 = new Activity("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

                activity2.DisplayStartingMessage();
                int _reflectDuration = int.Parse(Console.ReadLine());
                activity2.GetReady();
                Console.WriteLine("Consider the following prompt: ");
                


                ReflectingActivity reflecting = new ReflectingActivity( "Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

                ReflectingActivity reflecting1 = new ReflectingActivity(_reflectDuration);

                reflecting1.DisplayPrompts();
                
                Console.WriteLine();
                reflecting.Duration(_reflectDuration);
                reflecting.DisplayEndingMessage();
                

                break;

                case 3:
                break;

                
            }
        }

        }
        
}