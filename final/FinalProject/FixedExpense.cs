using System;

public class FixedExpense : Expense
{
  //private string _recurringFrenquency;
  //private DateTime _nextDueDate;
  private List<double> _fixedList = new List<double>();
  
  public FixedExpense(string date, double amount, string category, string notes/*, DateTime nextDueDate, string recurringFrenquency*/) : base(date, amount, category, notes)
  {
    //_recurringFrenquency = recurringFrenquency;
    //_nextDueDate = nextDueDate;
  }
  public FixedExpense(double extra, string note) : base(extra, note){}

  public override double CalculateExpense()
  {
    foreach(var ex in _expenses)
    {
      if(ex is FixedExpense vE)
      {
        double varEx = vE._amount;
        _fixedList.Add(varEx);
      }
    }
    return _fixedList.Sum();
  }
}