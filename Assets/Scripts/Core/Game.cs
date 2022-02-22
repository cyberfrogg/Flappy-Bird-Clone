using Core.Level;
using Core.Player;
using Core.Player.States;
using UnityEngine;

namespace Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private PlayerBird _playerBird;
        [SerializeField] private LevelEnviroment _levelEnviroment;

        public void StartPlay()
        {
            _playerBird.EnterState<BirdStateAlive>();
            _levelEnviroment.StartMovement();
            _playerBird.OnDeath += birdDied;
        }

        private void Awake()
        {
            _levelEnviroment.Setup(_playerBird);
        }
        private void birdDied(PlayerBird bird)
        {
            _levelEnviroment.StopMovement();
        }
    }
}