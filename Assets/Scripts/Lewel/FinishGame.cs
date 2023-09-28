using Global;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private FinishPanel _finishPanel;
    private LewelMap _lewelMap;
    private PlayerStats _playerStats;

    private void Awake() =>
        _lewelMap = GetComponentInParent<LewelMap>();

    private void OnEnable() =>
        _lewelMap.Finished += Init;

    private void Update()
    {
        if (_playerStats.gameObject.transform.position.y <= -3)
        {
            _playerStats.gameObject.SetActive(false);
            FinalMenu();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerStats _))
            FinalMenu();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Movment playerMovment))
            playerMovment.enabled = false;
    }

    private void OnDisable() =>
        _lewelMap.Finished -= Init;

    private void FinalMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        _finishPanel.gameObject.SetActive(true);
    }

    private void Init(FinishPanel finishPlane, PlayerStats playerStats)
    {
        _finishPanel = finishPlane;
        _playerStats = playerStats;
    } 
}