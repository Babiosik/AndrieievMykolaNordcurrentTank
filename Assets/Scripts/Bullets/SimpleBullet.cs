using UnityEngine;

namespace Bullets
{
    public class SimpleBullet : BulletBase
    {
        public override void ReturnToPool()
        {
            bulletPool.Pool.Release(this);
        }

        private void FixedUpdate()
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + (Vector2)transform.up * speed * Time.fixedDeltaTime);
        }
    }
}