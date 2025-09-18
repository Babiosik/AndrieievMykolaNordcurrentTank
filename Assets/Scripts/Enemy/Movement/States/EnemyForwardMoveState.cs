using UnityEngine;

namespace Enemy.Movement.States
{
    public class EnemyForwardMoveState : EnemyMoveState
    {
        public override void Enter()
        {
            Direction = Vector2.up;
        }
    }
}