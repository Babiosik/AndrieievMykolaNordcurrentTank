using System.Collections.Generic;
using Tanks;
using UnityEngine;
using UnityEngine.Pool;
using Utilities;

namespace Spawners
{
    public class EnemyTankFactory : TankFactory
    {
        [SerializeField] private float respawnTime = 1f;
        [SerializeField] private int spawnCount = 3;

        [Header("Spawn area")]
        [SerializeField] private Vector2 centerOffset = Vector2.zero;
        [SerializeField] private Vector2 areaSize = Vector2.one;
        [SerializeField] private float borderOffset = 1f;

        private IObjectPool<TankMediator> tanksPool;
        private IObjectPool<CountdownTimer> respawnTimerPool;
        private List<Timer> activeTimers = new List<Timer>();

        protected override Vector2 GetSpawnPoint()
        {
            Vector2 spawnPoint = Vector2.zero;
            for (int i = 0; i < 10; i++)
            {
                bool isVertical = Random.Range(0f, 1f) > 0.5f;
                bool isOddSide = Random.Range(0f, 1f) > 0.5f;
                float x = isVertical ? RandomCoord(areaSize.x) : GetSide(isOddSide, areaSize.x);
                float y = isVertical ? GetSide(isOddSide, areaSize.y) : RandomCoord(areaSize.y);
                spawnPoint = centerOffset + new Vector2(x, y);

                if (Physics2D.OverlapCircle(spawnPoint, borderOffset / 2) == null)
                    break;
            }

            return spawnPoint;

            float RandomCoord(float range) => Random.Range(-(range - borderOffset) / 2f, (range - borderOffset) / 2f);
            float GetSide(bool isOddSide, float range) => isOddSide ? (range - borderOffset) / 2f : -(range - borderOffset) / 2f;
        }

        protected override void Start()
        {
            tanksPool = new ObjectPool<TankMediator>(SpawnTank, RespawnTank, base.DestroyTank, null, false, spawnCount);
            respawnTimerPool = new ObjectPool<CountdownTimer>(CreateTimer, null, null, null, false, spawnCount);
            for (int i = 0; i < spawnCount; i++)
                tanksPool.Get();
        }

        public override void DestroyTank(TankMediator tank)
        {
            tanksPool.Release(tank);

            var timer = respawnTimerPool.Get();
            timer.Start();
            activeTimers.Add(timer);
        }

        private void Update()
        {
            foreach (var timer in activeTimers)
                timer.Tick(Time.deltaTime);
        }

        private CountdownTimer CreateTimer()
        {
            var timer = new CountdownTimer(respawnTime);
            timer.OnTimerStop += OnRespawnTank;
            return timer;
        }

        private void OnRespawnTank()
        {
            RespawnTank(tanksPool.Get());
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0, 0.35f);
            Matrix4x4 old = Gizmos.matrix;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Gizmos.DrawWireCube(centerOffset, areaSize);
            Gizmos.matrix = old;

            old = Gizmos.matrix;
            Gizmos.color = new Color(1, 0.5f, 0, 0.35f);
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Gizmos.DrawWireCube(centerOffset, areaSize - Vector2.one * borderOffset);
            Gizmos.matrix = old;
        }
#endif
    }
}