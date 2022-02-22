using Core.Player;
using UnityEngine;

namespace Core.Level
{
    [RequireComponent(typeof(LevelGenerator))]
    public class LevelEnviroment : MonoBehaviour
    {
        [SerializeField] private Transform _levelContainer;
        [SerializeField] private float _movementSpeed = 1f;

        private bool _isMoving;
        private PlayerBird _playerBird;
        private LevelGenerator _levelGenerator;

        public void Setup(PlayerBird bird)
        {
            _playerBird = bird;
            _levelGenerator = GetComponent<LevelGenerator>();
            _levelGenerator.Setup(_playerBird);
        }
        public void StartMovement()
        {
            _isMoving = true;
        }
        public void StopMovement()
        {
            _isMoving = false;
        }

        private void Update()
        {
            if (!_isMoving)
                return;

            _levelContainer.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
        }
    }
}