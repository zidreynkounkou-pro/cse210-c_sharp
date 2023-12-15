using System;

public class Runner
{
  private static List<string> menu = new List<string>(){"Sign Up", "Login", "Exit"};
  public static VariableExpense variable;
  public static FixedExpense fixedExpense;

   public static void Menu()
  {
    try
    {
      Annimations annimations = new Annimations();
    string option = "Las Vegas city";
    // Display menu
    while(option != "3")
    {
      Console.Write("Wait in...");
      annimations.PausingShowingCountDown();
      Console.Clear();
      Console.WriteLine("\nWelcome to the main menu!");
      for (int i = 0; i < menu.Count; i++)
      {
        Console.WriteLine($" {i + 1}. {menu[i]}");
      }
      annimations.PausingShowingSpinner();
      Console.Write("Choose an option: ");
      option = Console.ReadLine();
      switch(option)
      {
        case "1":
        annimations.PausingShowingSpinner();
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        User user = new User(name, email, password);
        annimations.PausingShowingSpinner();
        user.Register();
        break;

        case "2":
        annimations.PausingShowingSpinner();
        Console.Write("\nEnter your name: ");
        string userName = Console.ReadLine();
        Console.Write("Enter your password: ");
        string userPassword = Console.ReadLine();

        User.Login(userName, userPassword);
        break;

        case "3":
        Console.Write("Wait in...");
        annimations.PausingShowingCountDown();
        Console.Clear();
        Console.WriteLine("GoodBye!");
        break;
        default:
        Console.WriteLine("Invalid choice. Please, try again!");
        break;
      }
    }
    }
    catch(Exception e)
    {
      Console.WriteLine();
      Console.WriteLine(e.Message);
    }
    
  }

  public void UserOptions()
  {
    try
    {
      Console.Clear();
    string option = "No response.";
    while(option != "12")
    {
      Annimations annimations = new Annimations();
      Console.Write($"Wait in...");
      annimations.PausingShowingCountDown();
      Console.Clear();
      Console.WriteLine("\nWelcome to the Expense Tracker Software!");
      List<string> _menu = new List<string>(){"Add Expense","Get Total Variable Expense","Get Total Fixed Expense","Get Total Expense", "Get Expense By Category", "Remove Expense", "Set Budget", "Check Budget", "Generate Reports", "Save Expenses", "Load Expenses", "Exit"};
      for(int i = 0; i < _menu.Count; i++)
      {
        Console.WriteLine($" {i+1}. {_menu[i]}");
      }
      annimations.PausingShowingSpinner();
      Console.Write("Choose an option: ");
      option = Console.ReadLine();
      switch(option)
      {
        case "1":
        Console.WriteLine(" 1. Variable Expense");
        Console.WriteLine(" 2. Fixed Expense");
        annimations.PausingShowingSpinner();
        Console.Write("Choose an option: ");
        int opt = int.Parse(Console.ReadLine());
        if (opt == 1)
        {
          Console.Write("\nEnter a category: ");
          string category = Console.ReadLine().ToLower();
          Console.Write("Enter an amount for this category: ");
          double amount = double.Parse(Console.ReadLine());
          Console.Write("Add notes for this category: ");
          string notes = Console.ReadLine();
          string date = DateTime.Now.ToShortDateString();
          variable = new VariableExpense(date, amount, category, notes);

          annimations.PausingShowingSpinner();
          variable.AddExpense(variable);
           Console.WriteLine("Expense has been added!");
        }
        else if (opt == 2)
        {
          Console.Write("\nEnter a category: ");
          string category = Console.ReadLine().ToLower();
          Console.Write("Enter an amount for this category: ");
          double amount = double.Parse(Console.ReadLine());
          Console.Write("Add notes for this category: ");
          string notes = Console.ReadLine();
          string date = DateTime.Now.ToShortDateString();
          fixedExpense = new FixedExpense(date, amount, category, notes);

          annimations.PausingShowingSpinner();
          fixedExpense.AddExpense(fixedExpense);
           Console.WriteLine("Expense has been added!");
        }
        else 
        {
          Console.WriteLine($"Invalid option '{opt}'.");
        }
        break;

        case "2":
        annimations.PausingShowingSpinner();
        Console.WriteLine($"\nTotal Variable Expense: {variable.CalculateExpense()}");
        variable.RemoveVariablaExpense();
        Console.WriteLine("\nPress enter to continue!");
        Console.ReadLine();
        break;

        case "3":
        annimations.PausingShowingSpinner();
        Console.WriteLine($"\nTotal Fixed Expense: {fixedExpense.CalculateExpense()}");
        fixedExpense.RemoveFixedExpense();
        Console.WriteLine("\nPress enter to continue!");
        Console.ReadLine();
        break;

        case "4":
        annimations.PausingShowingSpinner();
        double totalExpense = Expense.GetTotalExpense();
        Console.WriteLine($"\nTotal Expense: {totalExpense} - (all categories included)");
        Console.WriteLine("\nPress enter to continue!");
        Console.ReadLine();
        break;

        case "5":
        Console.Write("Enter the category: ");
        string aCategory = Console.ReadLine().ToLower();
        double totalExpenseForCategory = Expense.GetExpenseByCategory(aCategory);
        annimations.PausingShowingSpinner();
        Console.WriteLine($"Total Expense in '{aCategory}': {totalExpenseForCategory}");
        Console.WriteLine("\nPress enter to continue!");
        Console.ReadLine();
        break;

        case "6":
        Console.Write("Enter the category: ");
        string removeCategory = Console.ReadLine().ToLower();
        Console.Write("Enter the amount: ");
        double removeAmount = double.Parse(Console.ReadLine());
        annimations.PausingShowingSpinner();
        Expense.RemoveExpense(removeCategory, removeAmount);
        break;

        case "7":
        annimations.PausingShowingSpinner();
        Budget.AdjustBudget();
        break;

        case "8":
        Console.WriteLine("\nEnter a category: ");
        string budgetCategory = Console.ReadLine().ToLower();
        Console.Write($"Enter the amount spent in '{budgetCategory}': ");
        double budgetAmount = double.Parse(Console.ReadLine());
        annimations.PausingShowingSpinner();
        Budget.CheckBudget(budgetAmount, budgetCategory);
        break;

        case "9":
        Console.Write("\nEnter the total expense: ");
        double reportTotalExpense = double.Parse(Console.ReadLine());
        Console.Write("Enter the budget: ");
        double reportBudget = double.Parse(Console.ReadLine());
        Console.WriteLine();
        annimations.PausingShowingSpinner();
        ReportGenerator.GenerateBudgetReport(reportTotalExpense, reportBudget);
        ReportGenerator.GenerateExpenseReport();
        ReportGenerator.RemoveReport();
        Console.WriteLine("\nPress enter to continue!");
        Console.ReadLine();
        break;

        case "10":
        annimations.PausingShowingSpinner();
        DataStorage.SaveExpenses();
        annimations.PausingShowingSpinner();
        break;

        case "11":
        annimations.PausingShowingSpinner();
        DataStorage.LoadExpenses();
        break;
      }            
    }
    }
    catch(Exception e)
    {
      Console.WriteLine();
      Console.WriteLine(e.Message);
    }
  }
}