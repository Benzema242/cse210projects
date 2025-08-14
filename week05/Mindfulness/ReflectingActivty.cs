using System;
using System.Collections.Generic;


namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private int questionsIndex = 0;
        private readonly List<string> _prompts = new List<string>
        {
            "--- Think of a time when you stood up for someone else. ---",
            "--- Think of a time when you did something really difficult. ---",
            "--- Think of a time when you helped someone in need. ---",
            "--- Think of a time when you felt proud of yourself. ---",
            "--- Think of a time when you learned something new about yourself. ---",
            "--- Think of a time when you overcame a challenge. ---",
            "--- Think of a time you did something truly selfless. ---",
        };

        private readonly List<string> _questions = new List<string>
        {
            "What did you learn about yourself from this experience?",
            "Have you ever had a similar experience before?",
            "How did this experience change your perspective?",
            "What would you do differently if you faced this situation again?",
            "How did this experience affect your relationships with others?",
            "What emotions did you feel during this experience?",
            "How can you apply what you learned from this experience in the future?",
        };

        public ReflectingActivity()
         : base(
                "Reflecting",
                "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
                "This will help you recognize the power you have and how you can use it in other aspects of your life.")
        { }

        public void Run()
        {
            DisplayStartingMessage();
            DisplayPrompt();
            DisplayQuestions();
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            var rand = new Random();
            return _prompts[rand.Next(_prompts.Count)];
        }

        private string GetRandomQuestion()
        {
            var rand = new Random();
            return _questions[rand.Next(_questions.Count)];
        }

        private void DisplayPrompt()
        {
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($"{GetRandomPrompt()}");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue...");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Now ponder on the following questions as you reflect on this experience.");
            Console.WriteLine($"{GetRandomQuestion()}");
            Console.WriteLine();
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.Clear();
        }

        private void DisplayQuestions()
        {
            var endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine($"> {GetRandomQuestion()}");
                ShowSpinner(Math.Min(8, (int)(endTime - DateTime.Now).TotalSeconds));

                Console.WriteLine("Press Enter to continue to the next question or press 0 to go to the main menu.");
                var input = Console.ReadLine();

                if (input == "0")
                {
                    return;
                }
                questionsIndex++;

                if (questionsIndex < _questions.Count && DateTime.Now < endTime)
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("You have answered all the questions or time is up.");
                }
            }
            if (questionsIndex >= _questions.Count)
            {
                Console.WriteLine("You have reflected on all questions.");
    }
            else
            {
                Console.WriteLine("Time is up for this activity.");
            }
        }
    }
}
