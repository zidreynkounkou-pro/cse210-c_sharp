using System;

public class BreathingActivity : Activity {

  private string _breathIn;
  private string _breathOut;
  
  private int _timer;

  public BreathingActivity(string activityName, string description) : base(activityName, description)
  {
   
  }

  public BreathingActivity(int breathInDuration, string breathIn, string breathOut, string activityName, string description) : base(activityName, description)
  {
    _breathIn = breathIn;
    _breathOut = breathOut;
    _timer = breathInDuration;
  }
  
  public void BreathInAndBreathOut()
  {
    DateTime StartTime = DateTime.Now;
    DateTime endTime = StartTime.AddSeconds(_timer);

    PausingShowingSpinner();

    while (endTime > DateTime.Now)
    {
      Console.Write(_breathIn);
      PausingShowingCountDown();
      Console.WriteLine();
      Console.Write(_breathOut);
      PausingShowingCountDown();
      Console.WriteLine("\n");
    }
  }
}