using System;
using System.Reflection.Metadata;
using System.Collections.Generic; 
using System.Threading; 

namespace Mindfulness
{
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        protected int Duration => _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;

        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity. \n");
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How many seconds would you like to do this activity? ");

            _duration = ReadPositiveInt();
            Console.WriteLine("\nGet ready to begin...");
            ShowSpinner(5, true); // Show "Ready!" only here
        }

        public void DisplayEndingMessage()
        {
            
            
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds, bool showReady = false)
        {
            List<string> animationStrings = new List<string>();
            animationStrings.Add("|");
            animationStrings.Add("/");
            animationStrings.Add("-");
            animationStrings.Add("\\");
            animationStrings.Add("|");
            animationStrings.Add("/");
            animationStrings.Add("-");
            animationStrings.Add("\\");

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            int i = 0;

            while (DateTime.Now < endTime)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(500);
                Console.Write("\b \b");

                i++;

                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
            
            // Only show "Ready!" when showReady is true
            if (showReady)
            {
                Console.WriteLine("Ready!");
            }
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\rStarting in {i} seconds...");
                Thread.Sleep(1000);
            }
            Console.Write("\r    \r");
        }

        private int ReadPositiveInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int s) && s > 0)
                    return s;
                Console.WriteLine("Please enter a whole number greater than 0: ");
            }
        }
    }
}