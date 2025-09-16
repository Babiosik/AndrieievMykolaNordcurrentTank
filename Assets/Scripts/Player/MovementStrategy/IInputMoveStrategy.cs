using UnityEngine;

namespace Player.MovementStrategy
{
    public interface IInputMoveStrategy
    {
        Vector2 GetMoveVector(PlayerInputActions playerInputActions);
    }
}