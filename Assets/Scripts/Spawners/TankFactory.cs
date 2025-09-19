using Effects;
using Tanks;
using UnityEngine;

namespace Spawners
{
    public abstract class TankFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] tankPrefabs;
        [SerializeField] private EffectSpawner destroyEffectSpawner;
        protected abstract Vector2 GetSpawnPoint();

        protected virtual void Start()
        {
            SpawnTank();
        }

        protected virtual GameObject SpawnTank()
        {
            int randomIndex = Random.Range(0, tankPrefabs.Length);
            Vector2 spawnPoint = GetSpawnPoint();
            var go = Instantiate(tankPrefabs[randomIndex], spawnPoint, GetRotation(spawnPoint));
            go.AddComponent<TankDamageableComponent>().SetFactory(this);
            return go;
        }

        protected virtual void RespawnTank(GameObject tank)
        {
            Vector2 spawnPoint = GetSpawnPoint();
            tank.transform.position = spawnPoint;
            tank.transform.rotation = GetRotation(spawnPoint);
            tank.SetActive(true);
        }

        public virtual void DestroyTank(GameObject tank)
        {
            if (destroyEffectSpawner != null)
                destroyEffectSpawner.GetEffect(tank.transform);
            tank.SetActive(false);
        }

        private Quaternion GetRotation(Vector2 position)
        {
            Vector2 dir = Vector2.zero - position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, angle - 90);
        }
    }
}