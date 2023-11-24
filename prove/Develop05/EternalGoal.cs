using System;
using System.Threading.Channels;

public class EternalGoal : Goal
{
  private List<string> _goals = new List<string>{};
  private List<string> _descriptionList = new List<string>{};
  private List<float> _points = new List<float>{};
  private string _goal;
  private string _description;
  private float _goalPoints;
  public EternalGoal(string goal, string goalDescription, float points) : base(goal, goalDescription, points)
  {
   _goal = goal;
    _description = goalDescription;
    _goalPoints = points;
  }

  public override bool IsCompleted(bool isCompleted)
    {
      return isCompleted;
    }

  public override void WriteGoals()
    {
       _goals.Add(_goal);
       _descriptionList.Add(_description);
      _points.Add(_goalPoints);
    }

  public override void DisplayGoals(int index)
  {
    string completionStatus = IsCompleted(_isCompleted) ? "[X]" : "[ ]" ;
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
      EternalGoal selectedGoal = GoalManager.Instance.Goals()[goalIndex - 1] as EternalGoal;
      if (selectedGoal != null)
      {
        // Access properties of the specific SimpleGoal instance
        float points = selectedGoal._goalPoints; // Accessing the goal points directly
        string description = selectedGoal._description; // Accessing the description directly
        // Update completion status
        selectedGoal._isCompleted = false; // As it is an eternal goal
        _scores.Add(points);
        Console.WriteLine($"Congratulations! You've completed this goal: {description}. You've earned {points} points");
        Console.WriteLine($"You have now {NowScore()} points.");
        IsCompleted(false);
      }
    }
    else
    {
      Console.WriteLine("Invalid goal index.");
    }
  }

}