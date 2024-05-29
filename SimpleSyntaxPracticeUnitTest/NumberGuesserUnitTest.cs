using System.ComponentModel;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using SimpleSyntaxPracticeLibrary;

namespace SimpleSyntaxPracticeUnitTest
{
    [TestClass]
    public class NumberGuesserUnitTest
    {
        [TestMethod]
        public void GetTopRangeTest()
        {
            int result = 0;
            StringReader? input = null;
            StringWriter? output = null;
            NumberGuesser numberGuesser = new NumberGuesser();
           

            input = new StringReader("100");
            Console.SetIn(input);
            result = numberGuesser.GetTopRange();
            Assert.AreEqual(100, result);

            string maxInt = Int32.MaxValue.ToString();
            input = new StringReader(maxInt);
            Console.SetIn(input);
            result = numberGuesser.GetTopRange();
            Assert.AreEqual(Int32.MaxValue, result);

            //Minimum good value: 2
            input = new StringReader("2");
            Console.SetIn(input);
            result = numberGuesser.GetTopRange();
            Assert.AreEqual(2, result);


            //One below minimum: 0
            output = new StringWriter();
            input = new StringReader("0\n2");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.GetTopRange();
            Assert.IsTrue(output.ToString().Contains("That's dumb, choose a bigger range!"));


            //Really big negative
            output = new StringWriter();
            string negativeMaxInt = "-" + Int32.MaxValue.ToString();
            input = new StringReader($"{negativeMaxInt}\n2");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.GetTopRange();
            Assert.IsTrue(output.ToString().Contains("That's dumb, choose a bigger range!"));

            //Stings
            output = new StringWriter();
            string testString = "Doink";
            input = new StringReader($"{testString}\n2");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.GetTopRange();
            Assert.IsTrue(output.ToString().Contains("Please enter a number."));


            //Empty string
            output = new StringWriter();
            string emptyString = "";
            input = new StringReader($"{emptyString}\n2");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.GetTopRange();
            Assert.IsTrue(output.ToString().Contains("Please enter a number."));

            // 2q
            output = new StringWriter();
            string mixedString = "as3df";
            input = new StringReader($"{mixedString}\n2");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.GetTopRange();
            Assert.IsTrue(output.ToString().Contains("Please enter a number."));

            // null
            output = new StringWriter();
            string? nullString = null;
            input = new StringReader($"{nullString}\n2");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.GetTopRange();
            Assert.IsTrue(output.ToString().Contains("Please enter a number."));

        }


        [TestMethod]
        public void GuessTest()
        {
            StringReader? input = null;
            StringWriter? output = null;
            NumberGuesser numberGuesser = new NumberGuesser();

            // h h h h h h
            // Your number must be 99! It took me 7 tries to guess your number.
            output = new StringWriter();
            input = new StringReader("h\nh\nh\nh\nh\nh\n");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.Guess(100);
            Assert.IsTrue(output.ToString().Contains("Your number must be 99! It took me 7 tries to guess your number."));

            
            output = new StringWriter();
            input = new StringReader("l\nh\nl\nh\nl\nh\n");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.Guess(100);
            Assert.IsTrue(output.ToString().Contains("Your number must be 33! It took me 7 tries to guess your number."));

            output = new StringWriter();
            input = new StringReader("y\n");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.Guess(100);
            Assert.IsTrue(output.ToString().Contains("Hooray! Your number is 50. It took me 1 try to guess your number."));

            output = new StringWriter();
            input = new StringReader("y\n");
            Console.SetIn(input);
            Console.SetOut(output);
            numberGuesser.Guess(100);
            Assert.IsTrue(output.ToString().Contains("Hooray! Your number is 50. It took me 1 try to guess your number."));

        }
    }
}