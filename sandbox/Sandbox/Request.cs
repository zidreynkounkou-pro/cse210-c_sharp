using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    protected string _goalName;
    protected float _score;

    public Goal(string goalName, float score)
    {
        _goalName = goalName;
        _score = score;
    }

    public abstract void RecordEvent();
    public abstract void DisplayGoal();
    public abstract string SaveGoal();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string goalName, float score) : base(goalName, score) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for Simple Goal: {_goalName}");
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Simple Goal: {_goalName}, Score: {_score}");
    }

    public override string SaveGoal()
    {
        return $"Simple Goal, {_goalName}, {_score}";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string goalName, float score) : base(goalName, score) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for Eternal Goal: {_goalName}");
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Eternal Goal: {_goalName}, Score: {_score}");
    }

    public override string SaveGoal()
    {
        return $"Eternal Goal, {_goalName}, {_score}";
    }
}

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _totalTimes;

    public ChecklistGoal(string goalName, float score, int totalTimes) : base(goalName, score)
    {
        _timesCompleted = 0;
        _totalTimes = totalTimes;
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for Checklist Goal: {_goalName}");
        _timesCompleted++;
        if (_timesCompleted >= _totalTimes)
        {
            _score += 500; // Bonus on completing the goal
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Checklist Goal: {_goalName}, Score: {_score}, Completed {_timesCompleted}/{_totalTimes} times");
    }

    public override string SaveGoal()
    {
        return $"Checklist Goal, {_goalName}, {_score}, {_timesCompleted}/{_totalTimes}";
    }
}

public class Program
{
    private static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateNewGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        } while (choice != 6);
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("1. Create a new goal");
        Console.WriteLine("2. List goals");
        Console.WriteLine("3. Save goals");
        Console.WriteLine("4. Load goals");
        Console.WriteLine("5. Record event");
        Console.WriteLine("6. Quit");
        Console.Write("Select an option: ");
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("Creating a new goal...");
        // Logic to create a new goal and add it to the goals list
        // For example:
        goals.Add(new SimpleGoal("Run a Marathon", 1000));
        Console.WriteLine("New goal created.");
    }

    private static void ListGoals()
    {
        Console.WriteLine("\nList of Goals:");
        foreach (var goal in goals)
        {
            goal.DisplayGoal();
        }
    }

    private static void SaveGoals()
    {
        Console.WriteLine("\nSaving goals to file...");
        string filename = "goals.txt"; // Change the filename or path as needed

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.SaveGoal());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private static void LoadGoals()
    {
        Console.WriteLine("\nLoading goals from file...");
        string filename = "goals.txt"; // Change the filename or path as needed

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                // Logic to parse each line and create Goal objects, then add them to the goals list
                // For example:
                string[] parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    string goalType = parts[0].Trim();
                    string goalName = parts[1].Trim();
                    float score = float.Parse(parts[2].Trim());

                    if (goalType == "Simple Goal")
                    {
                        goals.Add(new SimpleGoal(goalName, score));
                    }
                    else if (goalType == "Eternal Goal")
                    {
                        goals.Add(new EternalGoal(goalName, score));
                    }
                    else if (goalType == "Checklist Goal")
                    {
                        int timesCompleted = int.Parse(parts[3].Trim().Split('/')[0]);
                        int totalTimes = int.Parse(parts[3].Trim().Split('/')[1]);
                        goals.Add(new ChecklistGoal(goalName, score, totalTimes) { _timesCompleted = timesCompleted });
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    private static void RecordEvent()
    {
        Console.WriteLine("\nRecording event for a goal...");
        // Logic to record an event for a specific goal
        // For example:
        if (goals.Count > 0)
        {
            Console.WriteLine("Choose a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]._goalName}");
            }

            int index;
            if (int.TryParse(Console.ReadLine(), out index) && index >= 1 && index <= goals.Count)
            {
                goals[index - 1].RecordEvent();
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a valid goal.");
            }
        }
        else
        {
            Console.WriteLine("No goals available to record events.");
        }
    }
}
