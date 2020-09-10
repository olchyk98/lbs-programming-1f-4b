namespace bulshitcoding.contracts
{
    public abstract class Player : IPlayer
    {
         // Boolean that represents if player has correctly answered
        public bool HasWon { get; private set; } = false;
        public int GuessesCount { get; private set; } = 0;

        /// <summary>
        /// Checks if the target number is the same as the generated number.
        /// If it's true that means that player has won.
        /// </summary>
        /// <returns>
        /// Boolean that represents if answer is correct
        /// </returns>
        public bool ControlAnswer(int targetNumber, int randomizedNumber)
        {
            // Check if passed the right number
            bool isCorrect = targetNumber == randomizedNumber;
            
            // Set HasWon variable to true if player won
            if (isCorrect) HasWon = true;
            // Otherwise inrease number of guesses that player made
            else GuessesCount++;

            return isCorrect;
        }

        #region Abstract Methods

        public abstract void PrintWinningMessage(int randomizedNumber);

        public abstract void PrintNumberErrorMessage(int number, int randomizedNumber);

        public abstract int GuessNumber(int randomizedNumber);

        #endregion
    }
}