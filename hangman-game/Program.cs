using System;
using System.Linq;

namespace hangman_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n- welcome to \"the hanging man\" -");
            Console.WriteLine("\npress any key to start the game");
            Console.WriteLine("press 0 to exit anytime during the game");
            Console.WriteLine("_______________________________________");
            Console.WriteLine();
            Console.ReadLine();

            var input = ' ';
            var amountGuesses = 0;
            var word = GetRandomWord();
            var rightGuess = new char[word.Length];

            Console.WriteLine("the word contains " + word.Length + " letters");
            Console.WriteLine("you have 15 guesses, enjoy!");
            while (input != '0' && ++amountGuesses < 15)
            {
                Console.Write("\nguess a letter: ");
                try
                {
                    input = char.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("wrong input, try again.");
                    continue;
                }
                bool isCorrect = false;
                for (var i = 0; i < word.Length; i++)
                {
                    if (input == word[i])
                    {
                        Console.WriteLine($"correct!");
                        Console.WriteLine($"the letter {input} is at position {i + 1}");
                        rightGuess[i] = input;
                        Console.WriteLine(rightGuess);
                        isCorrect = true;
                    }
                }
                if (word.SequenceEqual(rightGuess))
                {
                    Console.WriteLine("CONGRATS! you guessed the correct word.");
                    break;
                }
                else if (!isCorrect)
                {
                    Console.WriteLine("wrong!");
                }
            }
            Console.WriteLine("game over!");
            Console.ReadLine();
        }
        static string GetRandomWord()
        {
            string[] words = { "goat", "sleep", "summer", "lumberjack", "snowball", "chinese", "vagabond" , "sweden", "breathing", "zorro",
            "normal", "lemonpie", "toothpaste", "cat", "mixtape"};
            Random randomWord = new Random();
            return words[randomWord.Next(0, words.Length)];
        }
    }
}
