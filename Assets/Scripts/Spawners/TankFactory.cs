using Tanks;
using UnityEngine;

namespace Spawners
{
    public abstract class TankFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] tankPrefabs;
        protected abstract Vector2 GetSpawnPoint();

        protected virtual void Start()
        {
            SpawnTank();
        }

        protected virtual GameObject SpawnTank()
        {
            int randomIndex = Random.Range(0, tankPrefabs.Length);
            Vector2 spawnPoint = GetSpawnPoint();
            var go = Instantiate(tankPrefabs[randomIndex], spawnPoint, Quaternion.Euler(-spawnPoint.normalized));
            go.AddComponent<TankDamageableComponent>().SetFactory(this);
            return go;
        }

        protected virtual void RespawnTank(GameObject tank)
        {
            Vector2 spawnPoint = GetSpawnPoint();
            tank.transform.position = spawnPoint;
            tank.transform.rotation = Quaternion.Euler(-spawnPoint.normalized);
            tank.SetActive(true);
        }

        public virtual void DestroyTank(GameObject tank)
        {
            tank.SetActive(false);
        }
    }
}