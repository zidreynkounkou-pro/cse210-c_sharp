using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

public class User
{
  [Name("Name")]
  private string _name;
  [Name("Email")]
  private string _email;
  [Name("Password")]
  private string _password;
  public User (string name, string email, string password)
  {
    _name = name;
    _email = email;
    _password = password;
  }

  public void Register()
  {
    var users = new List<User>();

    // Check if the file exists.
    if (File.Exists("user.csv"))
    {
      using(StreamReader reader = new StreamReader("user.csv"))
      {
        string line;
        while((line = reader.ReadLine()) != null)
        {
          string[] fields = line.Split(",");
          if (fields.Length == 3) // Make sure that all the three fields exist
          {
            string name = fields[0];
            string email = fields[1];
            string password = fields[2];
            // Add the credentials into the list
            users.Add(new User(name, email, password));
          }
        }
      }
    }
    // Add the new credentials into the list
    users.Add(new User(_name, _email, _password));

    // Write the credentials into the list
    using(var writer = new StreamWriter("user.csv"))
    {
      foreach(var user in users)
      {
        writer.WriteLine($"{user._name},{user._email},{user._password}");
      }
    }
    Console.WriteLine("\nYou have registered successfully!");
  }


  public static void Login(string name, string password)
  {
    bool isFound = false;
    if (!File.Exists("user.csv"))
    {
      Console.WriteLine("No users have registered yet.");
    }
     if (File.Exists("user.csv"))
    {
      using(StreamReader reader = new StreamReader("user.csv"))
      {
        string line;
        while((line = reader.ReadLine()) != null)
        {
          string[] fields = line.Split(",");
          if (fields.Length == 3)
          {
            string userName = fields[0];
            string email = fields[1];
            string userPassword = fields[2];
            if (userName == name && userPassword == password)
            {
              string option = "No response.";
              while(option != "10")
              {
                Console.WriteLine("\nWelcome to the Expense Tracker Software!");
                List<string> _menu = new List<string>(){"Add Expense","Get Total Expense", "Get Expense By Category", "Remove Expense", "Set Budget", "Check Budget", "Generate Reports", "Save Data", "Load Data", "Exit"};
                for(int i = 0; i < _menu.Count; i++)
                {
                  Console.WriteLine($" {i+1}. {_menu[i]}");
                }
                Console.Write("Enter an option: ");
                option = Console.ReadLine();
                switch(option)
                {
                  case "1":
                  Console.WriteLine(" 1. Variable Expense");
                  Console.WriteLine(" 2. Fixed Expense");
                  Console.WriteLine("Choose an option");
                  int opt = int.Parse(Console.ReadLine());
                  if (opt == 1)
                  {
                    Console.Write("\nEnter a category: ");
                    string category = Console.ReadLine();
                    Console.Write("\nEnter an amount for this category: ");
                    double amount = double.Parse(Console.ReadLine());
                    Console.Write("\nAdd notes for this category: ");
                    string notes = Console.ReadLine();
                    Console.Write("\nAdd the location: ");
                    string location = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    VariableExpense variable = new VariableExpense(date, amount, category, notes, "photo", location);
                    variable.AddExpense(variable);
                  }
                  else if (opt == 2)
                  {
                    Console.Write("\nEnter a category: ");
                    string category = Console.ReadLine();
                    Console.Write("\nEnter an amount for this category: ");
                    double amount = double.Parse(Console.ReadLine());
                    Console.Write("\nAdd notes for this category: ");
                    string notes = Console.ReadLine();
                    Console.Write("\nAdd the location: ");
                    //string location = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    FixedExpense fixedExpense = new FixedExpense(date, amount, category, notes);
                    fixedExpense.AddExpense(fixedExpense);
                  }
                  else 
                  {
                    Console.WriteLine($"Invalid option '{opt}'.");
                  }
                  
                  break;

                  case "2":
                  //Console.WriteLine("\nThe Total Expense is: ");
                  //VariableExpense.GetTotalExpense();
                 
                  double totalExpense = Expense.GetTotalExpense();
                  Console.WriteLine($"\nTotal Expense: {totalExpense} - (all categories included)");
                  break;

                  case "3":
                  Console.Write("Enter the category: ");
                  string aCategory = Console.ReadLine();
                  double totalExpenseForCategory = Expense.GetExpenseByCategory(aCategory);
                  Console.WriteLine($"Total Expense in '{aCategory}': {totalExpenseForCategory}");

                  break;
                  case "4":
                  Console.Write("Enter the category: ");
                  string removeCategory = Console.ReadLine();
                  Console.Write("Enter the amount: ");
                  double removeAmount = double.Parse(Console.ReadLine());
                  Expense.RemoveExpense(removeCategory, removeAmount);
                  break;

                  case "5":
                  Budget.AdjustBudget();
                  break;

                  case "6":
                  Console.WriteLine("\nEnter a category: ");
                  string budgetCategory = Console.ReadLine();
                  Console.Write($"Enter the amount spent in '{budgetCategory}': ");
                  double budgetAmount = double.Parse(Console.ReadLine());
                  Budget.CheckBudget(budgetAmount, budgetCategory);
                  break;

                  case "7":
                  break;

                  case "8":
                  ///DataStorage.SaveData();
                  break;

                  case "9":
                  DataStorage.LoadData();
                  break;

                  case "10":
                  break;
                }
                isFound = true;
              }
            }
          }
        }
      }
    }
    if (!isFound)     
    {
      Console.WriteLine("Your name or password does not much. Try again, please!");
    }
  }
}