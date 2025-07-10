using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        {
            DisplayWelcome();

            string userName = PromptUserName();
            int favoriteNumber = PromptUserFavoriteNumber();
            int squaredNumber = SquareNumber(favoriteNumber);

            DisplayResults(userName, squaredNumber);

        }
        static void DisplayWelcome()
        {
            Console.Write("Welcome to the program!");
        }
        static string PromptUserName()
        {
            Console.Write(" Please enter your name: ");
            return Console.ReadLine();
        }
        static int PromptUserFavoriteNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            return number;
        }
        static int SquareNumber(int number)
        {
            return number * number;
        }

        static void DisplayResults(string userName, int squaredNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {squaredNumber}.");
        }
    }
}    