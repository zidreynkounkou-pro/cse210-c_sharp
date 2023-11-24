using System;
using System.Runtime.InteropServices;

public abstract class Goal 
{
  protected static List<float> _scores = new List<float>{};
  protected static List<float> _checkBonus = new List<float>();
  protected static List<int> _checkTimes = new List<int>();
  
  protected bool _isCompleted;
  private float _points;
  private string _goal;
  private string _goalDescription;
  private static string _filename;
  private static float _score;
  private static float _totalScore;
  private float _bonus;
  private int _numberOfTime;
  protected int _index;


  public Goal(string goal, string goalDescription, float score)
  {
    _goal = goal;
    _goalDescription = goalDescription;
    _points = score;
    _isCompleted = false;
  }

  public abstract void WriteGoals();
  public abstract void DisplayGoals(int index);
  public abstract void DisplayGoalsToRecord(int index);
  public abstract bool IsCompleted(bool isCompleted);
 
  public abstract void RecordEvent();

  public static float Score()
  {
    float total = 0;
    foreach(float score in _scores)
    {
      total += score;
      _totalScore = total;
    }
    return _totalScore;
  }

  public static float NowScore()
  {
    float total = 0;
    foreach(float score in _scores)
    {
      total += score;
      _score = total;
    }
    return _score;
  }

  public void GoalIndex(int index)
  {
    _index = index;
  }


  public static void Filename(string filename)
  {
    _filename = filename;
  }

  private float Bunus()
  {
    foreach(float bonus in _checkBonus)
    {
      _bonus = bonus;
    }
    return _bonus;
  }

  private int CheckTimes()
  {
    foreach(int checkTime in _checkTimes)
    {
      _numberOfTime = checkTime;
    }
    return _numberOfTime;
  }
  public static void SaveGoals()
  {
    using(StreamWriter writer = new StreamWriter(_filename, true))
    {
      writer.WriteLine($"{Score()}\n");
      foreach(Goal goal in GoalManager.Goals())
      {
        if (goal is SimpleGoal simpleGoal)
        {
          string goalName = simpleGoal._goal;
          string description = simpleGoal._goalDescription;
          float points = simpleGoal._points;
          bool isCompleted = simpleGoal._isCompleted;

          writer.WriteLine($"{goalName}|{description}|{points}|{isCompleted}");
        }
        else if (goal is EternalGoal eternalGoal)
        {
          string goalName = eternalGoal._goal;
          string description = eternalGoal._goalDescription;
          float points = eternalGoal._points;
          writer.WriteLine($"{goalName}|{description}|{points}");
        }
        else if(goal is ChecklistGoal checklistGoal)
        {
          string goalName = checklistGoal._goal;
          string description = checklistGoal._goalDescription;
          float points = checklistGoal._points;
          bool isCompleted = checklistGoal._isCompleted;
          float bonus = checklistGoal.Bunus();
          int number = checklistGoal.CheckTimes();
          int timesCompletion = checklistGoal.TimesCompletion();

          writer.WriteLine($"{goalName}|{description}|{points}|{timesCompletion}|{number}|{bonus}|{isCompleted}");
        }
      }
    }
    Console.WriteLine($"Goals have been saved succussfully in the {_filename} file.");
  }


  public static void LoadGoals()
  {
    string[] firstLine = System.IO.File.ReadAllLines(_filename);
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
        GoalManager manager = new GoalManager();
        simpleGoal.IsCompleted(isCompleted);
        manager.AddGoal(simpleGoal);
      }
      else if (data.Length == 3)
      {
        string [] eternalGoalString = data;
        string goalName = eternalGoalString[0];
        string goalDescription = eternalGoalString[1];
        float points = float.Parse(eternalGoalString[2]);

        EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, points);
        GoalManager manager = new GoalManager();
        manager.AddGoal(eternalGoal);

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
        GoalManager manager = new GoalManager();
        checklistGoal.IsCompleted(isCompleted);
        checklistGoal.TimesCompletionListForLoading(timesCompletion);
          manager.AddGoal(checklistGoal);
      }
    }
  }

}