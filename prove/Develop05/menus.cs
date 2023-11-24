using System;

public class Menus 
{

  private SimpleGoal simple;
  private EternalGoal eternal;
  private ChecklistGoal checklist;
  private GoalManager goals = new GoalManager();

  private List<string> _menuList = new List<string>()
  {
    "Create New Goal", "List Goals", "Save Goals", "Load Goals", "Record Event", "Quit"
  };

  private List<string> _goals = new List<string>()
  {
    "Simple Goal", "Eternal Goal", "Checklist Goal"
  };

  int input = -1;
  public void MenusMethod()
  {
    
    while(input != 6)
    {
      try
      {
        Console.WriteLine();
        Console.WriteLine($"You have {Goal.Score()} points.");
        Console.WriteLine("\nMenu Options: ");
        for(int i = 0; i < _menuList.Count; i++)
        {
          Console.WriteLine($"  {i + 1}. {_menuList[i]}");
        }
        Console.WriteLine("Select a choice from a menu:");
        input = int.Parse(Console.ReadLine());

        switch(input)
        {
          case 1:
          HandleMenuOption(input);
          break;

         case 2:
         Console.WriteLine("\nThe goals are:");
         goals.DisplayAllGoals();
         
         break;

         case 3:
         Console.WriteLine("What is the goal filename for the goal file?");
         string filename = Console.ReadLine();
         Goal.Filename(filename);
         Goal.SaveGoals();
         break;

         case 4:
         Console.WriteLine("What is the goal filename for the goal file?");
         string aFilename = Console.ReadLine();
         Goal.Filename(aFilename);
         Goal.LoadGoals();

         //Goal.Load();
         break;

         case 5:
         Console.WriteLine("The goals are: ");
         goals.DisplayAllGoalsToRecord();

         Console.WriteLine("Which goal did you accomplish?");
         int index = int.Parse(Console.ReadLine());

         Goal goal = GoalManager.Goals()[index -1];
         if (goal is SimpleGoal)
         {
          simple.GoalIndex(index);
          simple.RecordEvent();
         }
         else if (goal is EternalGoal)
         {
          eternal.GoalIndex(index);
          eternal.RecordEvent();
         }
         else if (goal is ChecklistGoal)
         {
          checklist.GoalIndex(index);
          checklist.RecordEvent();
         }
         break;
        }
      }
      catch(Exception)
      {
        Console.WriteLine("ERROR! Please, make sure you entered the inspected information and try again!");
      }
    } 
  }

  private void HandleMenuOption(int option)
  {
    switch(option)
    {
      case 1:
      Console.WriteLine("The types of Goals are: ");
       for(int i = 0; i < _goals.Count; i++)
       {
        Console.WriteLine($"  {i + 1}. {_goals[i]}");
       }

        Console.WriteLine("Which type of goal would you like to create? ");
        int menu = int.Parse(Console.ReadLine());
        
        // Simple Goal.
        if(menu == 1)
        {
          Console.WriteLine("What is the name of your goal? ");
          string goalName = Console.ReadLine();
          Console.WriteLine("What is a short description of it? ");
          string description = Console.ReadLine();
          Console.WriteLine("What is the amount of points associated with this goal? ");
          float points = float.Parse(Console.ReadLine());
      
         simple = new SimpleGoal(goalName, description, points);
         simple.WriteGoals();
         goals.AddGoal(simple);
        } 

        // Eternal Goal.
        else if(menu == 2)
        {
          Console.WriteLine("What is the name of your goal? ");
          string goalName = Console.ReadLine();
          Console.WriteLine("What is a short description of it? ");
          string description = Console.ReadLine();
          Console.WriteLine("What is the amount of points associated with this goal? ");
          float points = float.Parse(Console.ReadLine());

          eternal = new EternalGoal(goalName, description, points);
          eternal.WriteGoals();
          goals.AddGoal(eternal);
        }

        else // Checklist Goal
        {
          Console.WriteLine("What is the name of your goal? ");
          string goalName = Console.ReadLine();
          Console.WriteLine("What is a short description of it? ");
          string description = Console.ReadLine();
          Console.WriteLine("What is the amount of points associated with this goal? ");
          float points = float.Parse(Console.ReadLine());
          Console.WriteLine("How many time this goal need to be accomplished for a bonus? ");
          int numberTime = int.Parse(Console.ReadLine());
          Console.WriteLine("What is the bonus for accomplishing it that many times?");
          float bonus = float.Parse(Console.ReadLine());

          checklist = new ChecklistGoal(goalName, description, points, numberTime, bonus);
          checklist.WriteGoals();
          goals.AddGoal(checklist);

        }
      break;
    }
  }
}