using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] protected float speed = 10f;

        protected BulletSpawner bulletPool;
        protected Collider2D collider;

        protected Rigidbody2D Rigidbody2D { get; private set; }

        protected virtual void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            collider = GetComponentInChildren<Collider2D>();
        }

        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            IDamageable damageable = col.GetComponentInParent<IDamageable>();
            if (damageable == null)
                return;

            damageable.TakeDamage();
            ReturnToPool();
        }

        public virtual void SetPool(BulletSpawner pool) => bulletPool = pool;
        public virtual void ReturnToPool() => bulletPool.ReturnToPool(this);
        public virtual void SetShooter(Collider2D shooter)
        {
            Physics2D.IgnoreCollision(shooter, collider);
        }


    }
}