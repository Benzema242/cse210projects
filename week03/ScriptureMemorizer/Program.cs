using System;

class Program
{
    // I have exceeded the program requirements by allowing the user to get a different scripture at random each time.

    static readonly List<(string reference, string text)> _scriptures = new()
    {
        ("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
        ("Philippians 4:13", "I can do all this through him who gives me strength."),
        ("Romans 8:28", "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."),
        ("Psalm 23:1", "The Lord is my shepherd, I lack nothing."),
        ("Isaiah 40:31", "But those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint."),
        ("1 Nephi 3:7", "Nevertheless, I know in whom I have trusted; my God has been my support; he has kept me from falling."),
        ("Alma 37:37", "Counsel with the Lord in all thy doings, and he will direct thee for good."),
        ("1 Nephi 11:17", "I know that he loveth his children; nevertheless, I do not know the meaning of all things."),
        ("Ether 12:27", "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me.")
    };
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        Random rnd = new Random();
        var reference = new Reference("John 3:16");
        int index = rnd.Next(_scriptures.Count);
        var chosen = _scriptures[index];

        var chosenReference = new Reference(chosen.reference);
        var scripture = new Scripture(chosenReference, chosen.text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have memorized the scripture!");
                break;
            }

            Console.WriteLine("Press ENTER to hide 3 or more words, or type 'quit' to exit.");

            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) &&
                input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

}
