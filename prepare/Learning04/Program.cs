using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine();
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine($"{math.GetSummary()}\n{math.GetHomeworkList()}");
        Console.WriteLine();
        
        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History","The Causes of World War II");
        Console.WriteLine($"{writing.GetSummary()}\n{writing.GetWritingInformation()}");

    }
}