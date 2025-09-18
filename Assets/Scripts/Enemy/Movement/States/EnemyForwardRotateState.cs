using UnityEngine;

namespace Enemy.Movement.States
{
    public class EnemyForwardRotateState : EnemyMoveState
    {
        public override void Enter()
        {
            Direction = new Vector2(GetRandomDirection(), 1f).normalized;
        }

        private float GetRandomDirection()
        {
            return Random.Range(-1f, 1f);
        }
    }
}