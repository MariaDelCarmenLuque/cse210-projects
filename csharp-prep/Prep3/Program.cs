using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while(playAgain.ToLower() == "yes")
        { 
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 51);
            int guessNumber = 0;
        

            while(guessNumber != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guess=Console.ReadLine();
                guessNumber = int.Parse(guess);

                if (magicNumber> guessNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber<guessNumber) 
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guesses it!");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
    }
}