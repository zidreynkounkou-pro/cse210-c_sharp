public class Market
{
 public string Name { get; set; }
 public string[] Items { get; set; }

public static void Example()
{
 List<Market> markets = new List<Market>
 {
 new Market { Name = "Emily's", Items = new string[] { "kiwi",
"cheery", "banana" } },
 new Market { Name = "Kim's", Items = new string[] { "melon",
"mango", "olive" } },
 new Market { Name = "Adam's", Items = new string[] { "kiwi",
"apple", "orange" } },
 };
 // Determine which market contains fruit names equal 'kiwi'
 IEnumerable<string> names = from market in markets
 where market.Items.Contains("kiwi")
 select market.Name;
 foreach (string name in names)
 {
 Console.WriteLine($"{name} market");
 }
 // This code produces the following output:
 //
 // Emily's market
 // Adam's market

}

    private static async Task ShowConsoleAnimation()
    {
    for (int i = 0; i < 20; i++)
    {
    Console.Write("| -");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    Console.Write("/ \\");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    Console.Write("- |");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    Console.Write("\\ /");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    }
    Console.WriteLine();
    }

    public async void A()
    {
      await ShowConsoleAnimation();
    }


}
