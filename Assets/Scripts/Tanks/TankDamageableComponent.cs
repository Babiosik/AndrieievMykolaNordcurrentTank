using Bullets;
using Spawners;
using UnityEngine;

namespace Tanks
{
    public class TankDamageableComponent : MonoBehaviour, IDamageable
    {
        private TankFactory factory;

        public void TakeDamage()
        {
            factory.DestroyTank(gameObject);
        }

        public void SetFactory(TankFactory tankFactory)
        {
            factory = tankFactory;
        }
    }
}