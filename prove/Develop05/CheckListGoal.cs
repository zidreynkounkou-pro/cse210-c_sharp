using System;
using System.Globalization;
using System.Threading.Channels;
public class ChecklistGoal : Goal
{
  private List<string> _goals = new List<string>{};
  private List<string> _descriptionList = new List<string>{};
  private List<float> _points = new List<float>{};
  private int _aNumTime;
  private string _goal;
  private string _description;
  private float _goalPoints;
  private int _numTime;
  public ChecklistGoal(string goal, string goalDescription, float points, int numbOfTime, float bonus) : base(goal, goalDescription, points)
  {

    
    _goal = goal;
    _description = goalDescription;
    _goalPoints = points; 
    _bonus = bonus;
    _numTime = numbOfTime;
    _timesCompletion = 0;

  }


  public override void WriteGoals()
  {
    _goals.Add(_goal);
    _descriptionList.Add(_description);
    _numOfTimeList.Add(_numTime);
    _points.Add(_goalPoints);
    _checkBonus.Add(_bonus);
    _checkTimes.Add(_numTime);
  }


  public override void DisplayGoals(int index)
  {
    string completionStatus = _isCompleted ? "[X]" : "[ ]";
    for(int i = 0; i < _goals.Count; i++) //entries in _entries)
    {
      Console.WriteLine($"{index}. {completionStatus } {_goals[i]} ({_descriptionList[i]}) -- currently completed: {_timesCompletion}/{NumberOfTime()}");
    }
  }


  public override void DisplayGoalsToRecord(int index)
  {
    for(int i = 0; i < _goals.Count; i++)
    {
      Console.WriteLine($"{index}. {_goals[i]}");
    }
  }


  private int NumberOfTime()
  {
    foreach(int aNumTime in _numOfTimeList)
    {
      _numberOfTime = aNumTime;
      _aNumTime = aNumTime;
    }
   
    return _numberOfTime;
  }

  private void Bonus()
  {
    foreach (var bonus in _checkBonus)
    {
      _bonus = bonus;
    }
  }

  public int TimesCompletion()
  {
    foreach (int timesCompletion in _timesCompletionList)
    {
      _timesCompletion = timesCompletion;
    }
    return _timesCompletion;
  }

  



  public override void RecordEvent()
  {
    int goalIndex = _index;
    // Validate the index against the local goals count
    if (goalIndex >= 1 && goalIndex <= GoalManager.Instance.Goals().Count)
    {
      ChecklistGoal selectedGoal = GoalManager.Instance.Goals()[goalIndex - 1] as ChecklistGoal;
      if (selectedGoal != null)
      {
        selectedGoal._timesCompletion++;
        // Access properties of the specific ChecklistGoal instance
        float points = selectedGoal._goalPoints; // Accessing the goal points directly
        string description = selectedGoal._description; // Accessing the description directly

        if (selectedGoal._aNumTime == selectedGoal._timesCompletion)
        {
          float totalPoints = points + selectedGoal._bonus;
          _scores.Add(totalPoints);
          Console.WriteLine($"Congratulatoins! You've completed: {description} goal. You've earned {totalPoints} points.");
          Console.WriteLine($"You have now {NowScore()} points.");
        }

        // Exceed requirements
        else if (selectedGoal._aNumTime < selectedGoal._timesCompletion)
        {
          Console.WriteLine($"Goal reached out ({selectedGoal._aNumTime} times). {selectedGoal._timesCompletion} times extra now. Do you want to continue? y/n");
          string yesOrNo = Console.ReadLine();

          if (yesOrNo.ToLower() == "y")
          {
            _scores.Add(points);
            Console.WriteLine($"Congratulatoins! You've completed: {description} goal. You've earned {points} points.");
            Console.WriteLine($"You have now {NowScore()} points.");
          }
          else
          {
            Console.WriteLine("Feel free to create a new goal!");
          }
        }
        else
        {
          _scores.Add(points);
          Console.WriteLine($"Congratulatoins! You've completed: {description} goal. You've earned {points} points.");
          Console.WriteLine($"You have now {NowScore()} points.");          
        }
        // Update completion status
        
        if (selectedGoal._aNumTime == selectedGoal._timesCompletion) 
        {
          selectedGoal._isCompleted = true;
        }
      }
      
      
    }
    
    else
    {
      Console.WriteLine("Invalid goal index.");
    }
  }
 
}