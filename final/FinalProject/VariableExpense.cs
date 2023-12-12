using System;

public class VariableExpense : Expense
{
  private List<double> _variableList = new List<double>();
  private string _receiptPhoto;
  private string _location;
  private double _extra;
  private string _note;
  private double _variableAmount;

  public VariableExpense (string date, double amount, string category, string notes, string receiptPhoto, string location) : base(date, amount, category, notes)
  {
    _receiptPhoto = receiptPhoto;
    _location = location;
  }

  public VariableExpense(double extra, string note) : base(extra, note)
  {
    _extra = extra;
    _note = note;
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
}