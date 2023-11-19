using System;
using System.Globalization;
using System.Threading.Channels;
public class ChecklistGoal : Goal
{
  
  public ChecklistGoal(string goal, string goalDescription, float points, int numbOfTime, float bonus) : base(goal, goalDescription, points)
  {

    _checklist.Add($"{goal} ({goalDescription})|{points}|{bonus}|{numbOfTime}");
    WriteGoals($"{goal} ({goalDescription})", points);
  }

  //public void BonusAndTimes()


     public override void RecordEvent()
     {
      
     }
}