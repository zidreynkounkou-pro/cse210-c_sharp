public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text, bool hidden = false)
    {
        _text = text;
        _hidden = hidden;
    }

    public string GetRenderedText()
    {
        return _text;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Hide(bool hidden)
    {
        _hidden = hidden;
    }
    
}