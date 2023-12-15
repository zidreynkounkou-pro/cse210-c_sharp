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
  private string _name;
  private string _email;
  //[Name("Password")]
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
            //string email = fields[1];
            string userPassword = fields[2];
            if (userName == name && userPassword == password)
            {
              Runner runner = new Runner();
              runner.UserOptions();
              isFound = true;
            }
          }
        }
      }
    }
    if (!isFound)     
    {
      Annimations annimation = new Annimations();
      annimation.PausingShowingSpinner();
      Console.WriteLine("Your name or password does not much. Try again, please!");
      Console.WriteLine("\nPress enter to continue!");
      Console.ReadLine();
    }
  }
}