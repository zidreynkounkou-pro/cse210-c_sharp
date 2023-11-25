using System;
public class GoalManager
{
  private static GoalManager _instance;
  private static List<Goal> goals = new List<Goal>();

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

}
