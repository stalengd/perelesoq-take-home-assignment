using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Cameras
{
    public sealed class CameraDeviceGameView : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPoint;

        public Transform CameraPoint => _cameraPoint;
    }
}
