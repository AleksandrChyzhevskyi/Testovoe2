public class WalletCoints : IWalletPlayer
{
    public int ScoreCoints { get; private set; } = 0;

    public void AddCoin() =>
        ScoreCoints++;
}