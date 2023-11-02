using System;
public class Activity {
  private string _activityName;
  private string _description;
  private int _duration;

  private List<string> _spinnerList = new List<string>{"\\", "|", "/", "—", "\\", "|", "/", "—", "\\", "|", "/", "—", "\\", "|", "/"};


    public Activity(string activityName, string description)
  {
    _activityName = activityName;
    _description = description;
  }

  public Activity(int duration)
  {
    _duration = duration;
  }

  public void Duration(int timer)
  {
    _duration = timer;
  }

    public void GetReady()
  {
    Console.WriteLine("\nGet ready...\n");
  }

  public void DisplayStartingMessage()
  {
    Console.WriteLine($"Welcome to the {_activityName}\n\n{_description}\n!");
    Console.WriteLine("How long, in seconds, would you like for your session?");
  }

  public void PausingShowingSpinner()
  {
    DateTime  startime = DateTime.Now;
    DateTime endTime = startime.AddSeconds(1);
    while (endTime > DateTime.Now)
    {
       foreach (var spinner in _spinnerList)
      {
        Console.Write(spinner);
        Thread.Sleep(500);
        Console.Write("\b \b");
      
      }
    }
    
  }

  public void PausingShowingCountDown()
  {
    DateTime  startime = DateTime.Now;
    DateTime endTime = startime.AddSeconds(1);
    while (endTime > DateTime.Now)
    {
       for (var i = 5; i > 0; i--)
      {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
        
      }
    }
  }

  public void DisplayEndingMessage()
  {
    Console.WriteLine("Well done!");
    PausingShowingSpinner();
    Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_activityName}.");
    PausingShowingSpinner();
  }
}