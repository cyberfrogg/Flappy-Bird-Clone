using System;
using UnityEngine;

namespace Player.BirdStates
{
    public class BirdStateDead : BirdStateBase
    {
        public override void Enter(PlayerBird bird)
        {
            Debug.Log("Bird died");
        }

        public override void UpdateState()
        {

        }
    }
}
