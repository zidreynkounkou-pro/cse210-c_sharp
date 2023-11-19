using System;
using System.Threading.Channels;

public class EternalGoal : Goal
{
  public EternalGoal(string goal, string goalDescription, float points) : base(goal, goalDescription, points)
  {
    WriteGoals($"{goal} ({goalDescription})", points);
  }

  

     public override void RecordEvent()
     {
      
     }
}