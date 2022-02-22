using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainDeathScreen
{
    public class MainDeathScreen : MonoBehaviour
    {
        private PlayerBird _playerBird => SceneContext.Instance.PlayerBird;

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void Awake()
        {
            _playerBird.OnDeath += playerBirdDied;
            gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
            _playerBird.OnDeath -= playerBirdDied;
        }
        private void playerBirdDied(PlayerBird bird)
        {
            gameObject.SetActive(true);
        }
    }
}