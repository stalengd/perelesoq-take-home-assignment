using Perelesoq.TestAssignment.Core.Devices;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.DeviceInitializers
{
    public sealed class DeviceInputPortInitializer : MonoBehaviour
    {
        [SerializeField] private DeviceOutputPortInitializer _connectedTo;

        public DeviceInputPort Port { get; set; }
        public DeviceOutputPortInitializer ConnectedTo => _connectedTo;

        private void OnDrawGizmos()
        {
            if (_connectedTo == null)
            {
                Gizmos.color = new Color(1f, 0f, 0.2f, 0.7f);
                Gizmos.DrawWireSphere(transform.position, 0.2f);
                return;
            }

            var fromCenter = _connectedTo.transform.position;
            var toCenter = transform.position;
            var direction = toCenter - fromCenter;

            Gizmos.color = new Color(1f, 0f, 1f, 0.5f);

            Gizmos.DrawLine(fromCenter, toCenter);
            DrawCone(toCenter, direction, 0.4f, 0.2f, 3);
        }

        private static void DrawCone(Vector3 tip, Vector3 direction, float length, float radius, int lines)
        {
            Vector3 basePoint = tip - direction.normalized * length;
            for (var i = 0; i < lines; i++)
            {
                Gizmos.DrawLine(basePoint + Quaternion.AngleAxis(360f * i / lines, direction) * Vector3.up * radius,
                    tip);
            }
        }
    }
}
