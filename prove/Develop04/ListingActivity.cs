using System;

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

  private int _duration;
  

  public ListingActivity(string listingMessage, string activityName, string description) : base(activityName, description)
  {
    _items.Add(listingMessage);
  }

  public ListingActivity(int duration) : base(duration)
  {
    _duration = duration;
  }

  Random random = new Random();
  public string RandomPrompt()
  {
    int randomIndex = random.Next(0, _promptList.Count);
    return _promptList[randomIndex];
  }

  public void DisplayNumberOfItems()
  {
    int numberOfItems = _items.Count;
    Console.WriteLine($"You have listed {numberOfItems} items.");
  }

}