using Core.Player.States;
using Extensions.CameraExt;
using System;
using UnityEngine;

namespace Core.Player
{
    public class PlayerBird : MonoBehaviour
    {
        public BirdStates States { get => _states; }
        public Action<PlayerBird> OnDeath;

        [SerializeField] private float _flyUpForce = 10f;
        [SerializeField] private float _maxVelocity = 20f;
        [Space]
        [SerializeField, Range(0, 5f)] private float _spriteRotationModifier;
        [SerializeField] private Transform _sprite;

        private BirdStates _states;
        private Rigidbody2D _rigidbody;
        private Vector2 _lastFrozenVelocity;

        public void EnterState<T>()
        {
            States.EnterState<T>();
        }

        public void FlyUp()
        {
            _rigidbody.velocity = Vector2.up * _flyUpForce;
        }
        public void Die()
        {
            OnDeath?.Invoke(this);
        }
        public void Freeze()
        {
            _rigidbody.isKinematic = true;
            _lastFrozenVelocity = _rigidbody.velocity;
            _rigidbody.velocity = Vector2.zero;
        }
        public void UnFreeze()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = _lastFrozenVelocity;
        }

        private void Awake()
        {
            _states = GetComponent<BirdStates>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            clampVelocity();
            rotateSprite();
            clampPosition();
        }

        private void rotateSprite()
        {
            _sprite.rotation = Quaternion.Euler(0, 0, _rigidbody.velocity.y * _spriteRotationModifier);
        }
        private void clampVelocity()
        {
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxVelocity);
        }
        private void clampPosition()
        {
            float maxY = Camera.main.GetCameraBounds(Camera.main.transform.localToWorldMatrix).max.y;

            if (_rigidbody.position.y >= maxY)
            {
                _rigidbody.position = new Vector2(_rigidbody.position.x, maxY);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            }
        }
    }
}