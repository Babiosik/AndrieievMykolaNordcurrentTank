using Bullets;
using UnityEngine;

namespace Enemy
{
    public class CrushTankComponent : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (IsFriendlyLayer(collision))
                return;
                
            IDamageable damageable = collision.transform.GetComponentInParent<IDamageable>();
            if (damageable == null)
                return;

            damageable.TakeDamage();
        }

        private bool IsFriendlyLayer(Collision2D collision) => collision.gameObject.layer == gameObject.layer;
    }
}