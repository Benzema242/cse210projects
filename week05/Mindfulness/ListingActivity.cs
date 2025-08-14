using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private int _count = 0;
        private readonly List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base(
                "Listing",
                "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
            )
        { }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine();
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"> {GetRandomPrompt()}");

            Console.Write("\nYou may begin in: ");
            ShowCountDown(5);

            List<string> items = GetListFromUser();

            _count = items.Count;
            Console.WriteLine($"\nYou listed {_count} item(s).");

            DisplayEndingMessage();
        }

        public string GetRandomPrompt()
        {
            var rand = new Random();
            return _prompts[rand.Next(_prompts.Count)];
        }

        public List<string> GetListFromUser()
        {
            var responses = new List<string>();
            var end = DateTime.UtcNow.AddSeconds(Duration);

            Console.WriteLine("\nStart listing (press Enter after each item).");

            while (DateTime.UtcNow < end)
            {
                Console.Write("> ");
                string line = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(line))
                    responses.Add(line.Trim());
            }

            return responses;
        }

        private void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}