using System;
public class GoalManager
{
  private static GoalManager _instance;
  private static List<Goal> goals = new List<Goal>();
  private static string _filename;

// Singleton pattern starts here
  private GoalManager() { }


  public static GoalManager Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = new GoalManager();
      }
      return _instance;
    }
  }
  // Singleton pattern ends here.

  public void AddGoal(Goal goal)
  {
    goals.Add(goal);
  }
  public void DisplayAllGoals()
  {
    for (int i = 0; i < goals.Count; i++)
    {
      goals[i].DisplayGoals(i + 1); // Pass the index to the DisplayGoals method
    }
  }

  public void DisplayAllGoalsToRecord()
  {
    for (int i = 0; i < goals.Count; i++)
    {
      goals[i].DisplayGoalsToRecord(i + 1); // Pass the index to the DisplayGoalsToRecord method
    }
  }

  
  public List<Goal> Goals()
  {
    return goals;
  }

  public void Filename(string filename)
  {
    _filename = filename;
  }



  public void LoadGoals()
  {
    //string[] firstLine = System.IO.File.ReadAllLines(_filename);
    string[] lines = System.IO.File.ReadAllLines(_filename);
    
    // Process each goal to recreate the goals.
    foreach(string line in lines)
    {
      string[] data = line.Split("|");
      if (data.Length == 4)
      {
        string [] simpleGoalString = data;
        string goalName = simpleGoalString[0];
        string goalDescription = simpleGoalString[1];
        float points = float.Parse(simpleGoalString[2]);
        bool isCompleted = bool.Parse(simpleGoalString[3].ToLower());

        SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, points);

        simpleGoal.IsCompleted(isCompleted);
        AddGoal(simpleGoal);
      }
      else if (data.Length == 3)
      {
        string [] eternalGoalString = data;
        string goalName = eternalGoalString[0];
        string goalDescription = eternalGoalString[1];
        float points = float.Parse(eternalGoalString[2]);

        EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, points);
        AddGoal(eternalGoal);

      }
      else if (data.Length == 7)
      {
        string [] checklistGoalString = data;
        string goalName = checklistGoalString[0];
        string goalDescription = checklistGoalString[1];
        float points = float.Parse(checklistGoalString[2]);
        int timesCompletion = int.Parse(data[3]);
        int numberTime = int.Parse(data[4]);
        float bonus = float.Parse(data[5]);
        bool isCompleted = bool.Parse(checklistGoalString[6].ToLower());
        
        ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, points, numberTime, bonus);
       
        checklistGoal.IsCompleted(isCompleted);
        checklistGoal.TimesCompletionListForLoading(timesCompletion);
        AddGoal(checklistGoal);
      }
    }
  }
  
}
