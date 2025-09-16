using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public enum MovementStrategyType { Casual, Tank }

    [RequireComponent(typeof(Toggle))]
    public class SwitchMovementStartegy : MonoBehaviour
    {
        [SerializeField] private MovementStrategyType movementStrategyType = MovementStrategyType.Casual;
        [SerializeField] private PlayerInput playerInput;

        private Toggle toggle;

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
            if (isOn)
            {
                playerInput.SetInputMoveStrategy(movementStrategyType);
            }
        }
    }
}