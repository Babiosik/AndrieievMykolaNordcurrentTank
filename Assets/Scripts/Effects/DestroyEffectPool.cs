using UnityEngine;

namespace Effects
{
    [CreateAssetMenu(menuName = "Pool/DestroyEffectPool")]
    public class DestroyEffectPool : EffectBasePool<EffectBase>
    {
        [SerializeField] private EffectBase prefab;
        protected override EffectBase CreatePooledItem()
        {
            var bullet = Instantiate(prefab);
            bullet.SetPool(this);
            return bullet;
        }
    }
}