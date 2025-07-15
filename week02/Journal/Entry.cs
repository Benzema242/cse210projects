public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    // Display() method to show the entry details    
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine();
    }

    // Helpers for load and save functions
    public string ToDataLine() => $"{_date}|{_promptText}|{_entryText}|{_mood}";
        
    public static Entry FromDataLine(string dataLine)
    {
        var parts = dataLine.Split('|');
        if (parts.Length != 4)
            throw new FormatException("Invalid data line format.");

        return new Entry(parts[0], parts[1], parts[2], parts[3]);
    }
        
}


