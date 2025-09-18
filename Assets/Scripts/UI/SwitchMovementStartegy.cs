using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public enum MovementStrategyType { Casual, Tank }

    [RequireComponent(typeof(Toggle))]
    public class SwitchMovementStartegy : MonoBehaviour
    {
        [SerializeField] private MovementStrategyType movementStrategyType = MovementStrategyType.Casual;

        private Toggle toggle;
        private IPlayerInputService playerInputService;

        [Inject]
        public void Construct(IPlayerInputService playerInputService)
        {
            this.playerInputService = playerInputService;
        }
        private void Awake()
        {
            toggle = GetComponent<Toggle>();
        }

        void OnEnable()
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }

        void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            if (!isOn)
                return;

            playerInputService.SetInputMoveStrategy(movementStrategyType);
        }
    }
}