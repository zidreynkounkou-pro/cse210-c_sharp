using System;

public class Menus 
{

  private SimpleGoal simple;
  private EternalGoal eternal;
  private ChecklistGoal checklist;

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
      Console.WriteLine("\nYou have 0 points");
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
       Goal.DisplayGoals();

       break;

       case 3:
       Goal.Save();
       break;

       case 4:
       Goal.Load();
       break;

       case 5:
       
       break;
      };
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

        }
      break;

    }
  }
}