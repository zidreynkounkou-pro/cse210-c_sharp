using System;

public class PromptGenerator 
{
  public static Random random = new Random();

  // List of prompts.
  private static List<string> _prompts = new List<string>()
  {

    "Who was the most interesting person I interacted with today?",
    "What was the best part of my day?",
    "How did I see the hand of the Lord in my life today?",
    "What was the strongest emotion I felt today?",
    "If I had one thing I could do over today what would it be?",
    "What did I learn today?",
    "Did I reach out my goals today?",
    "What is the charity act did I today?",
    "Do I think I need to do better than I did today?"

  };

  // Generating random prompt.
  public static string RandomPrompt()
  {
    int _randomIndext = random.Next(0, _prompts.Count);
    return _prompts[_randomIndext];
  }
}
