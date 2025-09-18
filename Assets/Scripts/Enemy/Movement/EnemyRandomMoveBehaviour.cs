using Enemy.Movement.States;
using UnityEngine;
using Utilities;

namespace Enemy.Movement
{
    public class EnemyRandomMoveBehaviour : EnemyMoveBehaviour
    {
        [SerializeField] private float moveForwardDuration = 1f;
        [SerializeField] private float changeDirectionDuration = 1f;
        [SerializeField] private float avoidCollisionDuration = 1f;
        private Timer forwardPhaseTimer;
        private Timer rotatePhaseTimer;
        private Timer avoidCollisionTimer;
        private EnemyCollisionState collisionState;

        protected override void Awake()
        {
            base.Awake();
            stateMachine = new EnemyMoveStateMachine();
            stateMachine.AddState(new EnemyForwardMoveState());
            stateMachine.AddState(new EnemyForwardRotateState());

            collisionState = new EnemyCollisionState();
            stateMachine.AddState(collisionState);

            forwardPhaseTimer = new CountdownTimer(moveForwardDuration, null, StartChangeDirection);
            rotatePhaseTimer = new CountdownTimer(changeDirectionDuration, null, StartMoveForward);
            avoidCollisionTimer = new CountdownTimer(avoidCollisionDuration, null, StartMoveForward);

            StartMoveForward();
        }

        protected void OnDestroy()
        {
            forwardPhaseTimer.Dispose();
            rotatePhaseTimer.Dispose();
        }

        protected void Update()
        {
            forwardPhaseTimer.Tick(Time.deltaTime);
            rotatePhaseTimer.Tick(Time.deltaTime);
            avoidCollisionTimer.Tick(Time.deltaTime);
            Move(stateMachine.State.Direction);
        }

        private void StartChangeDirection()
        {
            stateMachine.ChangeState<EnemyForwardRotateState>();
            rotatePhaseTimer.Start();
        }

        private void StartMoveForward()
        {
            stateMachine.ChangeState<EnemyForwardMoveState>();
            forwardPhaseTimer.Start();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (avoidCollisionTimer.IsRunning)
                return;

            forwardPhaseTimer.Pause();
            rotatePhaseTimer.Pause();
            avoidCollisionTimer.Start();
            collisionState.SetContactPoint(collision.GetContact(0));
            stateMachine.ChangeState<EnemyCollisionState>();
        }
    }
}