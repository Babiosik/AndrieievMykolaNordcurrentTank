using UnityEngine;

namespace Bullets
{
    public class SimpleBullet : BulletBase
    {
        private void FixedUpdate()
        {
            Rigidbody2D.MovePosition(Rigidbody2D.position + (Vector2)transform.up * speed * Time.fixedDeltaTime);
        }
    }
}