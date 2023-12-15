using System;

public class FixedExpense : Expense
{
  private List<double> _fixedList = new List<double>();
  
  public FixedExpense(string date, double amount, string category, string notes) : base(date, amount, category, notes)
  {
  }

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

  public void RemoveFixedExpense()
  {
    _fixedList.RemoveRange(0, _fixedList.Count);
  }
}