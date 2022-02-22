using Pausing;
using UnityEngine;

namespace UI.MainMenuScreen
{
    public class MainMenuScreen : MonoBehaviour
    {
        private GamePause _pause => SceneContext.Instance.GamePause;

        private void Start()
        {
            _pause.Pause();
        }

        public void PlayGame()
        {
            _pause.Resume();
            gameObject.SetActive(false);
        }
    }
}