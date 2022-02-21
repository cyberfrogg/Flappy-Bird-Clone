using System;
using UnityEngine;
using CameraBehaviour.Extensions;
using Player.BirdStates;

namespace Player
{
    [RequireComponent(typeof(PlayerBirdStates), typeof(Rigidbody2D))]
    public class PlayerBird : MonoBehaviour
    {
        public PlayerBirdStates States { get => _states; }

        [SerializeField] private float _flyUpForce = 1000f;
        private PlayerBirdStates _states;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _states = GetComponent<PlayerBirdStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void FlyUp()
        {
            _rigidbody.velocity = Vector2.up * _flyUpForce;
        }
    }
}