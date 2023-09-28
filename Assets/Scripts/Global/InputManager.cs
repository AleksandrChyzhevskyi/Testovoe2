using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public event Action InputMouseButton;

    private void Start() =>
        Cursor.lockState = CursorLockMode.Locked;

    private void FixedUpdate() =>
        PressMouseButton();

    private void PressMouseButton()
    {
        if (Input.GetMouseButton(0))
            InputMouseButton?.Invoke();
    }
}