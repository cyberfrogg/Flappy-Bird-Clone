using CameraBehaviour.Extensions;
using System;
using UnityEngine;

namespace Player.BirdStates
{
    public class BirdStateAlive : BirdStateBase
    {
        private PlayerBird _bird;

        public override void Enter(PlayerBird bird)
        {
            _bird = bird;
        }

        public override void UpdateState()
        {
            controlInput();
            checkDeath();
        }
        private void controlInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _bird.FlyUp();
            }
        }
        private void checkDeath()
        {
            Bounds cameraBounds = Camera.main.GetCameraBounds(Camera.main.transform.localToWorldMatrix);

            if (transform.position.y <= cameraBounds.min.y)
            {
                _bird.States.EnterState<BirdStateDead>();
            }
        }
    }
}
