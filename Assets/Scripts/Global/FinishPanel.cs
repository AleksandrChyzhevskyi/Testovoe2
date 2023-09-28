using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class FinishPanel : MonoBehaviour
    {
        private void Start() =>
            gameObject.SetActive(false);

        public void Restart() => SceneManager.LoadScene(0);
    }
}