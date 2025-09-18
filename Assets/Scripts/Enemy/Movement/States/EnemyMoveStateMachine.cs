using System.Collections.Generic;

namespace Enemy.Movement.States
{
    public class EnemyMoveStateMachine
    {
        public EnemyMoveState State { get; private set; }
        private Dictionary<System.Type, EnemyMoveState> states = new Dictionary<System.Type, EnemyMoveState>();

        public void AddState<T>(T state) where T : EnemyMoveState
        {
            states.Add(typeof(T), state);
        }

        public void ChangeState<T>() where T : EnemyMoveState
        {
            if (!states.TryGetValue(typeof(T), out var newState))
                throw new System.InvalidOperationException($"State {typeof(T)} not registered");

            State?.Exit();
            State = newState;
            State.Enter();
        }
    }
}