namespace bulshitcoding.contracts
{
    public interface IPlayer
    {
        void PrintWinningMessage(int randomizedNumber);
        void PrintNumberErrorMessage(int number, int randomizedNumber);
        int GuessNumber(int randomizedNumber);
    }
}