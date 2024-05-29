using System;
using SimpleSyntaxPracticeLibrary;

class SimpleSyntaxPracticeApp
{
    static void Main()
    {
        string userInput;

        Dictionary<string, string> games = new Dictionary<string, string>();

        games.Add("n", "NumberGuesser");
        games.Add("d", "DiceGame");
        games.Add("c", "CoinFlip");

        Console.WriteLine("Pick a game!");

        foreach (KeyValuePair<string, string> kvp in games)
        {
            Console.WriteLine($"{kvp.Key} for {kvp.Value}");
        }
        Console.WriteLine("exit to exit");

        while(true)
        {
            userInput = Console.ReadLine();

            if (userInput == "exit" || userInput == "Exit")
            {
                Environment.Exit(0);
            }

            bool validInput = false;
            //Validate input.
            foreach (KeyValuePair<string, string> kvp in games)
            {
                if(userInput == kvp.Key)
                {
                    validInput = true;
                }
            }
            if (validInput) { break; } else { Console.WriteLine("Try again dummy"); }
        }

        switch (userInput)
        {
            case "n":
                NumberGuesser numberGuesser = new NumberGuesser();
                numberGuesser.NumberGuesserApp();
                break;
            case "d":
                DiceGame diceGame = new DiceGame();
                diceGame.DiceGameApp();

                break;
            case "c":
                CoinFlip coinFlip = new CoinFlip();
                coinFlip.CoinFlipApp();
                break;
        }
    }
}







