using UnityEngine;

namespace Effects
{
    public class EffectBase : MonoBehaviour
    {
        protected EffectSpawner bulletPool;

        public virtual void SetPool(EffectSpawner pool) => bulletPool = pool;
        public virtual void ReturnToPool() => bulletPool.ReturnToPool(this);
    }
}