using System;
using System.IO;
using System.Collections.Generic;

public class ListingActivity : Activity
{
  private List<string> _promptList = new List<string>
  {
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?"
  };

  private List<string> _items = new List<string>{};

  private int _timer;
  

  public ListingActivity(string activityName, string description) : base(activityName, description)
  {
    
  }


  public ListingActivity(int duration) : base(duration)
  {
    _timer = duration;
  }

  Random random = new Random();

  private string RandomPrompt()
  {
    int randomIndex = random.Next(0, _promptList.Count);
    return _promptList[randomIndex];
  }

  public void DisplayRandomPrompt()
  {
    
    DateTime StartTime = DateTime.Now;
    DateTime endTime = StartTime.AddSeconds(_timer);

    Console.WriteLine("List as many responses you can to the following prompt: \n");
    Console.WriteLine($"--- {RandomPrompt()} ---\n");
    Console.Write("You may begin in: ");
    PausingShowingCountDown();
    Console.WriteLine();

    while (endTime > DateTime.Now)
    {
      string input = Console.ReadLine();
      _items.Add(input);
    }

  }

  public void DisplayNumberOfItems()
  {
    int numberOfItems = _items.Count;
    Console.WriteLine($"\nYou have listed {numberOfItems} items.\n");
  }

}