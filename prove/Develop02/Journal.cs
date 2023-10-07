using System;
using System.IO;
using System.Collections.Generic;

public class Journal {

  public string _save;
  public string _load;
  public string _format;
  public string _loadFormat;
  public string _ex;

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
      // I decided to write the file with wether .csv or .text formats according to the user's need.
      using (StreamWriter _writer = new StreamWriter(_save + "."+ _format, true))
    {
      foreach (Entry _file in entries)
      {
        _writer.WriteLine(_file.StoreEntries());
      }
    }
  }


  public void LoadingFile()
  {
    try // Handling Exceptions
    {
      string[] _lines = System.IO.File.ReadAllLines(_load + "." + _loadFormat);
    
    
      Console.WriteLine("Your entries are:\n");

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

    catch (NotSupportedException)
    {
      Console.WriteLine($"The format '.{_loadFormat}'not supported.");
      Console.WriteLine();
    }
    catch (FileNotFoundException)
    {
      Console.WriteLine($"The file '{_load + '.' + _loadFormat}' not found. Check your file name and format, then try again.");
      Console.WriteLine();
    }
    catch (DirectoryNotFoundException)
    {
      Console.WriteLine($"The file '{_load + '.' + _loadFormat}' directory not found.");
      Console.WriteLine();
    }
    catch(IOException e)
    {
      Console.WriteLine(e);
      Console.WriteLine();
    }
  }

  public string HandlingFormatException()
  {
    return _ex;
  }
}
