using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the Exercise1 Project.");
            Console.WriteLine("This project is part of the C# Fundamentals course.");

            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine();

            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine($"Your name  is {lastName}, {firstName} {lastName}.");

        }
    }
}