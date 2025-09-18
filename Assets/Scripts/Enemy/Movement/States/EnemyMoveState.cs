using UnityEngine;

namespace Enemy.Movement.States
{
    public abstract class EnemyMoveState
    {
        public Vector2 Direction { get; protected set; }
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}