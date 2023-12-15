using System;

public class Expense
{
  protected static List<Expense> _expenses = new List<Expense>();
  public string _date;
  public double _amount;
  public string _category;
  public string _notes;
 
  public Expense(string date, double amount, string category, string notes) 
  {
    _date = date;
    _amount = amount;
    _category = category;
    _notes = notes;
  }

  public virtual double CalculateExpense()
  {
    return _amount;
  }

 
  
  public void AddExpense(Expense expense)
  {
    _expenses.Add(expense);
  }

  public static void RemoveExpense(string category, double amount)
  {
    Expense expenseToRemove = _expenses.FirstOrDefault(expense => expense._category == category && expense._amount == amount);

    if (expenseToRemove != null)
    {
      _expenses.Remove(expenseToRemove);
      Console.WriteLine($"Expense in category '{category}' removed successfully.");
    }
    else
    {
      Console.WriteLine($"No expense found in category '{category}'.");
    }
  }

  public static double GetTotalExpense()
  {
    return _expenses.Sum(expense => expense._amount);
  }


  public static double GetExpenseByCategory(string category)
  {
    List<Expense> expensesInCategory = _expenses.Where(expense => expense._category == category).ToList();


    Console.WriteLine($"\nCategory: {category}");
    foreach (Expense expense in expensesInCategory)
    {
      Console.WriteLine($"Amount for {category}: {expense._amount} - {expense._date} ({expense._notes})");
    }

    Console.WriteLine();
    double totalExpenseInCategory = expensesInCategory.Sum(expense => expense._amount);

    //Call the CheckBudget() method and pass its values
    Budget.CheckBudget(totalExpenseInCategory, category);
    return totalExpenseInCategory;
  }
}
