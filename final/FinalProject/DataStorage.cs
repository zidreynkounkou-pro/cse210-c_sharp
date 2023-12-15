using System;

public class DataStorage : Expense
{
  public DataStorage(string date, double amount, string category, string notes) : base(date, amount, category, notes)
  {
  }

  public override double CalculateExpense()
  {
    return 0;
  }

  public static void SaveExpenses()
  {

    List<Expense> existingExpenses = LoadExpensesFromFile();
    // Combine existing expenses with new expenses to avoid duplication
    List<Expense> combineExpense = existingExpenses.Concat(_expenses).ToList();

    // Write the data into the data.csv file
    using(var writer = new StreamWriter("expense.csv", true))
    {
      foreach(var expense in combineExpense)
      {
        if (expense is VariableExpense)
        {
          writer.WriteLine($"{"variable"}|{expense._date}|{expense._amount}|{expense._category}|{expense._notes}");
        }
        else if (expense is FixedExpense)
        {
          writer.WriteLine($"{"Fixed"}|{expense._date}|{expense._amount}|{expense._category}|{expense._notes}");
        }
        
      }
    }
    Console.WriteLine("\nExpenses have been saved successfully!");
  }


  private static List<Expense> LoadExpensesFromFile()
  {
    List<Expense> existingExpenses = new List<Expense>();

    if(File.Exists("expense.csv"))
    { string [] lines = System.IO.File.ReadAllLines("expense.csv");
     
      foreach(var line in lines)
      {
        string [] fields = line.Split("|");
       if(fields.Length == 5  && fields[0] == "Variable")// Check if fields contains 4 elements and if it is a variable expense.
       {
         string date = fields[1];
         double amount = double.Parse(fields[2]);
         string category = fields[3];
         string notes = fields[4];
         // Create an Expense object and add it to the list
         existingExpenses.Add(new Expense(date, amount, category, notes));
         Runner.variable = new VariableExpense(date, amount, category, notes);
         Runner.variable.AddExpense(Runner.variable);
       }
       else if(fields.Length == 5  && fields[0] == "Fixed")// Check if fields contains 4 elements and if it is a fixed expense.
       {
         string date = fields[1];
         double amount = double.Parse(fields[2]);
         string category = fields[3];
         string notes = fields[4];
         // Create an Expense object and add it to the list
         existingExpenses.Add(new Expense(date, amount, category, notes));
         Runner.fixedExpense = new FixedExpense(date, amount, category, notes);
         Runner.fixedExpense.AddExpense(Runner.fixedExpense);
        }
      } 
    }
    return existingExpenses;
  }

  public static List<Expense> LoadExpenses()
  {
    List<Expense> loadedExpenses = LoadExpensesFromFile();
    Console.WriteLine("\nExpenses have been loaded successfully!");
    return loadedExpenses;
  }
}