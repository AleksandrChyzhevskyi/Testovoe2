using UnityEngine;

public class Movment : MonoBehaviour
{
    private InputManager _inputManager;

    private readonly int Speed = 5;
    private PlayerStats _playerStats;

    private void Awake() =>
        _playerStats = GetComponent<PlayerStats>();


    private void OnEnable() =>
        _playerStats.TakeInputManager += SetInputManager;


    private void OnDisable()
    {
        _inputManager.InputMouseButton -= Move;
        _playerStats.TakeInputManager -= SetInputManager;
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
            ChangeDirection(new Vector3(GetMousePosition(), 0, 0));
    }

    private void SetInputManager(InputManager inputManager)
    {
        _inputManager = inputManager;
        _inputManager.InputMouseButton += Move;
    }

    private void ChangeDirection(Vector3 direction)
    {
        transform.position += (direction + Vector3.forward) * (Speed * Time.deltaTime);
        transform.Rotate(10, 0, 0);
    }

    private float GetMousePosition() => Input.GetAxis("Mouse X");
}