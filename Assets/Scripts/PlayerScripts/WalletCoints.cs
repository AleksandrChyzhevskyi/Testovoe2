public class WalletCoints : IWalletPlayer
{
    public int _scoreCoints { get; private set; };

    public void AddCoin() =>
        _scoreCoints++;
}