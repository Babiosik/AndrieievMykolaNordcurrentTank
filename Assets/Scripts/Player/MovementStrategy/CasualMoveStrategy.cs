using UnityEngine;

namespace Player.MovementStrategy
{
    public class CasualMoveStrategy : IInputMoveStrategy
    {
        public Vector2 GetMoveVector(PlayerInputActions playerInputActions)
        {
            return playerInputActions.CasualMove.Move.ReadValue<Vector2>();
        }
    }
}