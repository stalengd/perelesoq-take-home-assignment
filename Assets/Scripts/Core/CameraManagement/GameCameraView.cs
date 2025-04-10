using UnityEngine;

namespace Perelesoq.TestAssignment.Core.CameraManagement
{
    public sealed class GameCameraView : MonoBehaviour
    {
        [SerializeField] private Transform _root;

        public void AlignViewWith(Transform transform)
        {
            _root.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }
}
