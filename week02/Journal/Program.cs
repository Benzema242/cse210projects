using System;
/*
    I have exceeded the requirements by adding an extra feature that allows the user to describe their mood for the day.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        // Initialize the journal and prompt generator
        Journal journal = new Journal { _entries = new List<Entry>() };
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to file");
            Console.WriteLine("4. Load the journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1–5): ");


            switch (Console.ReadLine())
            {
                case "1":
                    // Write a new entry
                    WriteEntry(journal, promptGenerator);
                    break;
                case "2":
                    // Display the journal
                    journal.DisplayAll();
                    break;
                case "3":
                    // Save the journal to file
                    Console.Write("Filename to save to: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;
                case "4":
                    // Load the journal from file
                    Console.Write("Filename to load from: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;
                case "5":
                    // Quit
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }

        Console.WriteLine("Thank you for using the Journal Project. Goodbye!");
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your entry: ");
        string entryText = Console.ReadLine();

        Console.Write("How would you describe your mood today? ");
        string mood = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        journal.AddEntry(new Entry(date, prompt, entryText, mood));
        Console.WriteLine("Entry added successfully.");
    }
}