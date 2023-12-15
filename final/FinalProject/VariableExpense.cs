using System;

public class VariableExpense : Expense
{
  private List<double> _variableList = new List<double>();

  public VariableExpense (string date, double amount, string category, string notes) : base(date, amount, category, notes)
  {
  }
  public override double CalculateExpense()
  {

    foreach(var ex in _expenses)
    {
      if(ex is VariableExpense vrE)
      {
        double varExAmount = vrE._amount;
        _variableList.Add(varExAmount);
      }
    }
    return _variableList.Sum();
  }

  public void RemoveVariablaExpense()
  {
    _variableList.RemoveRange(0, _variableList.Count);
  }
}