using System;

public class Runner
{
  private static List<string> menu = new List<string>(){"Sign Up", "Login", "Exit"};

   public static void Menu()
  {
    string option = "Las Vegas city";
    // Display menu
    while(option != "3")
    {
      Console.WriteLine("\nWelcome to the main menu!");
      for (int i = 0; i < menu.Count; i++)
      {
        Console.WriteLine($" {i + 1}. {menu[i]}");
      }
      Console.Write("Choose an option:");
      option = Console.ReadLine();
      switch(option)
      {
        case "1":
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();
        Console.Write("\nEnter your email: ");
        string email = Console.ReadLine();
        Console.Write("\nEnter your password: ");
        string password = Console.ReadLine();
        User user = new User(name, email, password);
        user.Register();
        break;

        case "2":
        Console.Write("\nEnter your name: ");
        string userName = Console.ReadLine();
        Console.Write("\nEnter your password: ");
        string userPassword = Console.ReadLine();
        User.Login(userName, userPassword);
        break;

        case "3":
        Console.WriteLine("\nGoodBye!");
        break;
        default:
        Console.WriteLine("Invalid choice. Please, try again!");
        break;
      }
    }
  }
}