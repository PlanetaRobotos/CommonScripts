using Cinemachine;
using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.BehaviourStuff.CameraStuff
{
    public class SimpleCameraConnector : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;

        public void SetTargetFollow(Transform target)
        {
            _virtualCamera.Follow = target;
        }
        
        public void SetTargetLookAt(Transform target)
        {
            _virtualCamera.LookAt = target;
        }
    }
}