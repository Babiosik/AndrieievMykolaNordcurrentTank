using Bullets;
using Spawners;
using UnityEngine;

namespace Tanks
{
    public class TankDamageableComponent : MonoBehaviour, IDamageable
    {
        private TankFactory factory;
        private TankMediator mediator;

        public void TakeDamage()
        {
            factory.DestroyTank(mediator);
        }

        public void SetFactory(TankFactory tankFactory)
        {
            factory = tankFactory;
        }

        public void SetMediator(TankMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}