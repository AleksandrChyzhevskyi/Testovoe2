using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    public void Init(IWalletPlayer walletCoints) =>
        _tmpText.text = $"Score: {walletCoints.ScoreCoints}";
}

