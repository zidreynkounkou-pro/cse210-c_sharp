using  System;
using System.Linq;

public class ReportGenerator : Expense
{
  public ReportGenerator(string date, double amount, string category, string notes) : base(date, amount, category, notes){}
  private static List<string> _generateReports = new List<string>();

  public static void GenerateBudgetReport(double totalExpense, double budget)
  {
    string report = totalExpense <= budget ? "Within budget!" : "Exceeded budget!";
    _generateReports.Add("Budget Report: " + report);
  }

  public static void GenerateExpenseReport()
  {
    if (_expenses != null && _generateReports != null)
    {
      _generateReports.Add("Expense Report: " + string.Join(", ", _expenses.Select(ex => ex._amount)));

      foreach(var report in _generateReports)
      {
        Console.WriteLine(report);
      }
    }
    else{
      Console.WriteLine("Sorry, cannot generate report because, you have not added any expense yet.");
    }
  }

  public static void RemoveReport()
  {
    _generateReports.RemoveRange(0,  _generateReports.Count);
  }

  
}