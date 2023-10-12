using System;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string words = "bonjour comment vas-tu?. Ca va et toi?";

        int ranIndex = random.Next(0, words.Length);
        char word = words[ranIndex];
        
        string quit = "";
        while (quit != "quit")
        {
            

            foreach (char w in words)
             {
                if(word.Equals(w))
                {
                    words.Replace(w, '_');
                    Console.WriteLine(words);
                    quit = Console.ReadLine();
                    break;
                    
                }
                
                
             }
        }
        

        
        

    }
    
}