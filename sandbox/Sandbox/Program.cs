using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Sandbox Project.");

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

            //foreach (string s in animationStrings)
            //{
            //    Console.Write(s);
            //    Thread.Sleep(500);
            //    Console.Write("\b \b");
            //}

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(10);

            int i = 0;

            while (DateTime.Now < endTime)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                i++;

                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
            Console.Write("Done");
        }
    }
}