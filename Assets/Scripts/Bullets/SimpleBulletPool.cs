using UnityEngine;

namespace Bullets
{
    [CreateAssetMenu(menuName = "Pool/SimpleBullet")]
    public class SimpleBulletPool : BulletBasePool<SimpleBullet>
    {
        [SerializeField] private SimpleBullet prefab;
        protected override SimpleBullet CreatePooledItem()
        {
            var bullet = Instantiate(prefab);
            bullet.SetPool(this);
            return bullet;
        }
    }
}