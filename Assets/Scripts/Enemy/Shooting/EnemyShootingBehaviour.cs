using Tanks;
using UnityEngine;

namespace Enemy.Shooting
{
    [RequireComponent(typeof(TankShooting))]
    public abstract class EnemyShootingBehaviour : MonoBehaviour
    {
        protected TankShooting tankShooting;

        protected virtual void Awake()
        {
            tankShooting = GetComponent<TankShooting>();
        }

        protected virtual void Shoot()
        {
            tankShooting.Shoot();
        }
    }
}
