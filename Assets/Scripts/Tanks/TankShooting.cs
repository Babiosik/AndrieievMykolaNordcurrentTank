using Bullets;
using UnityEngine;

namespace Tanks
{
    public class TankShooting : MonoBehaviour
    {
        [SerializeField] private BulletSpawner bulletSpawner;
        [SerializeField] private Transform firePivot;
        [SerializeField] private AudioSource shootAudio;

        private Collider2D collider;

        private void Awake()
        {
            collider = GetComponentInChildren<Collider2D>();
        }

        public void Shoot()
        {
            BulletBase bullet = bulletSpawner.GetBullet();
            bullet.SetShooter(collider);
            bullet.transform.position = firePivot.position;
            bullet.transform.rotation = firePivot.rotation;
            shootAudio.Play();
        }
    }
}