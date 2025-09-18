using Enemy.Movement.States;
using Tanks;
using UnityEngine;

namespace Enemy.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(TankMovement))]
    public abstract class EnemyMoveBehaviour : MonoBehaviour
    {
        protected Rigidbody2D rb;
        protected TankMovement tankMovement;
        protected EnemyMoveStateMachine stateMachine; 

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            tankMovement = GetComponent<TankMovement>();
        }

        protected virtual void Move(Vector2 direction)
        {
            tankMovement.DirectionVector = direction;
        }
    }
}