using Cinemachine;
using UnityEngine;

namespace Zenject
{
    public interface ICameraService : IService
    {
        void SetFollow(Transform transform);
        void ResetTarget();
    }

    public class CinemachineCameraService : ICameraService
    {
        private readonly CinemachineVirtualCamera _virtualCamera;

        private Transform _defaultFollow;

        public CinemachineCameraService(CinemachineVirtualCamera virtualCamera)
        {
            _virtualCamera = virtualCamera;
        }

        public void Initialize()
        {
            _defaultFollow = _virtualCamera.Follow;
        }

        public void Dispose()
        {
            ResetTarget();
        }

        public void SetFollow(Transform target)
        {
            _virtualCamera.Follow = target;
        }

        public void ResetTarget()
        {
            _virtualCamera.Follow = _defaultFollow;
        }
    }
}