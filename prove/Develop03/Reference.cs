using System;
public class Reference
{
    private string _bookAndVerses;
   

    public Reference(string text)
    {
        _bookAndVerses = text;
    }

    public string ScriptureRef()
    {
        return _bookAndVerses;
    }

}