using System;

List<int> numbers = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

int userInput = -1;
while (userInput != 0)
{   // Prompting the user.
    Console.WriteLine("Enter a number: ");
    string user = Console.ReadLine();
    // Converting the user's prompt into integer.
    userInput = int.Parse(user);

    if (userInput != 0)
    {   // Adding the user's input into the list.
        numbers.Add(userInput);
        numbers.Sort();
    }


    else
    {   // Initializing the sum.
        int sum = 0;
        // Initializing the lagest number.
        int lagest = 0;
        // Initializing the smallest number.
        int smallest = 5679;
        // Iterating through the list of numbers.
        foreach (int number in numbers)
        {
            // Finding the sum.
            sum += number;

            // Finding the lagest number.
            if (lagest < number)
            {
                lagest = number;
            }

            // Stretch challenge.
            // Finfind the smallest positive number.
            if (number > 0 && number < smallest)
            {
                smallest = number;
            }
        }

        // Finding the average.
        float average = ((float)sum) / numbers.Count;
        // Printing the results out.
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The lagest number is: {lagest}");
        // Stretch challenge.
        Console.WriteLine($"The smallest positive number is: {smallest}");
        Console.WriteLine($"The sorted list is: ");

        foreach (int sort in numbers)
        {
            Console.WriteLine(sort);
        }
    }

}
