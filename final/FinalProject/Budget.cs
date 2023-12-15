using System;

public class Budget
{
  private static List<Budget> _budget = new List<Budget>{};
  private string _aCategory;
  private double _anAmount;

  private static void AddBudget(double budgetAmount, string budgetCategory)
  {
    _budget.Add(new Budget{_anAmount = budgetAmount, _aCategory = budgetCategory});
  }

  
  public static void AdjustBudget()
  {
    Console.WriteLine("\nAdgust your budget here. Enter 'exit' when you finish.");
    string setBudget = "exacT";
    while(setBudget != "exit")
    {
      Console.Write("\nEnter a category: ");
      setBudget = Console.ReadLine().ToLower();
      if (setBudget != "exit")
      {
        Console.Write($"Enter the amount for the '{setBudget}' category:");
        double itsAmount = double.Parse(Console.ReadLine());
        AddBudget(itsAmount, setBudget);
        Console.WriteLine($"Your budget in '{setBudget}' has been set successfully.");
      }
    }
  }
  public static void CheckBudget(double amount, string category)
  {
    IEnumerable<double> budgetAmount = from checkBudgetCategory in _budget
    where checkBudgetCategory._aCategory.Contains(category)
    select checkBudgetCategory._anAmount;

    foreach(double anAmount in budgetAmount)
    {
      if (anAmount == amount)
      {
        Console.WriteLine($"You have reached the budget in '{category}' category.\nYour budget in '{category}' is: {anAmount}");
      }
      else if (anAmount < amount)
      {
        Console.WriteLine($"You are out of the budget in '{category}' category.\nYour budget in '{category}' is: {anAmount}");
      }
      else if (anAmount > amount)
      {
        Console.WriteLine($"You are steel within the budget in '{category}' category.\nYour budget in '{category}' is: {anAmount}");
      }
    }
  }
}