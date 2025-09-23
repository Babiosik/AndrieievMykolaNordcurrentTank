using System.Collections.Generic;
using Player.MovementStrategy;
using Tanks;
using UI;
using UnityEngine.InputSystem;

namespace Zenject
{
    public interface IPlayerInputService : IService, ITickable
    {
        void SetInputMoveStrategy(MovementStrategyType moveStrategy);
        void SetTankMediator(TankMediator tankMediator);
    }

    public class PlayerInputService : IPlayerInputService
    {
        private TankMediator tankMediator;
        private PlayerInputActions playerInputActions;
        private IInputMoveStrategy inputMoveStrategy;
        private Dictionary<MovementStrategyType, IInputMoveStrategy> inputMoveStrategiesDict;

        public void Initialize()
        {
            playerInputActions = new PlayerInputActions();
            inputMoveStrategiesDict = new Dictionary<MovementStrategyType, IInputMoveStrategy>
            {
                { MovementStrategyType.Casual, new CasualMoveStrategy() },
                { MovementStrategyType.Tank, new TankMoveStrategy() }
            };
            SetInputMoveStrategy(MovementStrategyType.Casual);

            playerInputActions.Tower.Shoot.performed += OnShoot;
            playerInputActions.Enable();
        }

        public void Dispose()
        {
            playerInputActions.Disable();
            playerInputActions.Dispose();
            playerInputActions.Tower.Shoot.performed -= OnShoot;
        }

        private void OnShoot(InputAction.CallbackContext context)
        {
            tankMediator?.Shooting?.Shoot();
        }

        public void Tick()
        {
            if (tankMediator == null)
                return;
            if (tankMediator.Movement == null)
                throw new System.Exception("TankMovement is null");

            tankMediator.Movement.DirectionVector = inputMoveStrategy.GetMoveVector(playerInputActions);
        }

        public void SetInputMoveStrategy(MovementStrategyType moveStrategy)
        {
            if (inputMoveStrategiesDict.TryGetValue(moveStrategy, out IInputMoveStrategy inputMoveStrategies))
                this.inputMoveStrategy = inputMoveStrategies;
            else
                throw new System.Exception("Strategy not found");
        }

        public void SetTankMediator(TankMediator tankMediator)
        {
            this.tankMediator = tankMediator;
        }
    }
}