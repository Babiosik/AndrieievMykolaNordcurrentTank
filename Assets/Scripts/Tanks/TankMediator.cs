using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(TankMovement), typeof(TankShooting))]
    [RequireComponent(typeof(TankDamageableComponent), typeof(TankAppearanceController))]
    public class TankMediator : MonoBehaviour
    {
        protected TankMovement movement;
        protected TankShooting shooting;
        protected TankDamageableComponent damageable;
        protected TankAppearanceController appearance;

        protected virtual void Awake()
        {
            movement = GetComponent<TankMovement>();
            shooting = GetComponent<TankShooting>();
            damageable = GetComponent<TankDamageableComponent>();
            appearance = GetComponent<TankAppearanceController>();

            damageable.SetMediator(this);
        }

        public TankMovement Movement => movement;
        public TankShooting Shooting => shooting;
        public TankDamageableComponent DamageableComponent => damageable;
        public TankAppearanceController AppearanceController => appearance;
    }
}