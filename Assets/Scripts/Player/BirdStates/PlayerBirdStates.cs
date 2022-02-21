﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player.BirdStates
{
    [RequireComponent(typeof(PlayerBird))]
    public class PlayerBirdStates : MonoBehaviour
    {
        [SerializeField] private BirdStateBase[] _states;

        private BirdStateBase _currentState;
        private PlayerBird _playerBird;

        public void EnterState<T>()
        {
            IReadOnlyCollection<T> foundedStates = _states.OfType<T>().ToList().AsReadOnly();

            if (foundedStates.Count == 0)
                throw new ArgumentException($"Can't find Bird State of Type {typeof(T).Name}");

            T foundedState = foundedStates.First();
            _currentState = foundedState as BirdStateBase;
            _currentState.Enter(_playerBird);
        }

        private void Awake()
        {
            _playerBird = GetComponent<PlayerBird>();
        }
        private void Start()
        {
            EnterState<BirdStateAlive>();
        }
        private void Update()
        {
            _currentState.UpdateState();
        }
    }
}
