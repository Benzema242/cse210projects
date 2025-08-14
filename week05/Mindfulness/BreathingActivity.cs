using System;


namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax and focus on your breathing.")
        { }
        
        public void Run()
        {
            DisplayStartingMessage();

            int remaining = Duration;
            bool inhale = true;

            while (remaining > 0)
            {
                if (inhale)
                {
                    Console.WriteLine("Now breathe in...");
                    int step = Math.Min(4, remaining);
                    ShowCountDown(step); 
                    remaining -= step;
                }
                else
                {
                    Console.WriteLine("Now breathe out...");
                    int step = Math.Min(4, remaining);
                    ShowCountDown(step);
                    remaining -= step;
                }
                inhale = !inhale;
            }
            
            DisplayEndingMessage(); 
        }
    }
}