using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(string reference, string scripture)
    {
        InitializeScripture(reference, scripture, string.Empty);
    }

    public Scripture(string reference, string scripture, string endverse)
    {
        InitializeScripture(reference, scripture, endverse);
    }

    private void InitializeScripture(string reference, string scripture, string endverse)
    {
        _reference = new Reference(reference);
        string fullScripture = $"{scripture} {endverse}";
        _words = fullScripture.Split(" ").Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{_reference.ScriptureRef()}\n");

        foreach (var word in _words)
        {
            if (word.IsHidden())
            {
                Console.Write("_____");
            }
            else
            {
                Console.Write($"{word.GetRenderedText()} ");
            }
        }

        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 10); // Hide random words from 1 to 9.

        for (int i = 0; i < wordsToHide; i++)
        {
            List<Word> wordsToSee = _words.Where(word => !word.IsHidden()).ToList(); // Execeeding requirements.
            if (wordsToSee.Count == 0)
                break;

            int randomIndex = random.Next(wordsToSee.Count);
            wordsToSee[randomIndex].Hide(true);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
