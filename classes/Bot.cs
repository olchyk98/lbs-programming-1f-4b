using System;
using bulshitcoding.contracts;

namespace bulshitcoding.classes
{
    public class Bot : Player
    {
        #region Fields
        private readonly int[] myGuessedRange = {NumberGenerator.NumberRange[0], NumberGenerator.NumberRange[1]}; // [min, max]
        #endregion
        
        #region Methods
        /// <summary>
        /// Template for winning message
        /// </summary>
        public override void PrintWinningMessage(int generatedNumber)
        {
            Console.WriteLine(
                $"Bot guessed number {generatedNumber} and won! It needed {GuessesCount} tries to guess this number.");
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
            Console.WriteLine($"Bot guessed {number} and it's invalid. This number is too {sizeString}.");
        }

        /// <summary>
        /// Remembers the bot's choice.
        /// </summary>
        public void RememberChoice(int number, int randomizedNumber)
        {
            // Mark new bottom guessing limit
            if (number < randomizedNumber && number > myGuessedRange[0])
            {
                myGuessedRange[0] = number;
            } else if (number > randomizedNumber && number < myGuessedRange[1])
            { // Mark new top guessing limit
                myGuessedRange[1] = number;
            }
        }

        /// <summary>
        /// Decides which number the bot should guess
        /// </summary>
        /// <param name="randomizedNumber"></param>
        public override int GuessNumber(int randomizedNumber)
        {
            // Initialize random
            Random random = new Random();
            
            // Guess number in range that is higher than the smallest number
            return random.Next(myGuessedRange[0], myGuessedRange[1]);
        }
        #endregion
    }
}