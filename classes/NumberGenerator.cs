using System;

namespace bulshitcoding.classes
{
    internal class NumberGenerator
    {
        public static readonly int[] NumberRange = {1, 100};
        public int GeneratedNumber { get; private set; }

        /// <summary>
        /// Asks user for a number in the specific range.
        /// </summary>
        public void RandomizeNumber()
        {
            // Instantiate random
            Random random = new Random();
            
            // Generate a random number in range
            GeneratedNumber = random.Next(NumberRange[0], NumberRange[1]);
        }
    }
}