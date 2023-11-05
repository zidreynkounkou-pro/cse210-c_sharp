using System;
using System.Formats.Asn1;

public class ReflectingActivity : Activity
{
  private List<string> _promptList = new List<string>
  {
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
  };

  private List<string> _questionsList = new List<string>
  {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
  };

  private int _timer;

  public ReflectingActivity(string activityName, string description) : base(activityName, description)
  {
    
  }

  public ReflectingActivity(int duration) : base(duration)
  {
    _timer = duration;

  }

  private Random random = new Random();
  
  private string GetRandomPrompt()
  {
    int _index = random.Next(0, _promptList.Count);

    return _promptList[_index];
  }

  private string GetRandomQuestion()
  {
    int _index = random.Next(0, _questionsList.Count);

    return _questionsList[_index];
  }

  private void DisplayQuestionPrompt()
  {
    DateTime StartTime = DateTime.Now;
    DateTime endTime = StartTime.AddSeconds(_timer);

    while (endTime > DateTime.Now)
    {
      Console.Write($"> {GetRandomQuestion()} ");
      PausingShowingSpinner();
      Console.WriteLine();
    }
    
  }

  public void DisplayPrompts()
  {
    Console.WriteLine("Consider the following prompt: ");
    Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
    Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
    Console.ReadLine();
    Console.WriteLine("Now ponder on each of the following questions as they related to this experience: ");
    Console.Write("You may begin in: ");
    PausingShowingCountDown();
    Console.WriteLine();
    DisplayQuestionPrompt();
  }

}