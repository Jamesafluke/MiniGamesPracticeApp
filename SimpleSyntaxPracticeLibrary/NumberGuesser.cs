using System;

namespace SimpleSyntaxPracticeLibrary
{
    public class NumberGuesser
    {
        private const int _initialRangeBottom = 0;

        public NumberGuesser()
        {

        }

        public void NumberGuesserApp()
        {

          Console.WriteLine("Number guesser!");

            Guess(GetTopRange());

        }

        public int GetTopRange()
        {
            //Get top range from user.
            int rangeTop;
            while (true)
            {
                string? userInput = "";
                Console.WriteLine("Between 0 and what number?");
                userInput = Console.ReadLine();

                if (Int32.TryParse(userInput, out rangeTop))
                {
                    Console.WriteLine(rangeTop);

                    Console.WriteLine($"rangeTop is {rangeTop}. rangeBottom is {_initialRangeBottom}.");
                    if (rangeTop > (_initialRangeBottom + 1))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That's dumb, choose a bigger range!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
            return rangeTop;
        }
        public void Guess(int rangeTop)
        {
            int rangeBottom = _initialRangeBottom;
            int numberOfGuesses = 0;


            Console.WriteLine("I'll start guessing. For each guess, type h, l, or y. (higher, lower, yes)");
            while (true)
            {

                numberOfGuesses++;

                Console.WriteLine($"rangeTop is {rangeTop}. rangeBottom is {rangeBottom}");
                int average = (rangeBottom + rangeTop) / 2;

                if ((rangeTop - rangeBottom) == 2)
                {
                    //I know what the number is.
                    Console.WriteLine($"Your number must be {average}! It took me {numberOfGuesses} tries to guess your number.");
                    break;
                }

                string? userInput = "";
                while (true)
                {
                    Console.WriteLine($"Is your number {average}?");
                    userInput = Console.ReadLine();
                    if (userInput == "y" || userInput == "Y" || userInput == "h" || userInput == "H" || userInput == "l" || userInput == "L") { break; }
                }

                if (userInput == "y" || userInput == "Y")
                {
                    string pluralTry = "tries";
                    if (numberOfGuesses < 2) { pluralTry = "try"; }
                    Console.WriteLine($"Hooray! Your number is {average}. It took me {numberOfGuesses} {pluralTry} to guess your number.");

                    break;
                }
                else if (userInput == "h" || userInput == "H")
                {
                    rangeBottom = average;
                }
                else if (userInput == "l" || userInput == "L")
                {
                    rangeTop = average;
                }
            }
        }

    }

}
