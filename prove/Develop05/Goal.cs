using System;
using System.Runtime.InteropServices;

public abstract class Goal 
{

  protected static List<string> _entries = new List<string>{};
  protected static List<float> _points = new List<float>{};
  protected static List<string> _checklist = new List<string>{};
  private string _goal;
  private string _goalDescription;
  private float _score;


  public Goal(string goal, string goalDescription, float score)
  {
    _goal = goal;
    _goalDescription = goalDescription;
    _score = score;
  }

  public Goal(float bonus)
  {
  }

  public virtual void WriteGoals(string entry, float points)
  {
    _entries.Add(entry);
    _points.Add(points);
  } 

  public static void DisplayGoals()
    {
      for(int i = 0; i < _entries.Count; i++)
      {
        Console.WriteLine($"{i +1}. {_entries[i]}|{_points[i]}");
      }
      for (int i = 0; i < _checklist.Count; i++)
      {
        Console.WriteLine(_checklist[i]);
      }
      
    }
 
  public abstract void RecordEvent();

  public Boolean IsComplite()
  {
    return true;
  }


  public static void Save()
  {
    Console.WriteLine("What is the fileneme for the goal file? ");
      string fileneme = Console.ReadLine();

      using (StreamWriter writer = new StreamWriter(fileneme, true))
      {
        for(int i = 0; i < _entries.Count; i++)
        {
          writer.WriteLine($"{_entries[i]}|{_points[i]}");
        }

        foreach (var checklist in _checklist)
      {
        writer.WriteLine(checklist);
      }

      }
  }

  public static void Load()
  {
    Console.WriteLine("What is the filename for the goal file?");
    string filename = Console.ReadLine();
    string [] lines = System.IO.File.ReadAllLines(filename);
    foreach (string line in lines)
    {
      string  parts = line.Trim();
      string [] partSplit = parts.Split("|");
      
      if (partSplit.Length == 2)
        {
          string goal = partSplit[0];
          float points = float.Parse(partSplit[1]);
          _entries.Add(goal);
          _points.Add(points);
        }
        else if (partSplit.Length > 2)
        {
          string goal = partSplit[0];
          float points = float.Parse(partSplit[1]);
          _entries.Add(goal);
          _points.Add(points);

        }


    }

  }

}