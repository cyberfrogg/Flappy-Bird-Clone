using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Player.States
{
    [RequireComponent(typeof(PlayerBird))]
    public class BirdStates : MonoBehaviour
    {
        [SerializeField] private BirdStateBase[] _states;

        private BirdStateBase _currentState;
        private PlayerBird _playerBird;

        public void EnterState<T>()
        {
            IReadOnlyCollection<T> foundedStates = _states.OfType<T>().ToList().AsReadOnly();

            if (foundedStates.Count == 0)
                throw new ArgumentException($"Can't find Bird State of Type {typeof(T).Name}");

            if (_currentState != null)
                _currentState.Exit(_playerBird);

            T foundedState = foundedStates.First();
            _currentState = foundedState as BirdStateBase;
            _currentState.Enter(_playerBird);
        }

        private void Start()
        {
            _playerBird = GetComponent<PlayerBird>();
            EnterState<BirdStatePaused>();
        }
        private void Update()
        {
            _currentState.UpdateState();
        }
    }
}
