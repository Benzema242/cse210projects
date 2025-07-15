public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()

    {
        _random = new Random();
        _prompts = new List<string>
        {
            "What are you grateful for today?",
            "Describe a memorable event from your past.",
            "What are your goals for the future?",
            "What is something you learned recently?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }
}

