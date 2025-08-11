using System;
using Homework;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        MathAssignment mathAssignment = new MathAssignment(
            "Roberto Rodriguez",
            "Fractions",
            "7.3",
            "1-20"
        );

        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
    }
}