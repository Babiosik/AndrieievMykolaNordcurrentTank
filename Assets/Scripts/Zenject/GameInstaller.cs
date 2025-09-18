using Cinemachine;
using UnityEngine;

namespace Zenject
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        public override void InstallBindings()
        {
            Container.BindInstance(_virtualCamera).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInputService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CinemachineCameraService>().AsSingle().NonLazy();
        }
    }
}