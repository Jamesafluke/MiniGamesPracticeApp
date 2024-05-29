using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSyntaxPracticeLibrary
{
    public class DiceGame
    {
        public DiceGame()
        {
            
        }

        public void DiceGameApp()
        {
            while (true)
            {
                Console.WriteLine("Welcome to dice game.");
                int numberOfSides = GetNumberOfSides();
                int? seed = GetSeed();

                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(RollDice(numberOfSides, seed));
                }
            }
        }

        private int? GetSeed()
        {

            Console.WriteLine("Want to specify a seed? y/n");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y") { return GetPositiveIntFromUser(); }
                else if (userInput == "n" || userInput == "N") { return null; }
                else { Console.WriteLine("Try again. Want to specify a seed? y/n"); }
            }
        }

        private int GetNumberOfSides()
        {
            Console.WriteLine("Want to set number of sides? Default is 6. Enter a number or n y/n");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y") { return GetPositiveIntFromUser(); }
                else if (userInput == "n" || userInput == "N") { Console.WriteLine("Defaulting to 6 sides."); return 6; }
                else { Console.WriteLine("Try again."); }
            }
        }

        private int GetPositiveIntFromUser()
        {
            Console.WriteLine("Enter a positive int.");
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int numberOfSides))
                {
                    if (numberOfSides > 0) { return numberOfSides; }
                    else { Console.WriteLine("Give a number greater than 0."); }
                }
                else
                {
                    Console.WriteLine("Try again. Enter a positive int.");
                }
            }
        }

        public int RollDice(int numberOfSides, int? seed = null)
        {
            Random rnd = new Random();
            if (seed == null)
            { 
                rnd = new Random();
            }
            else 
            {
                rnd = new Random((int)seed);

            }
            return rnd.Next(0, numberOfSides);
        }
    }
}
