using UnityEngine;
using UnityEngine.Pool;

namespace Bullets
{
    public abstract class BulletSpawner : ScriptableObject
    {
        public abstract BulletBase GetBullet();
    }

    public abstract class BulletBasePool<T> : BulletSpawner where T : BulletBase
    {
        [SerializeField] protected int defaultCapacity = 10;

        protected IObjectPool<T> m_Pool;
        public IObjectPool<T> Pool => m_Pool ??= new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, defaultCapacity);

        public override BulletBase GetBullet()
        {
            return Pool.Get();
        }

        protected abstract T CreatePooledItem();

        protected virtual void OnReturnedToPool(T bullet)
        {
            bullet.gameObject.SetActive(false);
        }

        protected virtual void OnTakeFromPool(T bullet)
        {
            bullet.gameObject.SetActive(true);
        }

        protected virtual void OnDestroyPoolObject(T bullet)
        {
            Destroy(bullet.gameObject);
        }
    }
}