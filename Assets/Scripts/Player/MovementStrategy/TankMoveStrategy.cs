using UnityEngine;

namespace Player.MovementStrategy
{
    public class TankMoveStrategy : IInputMoveStrategy
    {
        private Vector2 outputVector = Vector2.zero;

        public Vector2 GetMoveVector(PlayerInputActions playerInputActions)
        {
            float leftTruck = playerInputActions.TankMove.LeftTruck.ReadValue<float>();
            float rightTruck = playerInputActions.TankMove.RightTruck.ReadValue<float>();
            
            outputVector.x = leftTruck - rightTruck;
            outputVector.y = leftTruck + rightTruck;
            outputVector.Normalize();
            
            return outputVector;
        }
    }
}