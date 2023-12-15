using System;

public class Annimations
{
  private List<string> _spinnerList = new List<string>{"\\", "|", "/", "—", "\\", "|", "/", "—", "\\", "|", "/", "—", "\\", "|", "/"};

  public void PausingShowingCountDown()
  {
    DateTime  startime = DateTime.Now;
    DateTime endTime = startime.AddSeconds(0.75);
    while (endTime > DateTime.Now)
    {
       for (var i = 5; i > 0; i--)
      {
        Console.Write(i);
        Thread.Sleep(750);
        Console.Write("\b \b");
      }
    }
  }

  public void PausingShowingSpinner()
  {
    DateTime  startime = DateTime.Now;
    DateTime endTime = startime.AddSeconds(0.5);
    while (endTime > DateTime.Now)
    {
       foreach (var spinner in _spinnerList)
      {
        Console.Write(spinner);
        Thread.Sleep(100);
        Console.Write("\b \b");
      }
    } 
  }
}