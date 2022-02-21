using Level.Generation;
using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(LevelGenerator))]
    public class LevelEnviroment : MonoBehaviour
    {
        public Transform Container { get => _levelContainer; }

        [SerializeField] private bool _autoStart;
        [SerializeField] private Transform _levelContainer;
        [SerializeField] private float _movementSpeed = 1f;

        private bool _isMoving;

        public void StartLevelMovement()
        {
            _isMoving = true;
        }

        private void Start()
        {
            if (!_autoStart)
                return;

            StartLevelMovement();
        }
        private void Update()
        {
            if (!_isMoving)
                return;

            _levelContainer.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
        }
    }
}