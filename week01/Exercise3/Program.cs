using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        // For the sake of time and already late on submission i won't me doing the stretch challenges here
        //  but i will practice them later.

    
        //Console.Write("What is the magic number?  ");
        Random randomGenerator  = new Random();
        int magicNumber = randomGenerator.Next(1, 100); // Generate a random number between 1 and 100

        int guess = -1;

        while (guess != magicNumber)  // Loop until the guess is correct
        {
            Console.Write("Guess the magic number: ");
            string guessInput = Console.ReadLine();
            guess = int.Parse(guessInput);


            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congratulations! You guessed it!");
            }

        }
    }
}