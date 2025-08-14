using System;
// I have exceeded requirements for this task by adding celebration animation on completing
// a goal, or earning a bonus.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}