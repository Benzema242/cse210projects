public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true; // Set to true to hide the word
    }

    public void Show()
    {
        _isHidden = false; // Set to false to show the word
    }

    public bool IsHidden()
    {
        return _isHidden; // Return the current hidden state
    }
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length); // Return underscores for hidden words
        }

        return _text; // Return the actual text if not hidden
    }
}