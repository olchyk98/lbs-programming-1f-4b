using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bulshitcoding.contracts;

namespace bulshitcoding.classes
{
    public static class PipelineHandler
    {
        #region Fields
        private static User myPlayer;
        private static Bot myBot;
        private static IList<Player> players;
        private static NumberGenerator NumberGenerator;
        private static int RandomizedNumber => NumberGenerator.GeneratedNumber;
        #endregion
        
        #region Constructor

        static PipelineHandler()
        {
            NumberGenerator = new NumberGenerator();
            
            myPlayer = new User();
            myBot = new Bot();
            
            players = new List<Player>() { myPlayer, myBot };
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Nxt layer of entry point
        /// </summary>
        public static void Run()
        {
            // Randomize value
            NumberGenerator.RandomizeNumber();
            
            // Start loop
            while (!myPlayer.HasWon && !myBot.HasWon)
            {
                // Clear console on each try
                Console.Clear();

                foreach (Player player in players)
                {
                    // Get input
                    int passedNumber = player.GuessNumber(RandomizedNumber);

                    // Validate input
                    bool isCorrect = player.ControlAnswer(passedNumber, NumberGenerator.GeneratedNumber);
                    
                    // Remember input if bot
                    if (player is Bot botPlayer)
                    {
                        botPlayer.RememberChoice(passedNumber, NumberGenerator.GeneratedNumber);
                    }

                    // Print an error message if answer is invalid
                    if (!isCorrect)
                    {
                        // Print the error
                        player.PrintNumberErrorMessage(passedNumber, NumberGenerator.GeneratedNumber);
                    }
                    else
                    {
                        // Print winning message if valid
                        player.PrintWinningMessage(NumberGenerator.GeneratedNumber);   
                    }
                }
                
                // Wait a few seconds to allow user to see the error message
                Task.Delay(3000).Wait();
            }
        }
        #endregion
    }
}