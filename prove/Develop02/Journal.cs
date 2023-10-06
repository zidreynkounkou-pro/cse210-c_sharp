using System;
using System.IO;
using System.Collections.Generic;

public class Journal {

  public string _save;
  public string _load;

  public List<Entry> entries = new List<Entry>();
  public void AddEntry(Entry entry)
  {
    entries.Add(entry);
  }
  public void DisplayAllEntries()
  {
    Console.WriteLine();
    foreach (Entry _allEntries in entries)
    {
      _allEntries.DisplayEnties();
    }
  }

  public void WritingFile()
  {
   
      using (StreamWriter _writer = new StreamWriter(_save, true))
    {
      foreach (Entry _file in entries)
      {
        _writer.WriteLine(_file.StoreEntries());
      }
    }

  }


  public void LoadingFile()
  {
    
    string[] _lines = System.IO.File.ReadAllLines(_load);
    foreach (string _line in _lines)
    {
      string[] _parts = _line.Split(" | ");
      string _date = _parts[0];
      string _prompt = _parts[1];
      string _response = _parts[2];

      Console.WriteLine($"{_date}\n{_prompt}\n{_response}");
      Console.WriteLine();
    }
  }

}