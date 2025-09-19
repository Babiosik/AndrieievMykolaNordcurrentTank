using UnityEngine;
using UnityEngine.Pool;

namespace Effects
{
    public abstract class EffectSpawner : ScriptableObject
    {
        public abstract EffectBase GetEffect(Transform parent);
        public abstract void ReturnToPool(EffectBase effect);
    }

    public abstract class EffectBasePool<T> : EffectSpawner where T : EffectBase
    {
        [SerializeField] protected int defaultCapacity = 10;

        protected IObjectPool<T> m_Pool;
        public IObjectPool<T> Pool => m_Pool ??= new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, defaultCapacity);

        public override EffectBase GetEffect(Transform parent)
        {
            var effect = Pool.Get();
            if (parent != null)
            {
                effect.transform.position = parent.position;
                effect.transform.rotation = parent.rotation;
            }
            
            return effect;
        }

        public override void ReturnToPool(EffectBase effect) => Pool.Release((T)effect);

        protected abstract T CreatePooledItem();
        protected virtual void OnReturnedToPool(T effect) => effect.gameObject.SetActive(false);
        protected virtual void OnTakeFromPool(T effect) => effect.gameObject.SetActive(true);
        protected virtual void OnDestroyPoolObject(T effect) => Destroy(effect.gameObject);
    }
}