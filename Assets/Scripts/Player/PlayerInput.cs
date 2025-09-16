using System.Collections.Generic;
using Player.MovementStrategy;
using Tanks;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private TankMovement tankMovement;
        private PlayerInputActions playerInputActions;
        private IInputMoveStrategy inputMoveStrategy;
        private Dictionary<MovementStrategyType, IInputMoveStrategy> inputMoveStrategiesDict = new Dictionary<MovementStrategyType, IInputMoveStrategy>();

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            inputMoveStrategiesDict.Add(MovementStrategyType.Casual, new CasualMoveStrategy());
            inputMoveStrategiesDict.Add(MovementStrategyType.Tank, new TankMoveStrategy());
            SetInputMoveStrategy(MovementStrategyType.Casual);
        }

        private void OnEnable()
        {
            playerInputActions.Enable();
        }

        private void OnDisable()
        {
            playerInputActions.Disable();
        }

        private void OnDestroy()
        {
            playerInputActions.Dispose();
        }

        private void Update()
        {
            if (tankMovement == null)
                throw new System.Exception("TankMovement is null");

            tankMovement.DirectionVector = inputMoveStrategy.GetMoveVector(playerInputActions);
        }

        public void SetInputMoveStrategy(MovementStrategyType moveStrategy)
        {
            if (inputMoveStrategiesDict.TryGetValue(moveStrategy, out IInputMoveStrategy inputMoveStrategies))
                this.inputMoveStrategy = inputMoveStrategies;
            else
                throw new System.Exception("Strategy not found");
        }
    }
}