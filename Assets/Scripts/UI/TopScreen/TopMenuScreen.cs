using Pausing;
using Player;
using UnityEngine;

namespace UI.TopMenuScreen
{
    public class TopMenuScreen : MonoBehaviour
    {
        private PlayerBird _playerBird => SceneContext.Instance.PlayerBird;
        private GamePause _pause => SceneContext.Instance.GamePause;
        private bool _isPaused = false;

        public void TogglePause()
        {
            _isPaused = !_isPaused;

            if (_isPaused)
                _pause.Pause();
            else
                _pause.Resume();
        }

        private void Awake()
        {
            _playerBird.OnDeath += playerBirdDied;
        }
        private void OnDestroy()
        {
            _playerBird.OnDeath -= playerBirdDied;
        }

        private void playerBirdDied(PlayerBird bird)
        {
            gameObject.SetActive(false);
        }
    }
}