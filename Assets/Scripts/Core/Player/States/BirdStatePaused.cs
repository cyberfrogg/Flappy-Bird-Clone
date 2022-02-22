using Core.Player;
using UnityEngine;

namespace Core.Player.States
{
    public class BirdStatePaused : BirdStateBase
    {
        public override void Enter(PlayerBird bird)
        {
            bird.Freeze();
        }
        public override void Exit(PlayerBird bird)
        {
            bird.UnFreeze();
        }
        public override void UpdateState()
        {

        }
    }
}
