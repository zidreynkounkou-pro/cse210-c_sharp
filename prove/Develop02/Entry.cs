using System;

public class Entry
{

  public string _prompt{get; set;}
  public string _response {get; set;}
  public  string _date {get; set;}

  public Entry(string date, string prompt, string response)
  {
    _date = date;
    _prompt = prompt;
    _response = response;
  }

  public string StoreEntries()
  {
    string _storeDate = _date;
    string _storePrompt = _prompt;
    string _storeResponse = _response;
    
    return $"Date: {_storeDate} | Prompt: {_storePrompt} | Response: {_storeResponse}";

  }

  public void DisplayEnties()
  {
    Console.WriteLine($"Date: {_date}"); 
    Console.WriteLine($"Prompt: {_prompt}");
    Console.WriteLine($"Response: {_response}");
    Console.WriteLine();
  }
}