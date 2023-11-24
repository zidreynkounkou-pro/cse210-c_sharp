using System;
using System.Threading.Channels;

public class SimpleGoal : Goal
{
  private List<string> _descriptionList = new List<string>{};
  private static List<string> _goals = new List<string>{};
  private List<float> _points = new List<float>{};
  private string _goal;
  private string _description;
  private float _goalPoints;
  public SimpleGoal(string goal, string goalDescription, float points) : base(goal, goalDescription, points)
  {
   _goal = goal;
    _description = goalDescription;
    _goalPoints = points;
  }

  public override void WriteGoals()
    {
      _goals.Add(_goal);
       _descriptionList.Add(_description);
      _points.Add(_goalPoints);
    }

    public override bool IsCompleted(bool isCompleted)
    {
      return isCompleted;
    }

  public override void DisplayGoals(int index)
  {
    string completionStatus = IsCompleted(_isCompleted) ? "[X]" : "[ ]";
    for(int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{index}. {completionStatus } {_goals[i]} ({_descriptionList[i]})");
    }
  }
  public override void DisplayGoalsToRecord(int index)
  {
    for(int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{index}. {_goals[i]}");
    }
  }


  public override void RecordEvent()
  {
    int goalIndex = _index;
    // Validate the index against the local goals count
    if (goalIndex >= 1 && goalIndex <= GoalManager.Instance.Goals().Count)
    {
      SimpleGoal selectedGoal = GoalManager.Instance.Goals()[goalIndex - 1] as SimpleGoal;
      if (selectedGoal != null)
      {
        // Access properties of the specific SimpleGoal instance
        float points = selectedGoal._goalPoints; // Accessing the goal points directly
        string description = selectedGoal._description; // Accessing the description directly
        // Update completion status
        selectedGoal._isCompleted = true;

        _scores.Add(points);
        Console.WriteLine($"Congratulations! You've completed: {description} goal. You've earned {points} points.");
        Console.WriteLine($"You have now {NowScore()} points.");
      }
    }
    else
    {
      Console.WriteLine("Invalid goal index.");
    }
  }
}