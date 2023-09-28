using DefaultNamespace;
using UnityEngine;

namespace Global
{
    public class StartGame : MonoBehaviour
    {
        private FollowCamera _followCamera;
        private InputManager _inputManager;
        private FactoryElements _factoryElements;
        private ChangeText _changeText;
        private FinishPanel _finishPanel;
        private void Awake()
        {
            _finishPanel = GetComponentInChildren<FinishPanel>();
            _inputManager = GetComponentInChildren<InputManager>();
            _followCamera = GetComponentInChildren<FollowCamera>();
            _factoryElements = GetComponentInChildren<FactoryElements>();
            _changeText = GetComponentInChildren<ChangeText>();
        }

        private void Start()
        {
            LewelMap lewelMap = _factoryElements.CreateLewelMap();
            _factoryElements.CreateCoints(lewelMap.GetPositionSpawn());
            PlayerStats player = _factoryElements.CreatePlayer(lewelMap.GetSpawnPlayerPosition(), _inputManager,
                _followCamera, transform);
            _changeText.Init(player.wallet);
            lewelMap.Init(_finishPanel, player);
        }
    }
}