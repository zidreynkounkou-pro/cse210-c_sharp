using System;

public class DataStorage : Expense
{
  private List<string> _saveData = new List<string>();
  public DataStorage(string date, double amount, string category, string notes) : base(date, amount, category, notes)
  {
  }

  public DataStorage(double extra, string note) : base(extra, note){}

  public override double CalculateExpense()
  {
    return 0;
  }


 /* public static void SaveData()
  {
    var dataList = new List<DataStorage>();

    // Check if the file exists.
    if (File.Exists("data.csv"))
    {
      using(StreamReader reader = new StreamReader("data.csv"))
      {
        string line;
        while((line = reader.ReadLine()) != null)
        {
          string[] fields = line.Split(",");
          if (fields.Length == 3) // Make sure that all the three fields exist
          {
            string date = fields[0];
            double amount = double.Parse(fields[1]);
            string category = fields[2];
            string notes = fields[3];
            // Add the data into the list
            dataList.Add(new DataStorage(date, amount, category, notes));
          }
        }
      }
    }
    // Add the new data into the list
    foreach(var expense in _expenses)
    {
      string _eDate = expense._date;
      double _eAmount = double.Parse(expense[1]);
      string _eCategory = expense[2];
      string _eNotes = expense[3];
      dataList.Add(new DataStorage(_eDate, _eAmount, _eCategory, _eNotes));
    }
    dataList.Add(new DataStorage(_data, _amount, _category, _notes));

    // Write the data into the data.csv file
    using(var writer = new StreamWriter("data.csv"))
    {
      foreach(var data in dataList)
      {
        writer.WriteLine($"{data._date},{data._amount},{data._category}, {data._notes}");
      }
    }
    Console.WriteLine("\nYour data have been stored successfully!");
  } */


  public static void LoadData()
  {
    
  }
}