using UnityEngine;

namespace DefaultNamespace
{
    public class FollowCamera : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake() =>
            _mainCamera = GetComponent<Camera>();

        public void MoveCamera(PlayerStats player)
        {
            Vector3 playerPosition = player.transform.position;
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 2, playerPosition.z - 5);
        }
    }
}