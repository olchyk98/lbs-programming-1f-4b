using System;
using bulshitcoding.contracts;

namespace bulshitcoding.classes
{
    public class User : Player
    {
        /// <summary>
        /// Gets input from user and converts it a number
        /// </summary>
        /// <param name="randomizedNumber"></param>
        /// <returns>
        /// Received number
        /// </returns>
        public override int GuessNumber(int randomizedNumber)
        {
            // Print the input message
            int[] choiceRange = NumberGenerator.NumberRange;
            Console.WriteLine($"Guess your number (between {choiceRange[0]} and {choiceRange[1]}): ");
            
            // Ask for input till the moment when player presses a valid button
            int pressedNumber = default;

            while (pressedNumber == default)
            {
                // Ask for input
                string pressedKey = Console.ReadLine();
            
                // Check if number is in the ASCII range (if it's really number)
                try
                {
                    pressedNumber = int.Parse(pressedKey!);
                    break;
                }
                catch
                {
                    // pass
                }

                // Otherwise ask for input again
            }
            
            // Return the pressed number
            return pressedNumber;
        }

        /// <summary>
        /// Template for winning message
        /// </summary>
        /// <param name="randomizedNumber"></param>
        public override void PrintWinningMessage(int randomizedNumber)
        {
            Console.WriteLine(
                $"You gussed number {randomizedNumber} and won! You needed {GuessesCount} tries to guess this number.");
        }

        /// <summary>
        /// Template for the error message
        /// </summary>
        /// <param name="number">
        ///     Passed number
        /// </param>
        /// <param name="randomizedNumber"></param>
        public override void PrintNumberErrorMessage(int number, int randomizedNumber)
        {
            // Check if value is bigger
            bool isTooBig = number > randomizedNumber;
            string sizeString = (isTooBig) ? "big" : "small";

            // Print the error
            Console.WriteLine($"You guessed number {number}. It's too {sizeString}!");
        }
    }
}