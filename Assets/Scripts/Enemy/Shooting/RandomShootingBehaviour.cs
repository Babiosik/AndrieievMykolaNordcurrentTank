using UnityEngine;

namespace Enemy.Shooting
{
    public class RandomShootingBehaviour : EnemyShootingBehaviour
    {
        [SerializeField] private float timeBetweenShots = 2;
        [SerializeField] private float randomOffset = 0.5f;
        private float timer = 0;

        private void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = timeBetweenShots + Random.Range(-randomOffset, randomOffset);
                Shoot();
            }
        }
    }
}
