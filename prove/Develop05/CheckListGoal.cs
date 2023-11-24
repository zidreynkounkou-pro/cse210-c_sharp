using System;
using System.Globalization;
using System.Threading.Channels;
public class ChecklistGoal : Goal
{
  private GoalManager goal = new GoalManager();
  private List<string> _goals = new List<string>{};
  private List<string> _descriptionList = new List<string>{};
  private List<int> _numOfTimeList = new List<int>();
   private List<float> _points = new List<float>{};
   private List<int> _timesCompletionList = new List<int>{};
   private int _timesCompletionReturned;
  private int _aNumTime;
  private string _goal;
  private string _description;
  private float _goalPoints;
  private int _timesCompletion;
  private int _numTime;
  private float _bonusPoints;
  public ChecklistGoal(string goal, string goalDescription, float points, int numbOfTime, float bonus) : base(goal, goalDescription, points)
  {

    
    _goal = goal;
    _description = goalDescription;
    _goalPoints = points; 
    _bonusPoints = bonus;
    _numTime = numbOfTime;
    _timesCompletion = 0;

  }


  public override void WriteGoals()
  {
    _goals.Add(_goal);
    _descriptionList.Add(_description);
    _numOfTimeList.Add(_numTime);
    _points.Add(_goalPoints);
    _checkBonus.Add(_bonusPoints);
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
      _aNumTime = aNumTime;
    }
    return _aNumTime;
  }

  public int TimesCompletion()
  {
    foreach (var timesCompletion in _timesCompletionList)
    {
      _timesCompletionReturned = timesCompletion;
    }
    return _timesCompletionReturned;
  }

  public void TimesCompletionListForLoading(int numberTime)
  {
    _timesCompletionList.Add(numberTime);
  }

  public override bool IsCompleted(bool isCompleted)
    {
      return isCompleted;
    }
  


  public override void RecordEvent()
  {
    int goalIndex = _index;
    // Validate the index against the local goals count
    if (goalIndex >= 1 && goalIndex <= GoalManager.Goals().Count)
    {
      ChecklistGoal selectedGoal = GoalManager.Goals()[goalIndex - 1] as ChecklistGoal;
      if (selectedGoal != null)
      {
        selectedGoal._timesCompletion++;
        selectedGoal._timesCompletionList.Add(_timesCompletion);
        // Access properties of the specific ChecklistGoal instance
        float points = selectedGoal._goalPoints; // Accessing the goal points directly
        string description = selectedGoal._description; // Accessing the description directly

        if (selectedGoal._numTime == selectedGoal._timesCompletion)
        {
          float totalPoints = points + selectedGoal._bonusPoints;
          _scores.Add(totalPoints);
          Console.WriteLine($" Congratulatoins! You've completed: {description} goal. You've earned {totalPoints} points.");
          Console.WriteLine($"You have now {NowScore()} points.");
        }

        // Exceed requirements
        else if (selectedGoal._numTime < selectedGoal._timesCompletion)
        {
          Console.WriteLine($"Goal reached out ({selectedGoal._aNumTime} times). {selectedGoal._timesCompletion} times extra now. Do you want to continue? y/n");
          string yesOrNo = Console.ReadLine();

          if (yesOrNo.ToLower() == "y")
          {
            _scores.Add(points);
            Console.WriteLine($" Congratulatoins! You've completed: {description} goal. You've earned {points} points.");
            Console.WriteLine($"You have now {NowScore()} points.");
          }
          else
          {
            Console.WriteLine("Feel free to create a  new goal!");
          }
        }
        else
        {
          _scores.Add(points);
          Console.WriteLine($" Congratulatoins! You've completed: {description} goal. You've earned {points} points.");
          Console.WriteLine($"You have now {NowScore()} points.");
        }
        // Update completion status
        
        if (selectedGoal._numTime == selectedGoal._timesCompletion) 
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