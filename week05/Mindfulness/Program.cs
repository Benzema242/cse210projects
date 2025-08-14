using System;
using Mindfulness;

/* I have excceded requirements by adding user control on reflecting activity questions.
/*And. the ability to end activity early by pressing "0".
*/
class Program
{
    static void Main(string[] args)

    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        {
            while (true)
            {
                Console.WriteLine("Please select an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new BreathingActivity().Run();
                        PauseAndReturn();
                        break;
                    case "2":
                        new ReflectingActivity().Run();
                        PauseAndReturn();
                        break;
                    case "3":
                        new ListingActivity().Run();
                        PauseAndReturn();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Please enter a number 1 - 4.");
                        PauseAndReturn();
                        break;
                }
            }
        }
    }
    static void PauseAndReturn()
    {
        Console.WriteLine("\nPress Enter to return to the main menu...");
        Console.ReadLine();
        Console.Clear();
    }
}