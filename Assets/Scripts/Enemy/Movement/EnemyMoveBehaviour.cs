using Enemy.Movement.States;
using Tanks;
using UnityEngine;

namespace Enemy.Movement
{
    [RequireComponent(typeof(TankMovement))]
    public abstract class EnemyMoveBehaviour : MonoBehaviour
    {
        protected TankMovement tankMovement;
        protected EnemyMoveStateMachine stateMachine; 

        protected virtual void Awake()
        {
            tankMovement = GetComponent<TankMovement>();
        }

        protected virtual void Move(Vector2 direction)
        {
            tankMovement.DirectionVector = direction;
        }
    }
}