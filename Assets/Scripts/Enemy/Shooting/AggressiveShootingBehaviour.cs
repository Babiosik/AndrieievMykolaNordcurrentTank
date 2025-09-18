using UnityEngine;
using Utilities;

namespace Enemy.Shooting
{
    public class AggressiveShootingBehaviour : EnemyShootingBehaviour
    {
        [SerializeField] private float timeBetweenShots = 2;
        [SerializeField] private Transform towerPivot;
        private Timer timer;

        private void Start()
        {
            timer = new CountdownTimer(timeBetweenShots, null, Shoot);
            timer.Start();
        }

        private void Update()
        {
            timer.Tick(Time.deltaTime);
            towerPivot.Rotate(Vector3.back, towerPivot.rotation.z + timeBetweenShots * Time.deltaTime);
        }

        protected override void Shoot()
        {
            base.Shoot();
            timer.Start();
        }
    }
}
