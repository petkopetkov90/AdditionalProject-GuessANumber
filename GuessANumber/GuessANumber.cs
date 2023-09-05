using System;

namespace GuessANumber
{
    internal class GuessANumber
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int numberLevel = 101;
            int computerNumber = randomNumber.Next(1, numberLevel);

            Console.WriteLine("Welcome to game \"Gues A Number\".");
            Console.Write($"Guess a number between 1 and {numberLevel - 1}: ");
            int level = 1;
            int totalTurns = 0;
            int turns = 0;

            while (true)
            {
                string playerInput = Console.ReadLine();
                bool isValid = int.TryParse(playerInput, out int playerNumber);

                if (!isValid)
                {
                    Console.WriteLine("Is not a number.");
                    Console.Write("Please choose a number: ");
                    continue;
                }

                if (playerNumber < 1 || playerNumber > numberLevel)
                {
                    Console.WriteLine("Number out of range.");
                    Console.Write("Please try with other number: ");
                    continue;
                }

                if (playerNumber < computerNumber)
                {
                    Console.WriteLine("Number is too low.");
                    Console.Write("Try again: ");
                    turns++;
                    continue;
                }
                else if (playerNumber > computerNumber)
                {
                    Console.WriteLine("Number is too high.");
                    Console.Write("Try again: ");
                    turns++;
                    continue;
                }
                else
                {
                    turns++;
                    Console.WriteLine($"You guessed it in {turns} turns.");
                    level++;
                    totalTurns += turns;
                    turns = 0;

                    if (level > 10)
                    {
                        while (true)
                        {
                            Console.WriteLine($"Congratulations you win the game.");
                            Console.WriteLine($"You win {level - 1} levels in {totalTurns} turns.");
                            Console.WriteLine("Thank you for playing!");
                            Console.Write("Choose [y]es for new game or [n]o to quit: ");
                            string yesOrNo = Console.ReadLine().ToLower();
                            if (yesOrNo == "yes" || yesOrNo == "y")
                            {
                                numberLevel = 101;
                                level = 1;
                                totalTurns = 0;
                                computerNumber = randomNumber.Next(1, numberLevel);
                                Console.Write($"Guess a number between 1 and {numberLevel - 1}: ");
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations you have reached a level {level}.");

                        Console.Write("Choose [y]es to continue or [n]o to quit: ");
                        string continueOrNo = Console.ReadLine().ToLower();

                        if (continueOrNo == "yes" || continueOrNo == "y")
                        {
                            numberLevel += 100;
                            computerNumber = randomNumber.Next(1, numberLevel);
                            Console.WriteLine($"Welcome ot level {level}.");
                            Console.Write($"Guess a number between 1 and {numberLevel - 1}: ");
                        }
                        else
                        {
                            Console.WriteLine($"You quit on level {level} after {totalTurns} turns.");
                            Console.WriteLine("Thank you for playing!");
                            break;
                        }
                    }
                }
            }
        }
    }
}