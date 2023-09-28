using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;
    private IWalletPlayer _walletPlayer;

    private void Update() => _tmpText.text = $"Score: {_walletPlayer.ScoreCoints}";

    public void Init(IWalletPlayer walletCoints) => 
        _walletPlayer = walletCoints;
}

