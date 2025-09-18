using Player;
using UnityEngine;
using Utilities;
using Zenject;

namespace Spawners
{
    public class PlayerTankFactory : TankFactory
    {
        [SerializeField] private float respawnTime = 1f;
        [SerializeField] private Transform[] spawnPoints;

        private GameObject playerTank;
        private Timer respawnTimer;
        private ICameraService cameraService;
        private IPlayerInputService playerInputService;

        [Inject]
        public void Construct(ICameraService cameraService, IPlayerInputService playerInputService)
        {
            this.cameraService = cameraService;
            this.playerInputService = playerInputService;
        }

        protected override Vector2 GetSpawnPoint()
        {
            return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        }

        private void Awake()
        {
            respawnTimer = new CountdownTimer(respawnTime, null, OnTankRespawned);
        }

        protected override GameObject SpawnTank()
        {
            playerTank = base.SpawnTank();
            cameraService.SetFollow(playerTank.transform);
            playerInputService.SetTankMediator(playerTank.GetComponent<TankMediator>());
            return playerTank;
        }

        public override void DestroyTank(GameObject tank)
        {
            base.DestroyTank(playerTank = tank);
            respawnTimer.Start();
        }

        private void OnTankRespawned()
        {
            RespawnTank(playerTank);
        }

        private void Update()
        {
            respawnTimer.Tick(Time.deltaTime);
        }
    }
}