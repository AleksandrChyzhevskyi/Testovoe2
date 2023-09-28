using System;
using DefaultNamespace;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public event Action<InputManager> TakeInputManager;
    private FollowCamera _followCamera;
    private WalletCoints _walletCoints = new WalletCoints();

    public IWalletPlayer wallet => _walletCoints;

    private void Update()
    {
        if (_followCamera != null)
            _followCamera.MoveCamera(this);
    }

    public void ChangeCountCoints() =>
        _walletCoints.AddCoin();

    public void Instans(InputManager inputManager, FollowCamera followCamera)
    {
        _followCamera = followCamera;
        TakeInputManager?.Invoke(inputManager);
    }
}